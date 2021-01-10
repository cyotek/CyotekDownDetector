using Cyotek.Demo.Windows.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cyotek.DownDetector.Client
{
  internal partial class SettingsDialog : BaseForm
  {
    #region Private Fields

    private static readonly TimeSpan2[] _defaultIntervals = new[]
    {
      TimeSpan2.FromSeconds(30),
      TimeSpan2.FromMinutes(1),
      TimeSpan2.FromSeconds(90),
      TimeSpan2.FromMinutes(5),
      TimeSpan2.FromMinutes(10),
      TimeSpan2.FromMinutes(15),
      TimeSpan2.FromMinutes(20),
      TimeSpan2.FromMinutes(25),
      TimeSpan2.FromMinutes(30),
      TimeSpan2.FromMinutes(45),
      TimeSpan2.FromHours(1),
      TimeSpan2.FromHours(2),
      TimeSpan2.FromHours(4),
      TimeSpan2.FromHours(8),
      TimeSpan2.FromHours(12),
      TimeSpan2.FromDays(1)
    };

    private DownDetectorSettings _settings;

    #endregion Private Fields

    #region Public Constructors

    public SettingsDialog()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DownDetectorSettings Settings
    {
      get { return _settings; }
      set { _settings = value; }
    }

    #endregion Public Properties

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      this.PopulateFields();
    }

    #endregion Protected Methods

    #region Private Methods

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      _settings.Addresses.Clear();
      _settings.Interval = intervalTimeSpanPicker.Value;
      _settings.UnstableInterval = unstableIntervalTimeSpanPicker.Value;
      _settings.MaximumDisplayItems = (int)displayCountNumericUpDown.Value;
      _settings.ShowNotifications = showNotificationsCheckBox.Checked;
      _settings.StartWithWindows = startWithWindowsCheckBox.Checked;

      foreach (string line in addressesTextBox.Lines)
      {
        if (!string.IsNullOrEmpty(line))
        {
          _settings.Addresses.Add(new Uri(line));
        }
      }

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void PopulateFields()
    {
      intervalTimeSpanPicker.Items.AddRange(_defaultIntervals);
      unstableIntervalTimeSpanPicker.Items.AddRange(_defaultIntervals);

      if (_settings != null)
      {
        addressesTextBox.Text = string.Join(Environment.NewLine, _settings.Addresses);
        intervalTimeSpanPicker.Value = _settings.Interval;
        unstableIntervalTimeSpanPicker.Value = _settings.UnstableInterval;
        displayCountNumericUpDown.Value = _settings.MaximumDisplayItems;
        showNotificationsCheckBox.Checked = _settings.ShowNotifications;
        startWithWindowsCheckBox.Checked = _settings.StartWithWindows;
      }
    }

    #endregion Private Methods
  }
}