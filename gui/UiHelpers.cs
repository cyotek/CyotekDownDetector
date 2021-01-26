using Cyotek.DownDetector.Client.Properties;
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
  internal static class UiHelpers
  {
    #region Public Methods

    public static void AddStatusImages(this ImageList imageList)
    {
      imageList.Images.Add(Resources.StatusUnknown);
      imageList.Images.Add(Resources.StatusOnline);
      imageList.Images.Add(Resources.StatusSslError);
      imageList.Images.Add(Resources.StatusUnstable);
      imageList.Images.Add(Resources.StatusOffline);
    }

    public static string ToYesNoString(this bool value)
    {
      return value ? "Yes" : "No";
    }

    #endregion Public Methods
  }
}