
// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector.Client
{
  internal partial class AddressesPanel : SettingsPanelBase
  {
    #region Public Constructors

    public AddressesPanel()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Methods

    public override void LoadSettings(DownDetectorSettings settings)
    {
      uriInfoCollectionEditor.Statuses = settings.Statuses;
      uriInfoCollectionEditor.Items = settings.Addresses.Clone();

      base.LoadSettings(settings);
    }

    public override void SaveSettings(DownDetectorSettings settings)
    {
      settings.Addresses.Clear();
      settings.Addresses.AddRange(uriInfoCollectionEditor.Items);
      settings.Addresses.Sort();

      base.SaveSettings(settings);
    }

    #endregion Public Methods
  }
}