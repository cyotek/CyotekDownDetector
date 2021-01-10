using Cyotek.DownDetector.Client.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Cyotek.DownDetector.Client
{
  internal class DownDetectorApplicationContext : TrayIconApplicationContext
  {
    #region Private Fields

    private DownDetectorClient _client;

    private SettingsDialog _settingsDialog;

    private string _settingsFileName;

    #endregion Private Fields

    #region Public Constructors

    public DownDetectorApplicationContext()
    {
      _client = new DownDetectorClient();
      _client.UriChecking += this.UriCheckingHandler;
      _client.UriChecked += this.UriCheckedHandler;
      _client.UriStatusChanged += this.UriStatusChangedHandler;
      _client.UriException += this.UriExceptionHandler;
      _client.UriSslPolicyError += this.UriSslPolicyErrorHandler;

      this.LoadSettings();

      this.SetDefaultToolTip();
      this.SetIcon();
    }

    private void UriSslPolicyErrorHandler(object sender, UriSslPolicyErrorEventArgs e)
    {
      this.Log(string.Format("{0}: {1}", e.SslPolicyErrors, e.Uri));
    }

    #endregion Public Constructors

    #region Internal Methods

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

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _client.UriChecking -= this.UriCheckingHandler;
        _client.UriChecked -= this.UriCheckedHandler;
        _client.UriStatusChanged -= this.UriStatusChangedHandler;
        _client.UriException -= this.UriExceptionHandler;
      _client.UriSslPolicyError -= this.UriSslPolicyErrorHandler;
        _client.Dispose();
        _client = null;
      }

      base.Dispose(disposing);
    }

    protected override void OnInitializeContextMenu()
    {
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&Settings...", null, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&Check Now", null, this.CheckNowContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);

      this.LoadStatusItems();

      base.OnInitializeContextMenu();
    }

    protected override void OnTrayIconDoubleClick(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.ShowSettings();
      }

      base.OnTrayIconDoubleClick(e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ExitThread();
    }

    private async void CheckNowContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      await _client.CheckAll().ConfigureAwait(false);
    }

    private int GetOfflineCount()
    {
      int offlineCount;
      UriCollection addresses;
      UriStatusInfoCollection statuses;

      offlineCount = 0;
      addresses = _client.Settings.Addresses;
      statuses = _client.Settings.Statuses;

      for (int i = 0; i < addresses.Count; i++)
      {
        if (statuses.TryGetValue(addresses[i], out UriStatusInfo statusInfo) && statusInfo.Status == UriStatus.Offline)
        {
          offlineCount++;
        }
      }

      return offlineCount;
    }

    private Image GetStatusImage(UriStatus status)
    {
      Image result;

      switch (status)
      {
        case UriStatus.Online:
          result = Resources.StatusOnline;
          break;

        case UriStatus.Unstable:
          result = Resources.StatusUnstable;
          break;

        case UriStatus.InvalidCertificate:
          result = Resources.StatusSslError;
          break;

        case UriStatus.Offline:
          result = Resources.StatusOffline;
          break;

        default:
          result = Resources.StatusUnknown;
          break;
      }

      return result;
    }

    private UriStatus GetWorstStatus()
    {
      UriStatus worstStatus;
      UriCollection addresses;
      UriStatusInfoCollection statuses;

      worstStatus = UriStatus.Online;
      addresses = _client.Settings.Addresses;
      statuses = _client.Settings.Statuses;

      for (int i = 0; i < addresses.Count; i++)
      {
        if (statuses.TryGetValue(addresses[i], out UriStatusInfo statusInfo) && statusInfo.Status > worstStatus)
        {
          worstStatus = statusInfo.Status;

          if (worstStatus == UriStatus.Offline)
          {
            break;
          }
        }
      }

      return worstStatus;
    }

    private void LoadSettings()
    {
      _settingsFileName = Path.ChangeExtension(Application.ExecutablePath, ".json");

      if (File.Exists(_settingsFileName))
      {
        Json.ParseFileInto(_settingsFileName, _client.Settings);
      }
    }

    private bool _loading;

    private void LoadStatusItems()
    {
      if (!_loading)
      {
        ToolStripItemCollection items;
        UriCollection addresses;
        UriStatusInfoCollection statuses;

        _loading = true;

        items = this.ContextMenu.Items;
        addresses = _client.Settings.Addresses;
        statuses = _client.Settings.Statuses;

        this.RemoveExistingStatusItem(items);

        for (int i = 0; i < addresses.Count; i++)
        {
          Uri uri;
          UriStatus status;
          ToolStripMenuItem item;

          uri = addresses[i];

          status = statuses.TryGetValue(uri, out UriStatusInfo statusInfo)
            ? statusInfo.Status
            : UriStatus.Unknown;

          item = new ToolStripMenuItem
          {
            Text = uri.AbsoluteUri,
            Tag = uri,
            Image = this.GetStatusImage(status)
          };

          item.Click += this.UrlMenuClickHandler;

          items.Insert(i, item);

          if (i > _client.Settings.MaximumDisplayItems)
          {
            break;
          }
        }

        _loading = false;
      }
    }

    private void Log(string text)
    {
      Trace.WriteLine(text);
    }

    private void RemoveExistingStatusItem(ToolStripItemCollection items)
    {
      for (int i = items.Count; i > 0; i--)
      {
        ToolStripItem item;

        item = items[i - 1];

        if (item.Tag != null)
        {
          item.Click -= this.UrlMenuClickHandler;
          items.RemoveAt(i - 1);
        }
      }
    }

    private void SaveSettings()
    {
      Json.WriteFile(_settingsFileName, _client.Settings, JsonOptions.WriteWhitespace);
    }

    private void SetDefaultToolTip()
    {
      int offlineCount;
      string text;

      offlineCount = this.GetOfflineCount();
      text = string.Format("{0}\r\n{1}\r\n\r\n{2} sites offline", Application.ProductName, Application.ProductVersion, offlineCount);

      this.SetToolTip(text);
    }

    private void SetIcon()
    {
      switch (this.GetWorstStatus())
      {
        case UriStatus.Online:
          this.TrayIcon.Icon = Resources.IconOnline;
          break;

        case UriStatus.Offline:
          this.TrayIcon.Icon = Resources.IconOffline;
          break;

        default:
          this.TrayIcon.Icon = Resources.IconUnstable;
          break;
      }
    }

    private void SettingsContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ShowSettings();
    }

    private void SetToolTip(string toolTipText)
    {
      this.TrayIcon.Text = toolTipText;
    }

    private void ShowSettings()
    {
      if (_settingsDialog == null)
      {
        using (_settingsDialog = new SettingsDialog
        {
          Settings = _client.Settings
        })
        {
          if (_settingsDialog.ShowDialog() == DialogResult.OK)
          {
            this.SaveSettings();
            this.LoadStatusItems();
          }
        }
        _settingsDialog = null;
      }
      else
      {
        _settingsDialog.Activate();
      }
    }

    private void UriCheckedHandler(object sender, UriEventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action<object, UriEventArgs>(this.UriCheckedHandler), sender, e);
      }
      else
      {
        this.SetDefaultToolTip();
      }
    }

    private void UriCheckingHandler(object sender, UriEventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action<object, UriEventArgs>(this.UriCheckingHandler), sender, e);
      }
      else
      {
        string text;

        text = string.Format("Checking: {0}", e.Uri);

        this.Log(text);
        this.SetToolTip(text);
      }
    }

    private void UriExceptionHandler(object sender, UriExceptionEventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action<object, UriExceptionEventArgs>(this.UriExceptionHandler), sender, e);
      }
      else
      {
        this.Log(string.Format("Failed to check URL '{0}'. {1}.", e.Uri, e.Exception.Message));
      }
    }

    private void UriStatusChangedHandler(object sender, UriStatusInfoEventArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action<object, UriStatusInfoEventArgs>(this.UriStatusChangedHandler), sender, e);
      }
      else
      {
        this.SaveSettings();

        this.UpdateStatusIcon(e.StatusInfo);

        this.SetIcon();

        if (e.StatusInfo.Status == UriStatus.Offline && _client.Settings.ShowNotifications)
        {
          string title;
          string text;

          title = "Site Offline";
          text = string.Format("Site '{0}' is offline.", e.Uri);

          this.TrayIcon.ShowBalloonTip(1000, text, title, ToolTipIcon.Error);
        }
      }
    }

    private void UpdateStatusIcon(UriStatusInfo statusInfo)
    {
      ToolStripItemCollection items;

      items = this.ContextMenu.Items;

      for (int i = 0; i < items.Count; i++)
      {
        if (items[i] is ToolStripMenuItem item && item.Tag is Uri uri && uri.Equals(statusInfo.Uri))
        {
          item.Image = this.GetStatusImage(statusInfo.Status);
          break;
        }
      }
    }

    private void UrlMenuClickHandler(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem item && item.Tag is Uri uri)
      {
        DownDetectorApplicationContext.OpenUrl(uri.AbsoluteUri);
      }
    }

    #endregion Private Methods
  }
}