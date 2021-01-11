using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Cyotek.Demo.Windows.Forms
{
  internal partial class AboutPanel : UserControl
  {
    #region Public Constructors

    public AboutPanel()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Internal Methods

    internal static void OpenCyotekHomePage()
    {
      AboutPanel.OpenUrl("https://www.cyotek.com");
    }

    internal static void OpenUrl(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion Internal Methods

    #region Protected Methods

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      nameLabel.Font = new Font(this.Font, FontStyle.Bold);
    }

    protected override void OnLoad(EventArgs e)
    {
      FileVersionInfo versionInfo;
      int x;
      int w;

      if (!this.DesignMode)
      {
        versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        nameLabel.Text = versionInfo.ProductName;
        versionLabel.Text = "Version " + versionInfo.ProductVersion;
        copyrightLabel.Text = versionInfo.LegalCopyright;

        iconPictureBox.Size = SystemInformation.IconSize;
        iconPictureBox.Image = GetIconBitmap();

        x = iconPictureBox.Right + iconPictureBox.Margin.Right + nameLabel.Margin.Left;
        w = this.ClientSize.Width - (iconPictureBox.Left + x);

        nameLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);
        versionLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);
        copyrightLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);
        infoLinkLabel.SetBounds(x, 0, w, 0, BoundsSpecified.X | BoundsSpecified.Width);

        this.LoadAboutText();
      }

      base.OnLoad(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private static Bitmap GetIconBitmap()
    {
      using (Icon icon = Icon.ExtractAssociatedIcon(Process.GetCurrentProcess().MainModule.FileName))
      {
        return icon.ToBitmap();
      }
    }

    private void InfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      AboutPanel.OpenUrl((string)e.Link.LinkData);
    }

    private void LoadAboutText()
    {
      string fileName;

      fileName = Path.Combine(Application.StartupPath, "about.txt");

      if (File.Exists(fileName))
      {
        string text;
        int linkStart;

        text = File.ReadAllText(fileName);

        infoLinkLabel.Text = text;
        linkStart = -1;

        do
        {
          linkStart = text.IndexOf('<', linkStart + 1);

          if (linkStart != -1)
          {
            int linkEnd;

            linkEnd = text.IndexOf('>', linkStart);

            if (linkEnd != -1)
            {
              int length;
              string link;

              length = linkEnd - linkStart;
              link = text.Substring(linkStart + 1, length - 1);

              infoLinkLabel.Links.Add(linkStart + 1, length - 1, link);
            }
          }
        } while (linkStart != -1);
      }
    }

    private void WebLinkLabel_LinkClicked(object sender, EventArgs e)
    {
      AboutPanel.OpenCyotekHomePage();
    }

    #endregion Private Methods
  }
}