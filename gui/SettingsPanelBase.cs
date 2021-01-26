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
  internal class SettingsPanelBase : UserControl
  {
    #region Public Methods

    public virtual void LoadSettings(DownDetectorSettings settings)
    {
    }

    public virtual void SaveSettings(DownDetectorSettings settings)
    {
    }

    #endregion Public Methods
  }
}