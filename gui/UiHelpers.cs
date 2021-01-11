using Cyotek.DownDetector.Client.Properties;
using System.Windows.Forms;

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