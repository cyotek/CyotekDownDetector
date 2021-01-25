using Cyotek.Demo.Windows.Forms;
using Cyotek.DownDetector.Client.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.DownDetector.Client
{
  internal class DownDetectorApplicationContext : TrayIconApplicationContext
  {
    #region Private Fields

    private DownDetectorClient _client;

    private bool _loading;

    private string _logFileName;

    private Stream _logStream;

    private TextWriter _logWriter;

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
      _client.Checking += this.CheckingHandler;
      _client.Checked += this.CheckedHandler;

      this.InitializeLog();
      this.LoadSettings();

      this.SetDefaultToolTip();
      this.SetIcon();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_logWriter != null)
        {
          _logWriter.Flush();
          _logWriter.Dispose();
          _logWriter = null;
        }

        if (_logStream != null)
        {
          _logStream.Dispose();
          _logStream = null;
        }

        _client.UriChecking -= this.UriCheckingHandler;
        _client.UriChecked -= this.UriCheckedHandler;
        _client.UriStatusChanged -= this.UriStatusChangedHandler;
        _client.UriException -= this.UriExceptionHandler;
        _client.UriSslPolicyError -= this.UriSslPolicyErrorHandler;
        _client.Checking -= this.CheckingHandler;
        _client.Checked -= this.CheckedHandler;
        _client.Dispose();
        _client = null;
      }

      base.Dispose(disposing);
    }

    protected override void OnContextMenuOpening(CancelEventArgs e)
    {
      base.OnContextMenuOpening(e);

      this.LoadStatusItems();
    }

    protected override void OnInitializeContextMenu()
    {
      this.ContextMenu.Items.Add("&Settings...", null, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
      this.ContextMenu.Items.Add("Open &Log", null, this.OpenLogContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("&Check Now", null, this.CheckNowContextMenuClickHandler);
      this.ContextMenu.Items.Add("-");
      this.ContextMenu.Items.Add("E&xit", null, this.ExitContextMenuClickHandler);

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

    private async void CheckedHandler(object sender, EventArgs e)
    {
      await _logWriter.FlushAsync().ConfigureAwait(false);
    }

    private void CheckingHandler(object sender, EventArgs e)
    {
      this.Log("Checking sites");
    }

    private async void CheckNowContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      await _client.CheckAll().ConfigureAwait(false);
    }

    private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
    {
      this.ExitThread();
    }

    private int GetOfflineCount()
    {
      int offlineCount;
      UriInfoCollection addresses;
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
      UriInfoCollection addresses;
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

    private void InitializeLog()
    {
      _logFileName = Path.ChangeExtension(Application.ExecutablePath, ".log");

      _logStream = File.Open(_logFileName, FileMode.Append, FileAccess.Write, FileShare.Read);
      _logWriter = new StreamWriter(_logStream, Encoding.UTF8);
    }

    private void LoadSettings()
    {
      _settingsFileName = Path.ChangeExtension(Application.ExecutablePath, ".json");

      if (File.Exists(_settingsFileName))
      {
        Json.ParseFileInto(_settingsFileName, _client.Settings);
      }
    }

    private void LoadStatusItems()
    {
      if (!_loading)
      {
        ToolStripItemCollection items;

        _loading = true;

        items = this.ContextMenu.Items;

        this.RemoveExistingStatusItem(items);

        if (_client.Settings.ShowDisplayItems)
        {
          UriInfoCollection addresses;
          UriStatusInfoCollection statuses;
          int index;

          addresses = _client.Settings.Addresses;
          statuses = _client.Settings.Statuses;
          index = 0;

          for (int i = 0; i < addresses.Count; i++)
          {
            Uri uri;
            UriStatus status;

            uri = addresses[i].Uri;

            status = statuses.TryGetValue(uri, out UriStatusInfo statusInfo)
              ? statusInfo.Status
              : UriStatus.Unknown;

            if (status != UriStatus.Online || !_client.Settings.ShowOfflineItemsOnly)
            {
              ToolStripMenuItem item;

              item = new ToolStripMenuItem
              {
                Text = uri.AbsoluteUri,
                Tag = uri,
                Image = this.GetStatusImage(status)
              };

              item.Click += this.UrlMenuClickHandler;

              items.Insert(index, item);

              index++;

              if (index > _client.Settings.MaximumDisplayItems)
              {
                break;
              }
            }
          }

          if (index > 0)
          {
            items.Insert(index, new ToolStripSeparator
            {
              Tag = "sitebreak"
            });
          }
        }

        _loading = false;
      }
    }

    private void Log(string text)
    {
#if DEBUG
      System.Diagnostics.Debug.WriteLine(text);
#endif

      _logWriter.Write(DateTime.UtcNow);
      _logWriter.Write('\t');
      _logWriter.WriteLine(text);
    }

    private void OpenLogContextMenuClickHandler(object sender, EventArgs e)
    {
      AboutPanel.OpenUrl(_logFileName);
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
      if (toolTipText.Length >= 64)
      {
        toolTipText = toolTipText.Substring(0, 60) + "...";
      }

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

#if DEBUG
        System.Diagnostics.Debug.WriteLine(text);
#endif

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

    private void UriSslPolicyErrorHandler(object sender, UriSslPolicyErrorEventArgs e)
    {
      this.Log(string.Format("{0}: {1}", e.SslPolicyErrors, e.Uri));
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

        this.Log(string.Format("Site '{0}' is {1}", e.StatusInfo.Uri, e.StatusInfo.Status));

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

    private void UrlMenuClickHandler(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem item && item.Tag is Uri uri)
      {
        AboutPanel.OpenUrl(uri.AbsoluteUri);
      }
    }

    #endregion Private Methods
  }
}