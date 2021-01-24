using System.Windows.Forms;

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