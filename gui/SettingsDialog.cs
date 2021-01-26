using Cyotek.Demo.Windows.Forms;
using Cyotek.DownDetector.Client.Properties;
using Cyotek.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
  internal partial class SettingsDialog : BaseForm
  {
    #region Private Fields

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

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.Icon = Resources.ApplicationIcon;

      // selecting event isn't called on first load
      this.TabList_Selected(tabList, new TabListEventArgs(tabList.SelectedPage, tabList.SelectedIndex, TabListAction.Selected));
    }

    #endregion Protected Methods

    #region Private Methods

    private void AddPage<T>(TabListPage host)
      where T : UserControl, new()
    {
      T control;

      control = new T()
      {
        Dock = DockStyle.Fill
      };

      if (control is SettingsPanelBase settingsPanel)
      {
        settingsPanel.LoadSettings(_settings);
      }

      host.Controls.Add(control);
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private IEnumerable<SettingsPanelBase> GetSettingsPanels()
    {
      foreach (TabListPage page in tabList.TabListPages)
      {
        if (page.Controls.Count == 1 && page.Controls[0] is SettingsPanelBase settingsPanel)
        {
          yield return settingsPanel;
        }
      }
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      this.SaveSettings();

      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void SaveSettings()
    {
      foreach (SettingsPanelBase settingsPanel in this.GetSettingsPanels())
      {
        settingsPanel.SaveSettings(_settings);
      }
    }

    private void TabList_Selected(object sender, TabListEventArgs e)
    {
      TabListPage page;

      page = e.TabListPage;

      if (page?.Controls.Count == 0)
      {
        if (object.ReferenceEquals(page, addressTabListPage))
        {
          this.AddPage<AddressesPanel>(page);
        }
        else if (object.ReferenceEquals(page, settingsTabListPage))
        {
          this.AddPage<SettingsPanel>(page);
        }
        else if (object.ReferenceEquals(page, aboutTabListPage))
        {
          this.AddPage<AboutPanel>(page);
        }
        else if (object.ReferenceEquals(page, logTabListPage))
        {
          this.AddPage<LogViewerPanel>(page);
        }
      }
    }

    #endregion Private Methods
  }
}