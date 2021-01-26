using System;
using System.Windows.Forms;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector.Client
{
  internal partial class SettingsPanel : SettingsPanelBase
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

    #endregion Private Fields

    #region Public Constructors

    public SettingsPanel()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Methods

    public override void LoadSettings(DownDetectorSettings settings)
    {
      intervalTimeSpanPicker.Value = settings.Interval;
      unstableIntervalTimeSpanPicker.Value = settings.UnstableInterval;
      displayCountNumericUpDown.Value = settings.MaximumDisplayItems;
      showNotificationsCheckBox.Checked = settings.ShowNotifications;
      startWithWindowsCheckBox.Checked = StartupManager.IsRegisteredForStartup();
      showMenuItemsCheckBox.Checked = settings.ShowDisplayItems;
      offlineOnlyCheckBox.Checked = settings.ShowOfflineItemsOnly;
      maximumRedirectsNumericUpDown.Value = settings.MaximumRedirects;

      base.LoadSettings(settings);
    }

    public override void SaveSettings(DownDetectorSettings settings)
    {
      settings.Interval = intervalTimeSpanPicker.Value;
      settings.UnstableInterval = unstableIntervalTimeSpanPicker.Value;
      settings.MaximumDisplayItems = (int)displayCountNumericUpDown.Value;
      settings.ShowNotifications = showNotificationsCheckBox.Checked;
      settings.ShowDisplayItems = showMenuItemsCheckBox.Checked;
      settings.ShowOfflineItemsOnly = offlineOnlyCheckBox.Checked;
      settings.MaximumRedirects = (int)maximumRedirectsNumericUpDown.Value;

      this.UpdateStartupSetting();

      base.SaveSettings(settings);
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      if (!this.DesignMode)
      {
        intervalTimeSpanPicker.Items.AddRange(_defaultIntervals);
        unstableIntervalTimeSpanPicker.Items.AddRange(_defaultIntervals);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void UpdateStartupSetting()
    {
      try
      {
        if (StartupManager.IsRegisteredForStartup() != startWithWindowsCheckBox.Checked)
        {
          if (startWithWindowsCheckBox.Checked)
          {
            StartupManager.RegisterStartupApplication();
          }
          else
          {
            StartupManager.UnregisterStartupApplication();
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to process startup changes. {0}", ex.Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    #endregion Private Methods
  }
}