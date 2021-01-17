using Cyotek.Demo.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.DownDetector.Client
{
  internal partial class AddAddressesDialog : BaseForm
  {
    #region Private Fields

    private static readonly char[] _uriComponentCharacters = { '.', '/', '?' };

    private string[] _addresses;

    #endregion Private Fields

    #region Public Constructors

    public AddAddressesDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string[] Addresses
    {
      get { return _addresses; }
      set { _addresses = value; }
    }

    #endregion Public Properties

    #region Private Methods

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private string[] GetAddresses()
    {
      List<string> addresses;

      addresses = new List<string>();

      foreach (string line in addressesTextBox.Lines)
      {
        if (!string.IsNullOrWhiteSpace(line))
        {
          string address;

          address = this.MakeAddress(line);

          if (!addresses.Contains(address))
          {
            addresses.Add(address);
          }
        }
      }

      return addresses.ToArray();
    }

    private string MakeAddress(string address)
    {
      int protocolEndPosition;
      int otherPosition;

      address = address.Trim();

      protocolEndPosition = address.IndexOf(':');
      otherPosition = address.IndexOfAny(_uriComponentCharacters);

      if (protocolEndPosition == -1
        || (otherPosition != -1 && protocolEndPosition > otherPosition))
      {
        address = "http://" + address;
      }

      return address;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (this.ValidateAddresses())
      {
        _addresses = this.GetAddresses();

        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      else
      {
        this.DialogResult = DialogResult.None;
      }
    }

    private bool ValidateAddresses()
    {
      StringBuilder sb;
      bool result;

      sb = new StringBuilder();
      result = true;

      foreach (string line in addressesTextBox.Lines)
      {
        if (!string.IsNullOrWhiteSpace(line))
        {
          string address;

          address = this.MakeAddress(line);

          if (!Uri.TryCreate(address, UriKind.Absolute, out Uri _))
          {
            sb.AppendLine(line);
            result = false;
          }
        }
      }

      if (!result)
      {
        MessageBox.Show(string.Format("The following addresses are invalid:\r\n\r\n{0}", sb.ToString()), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      return result;
    }

    #endregion Private Methods
  }
}