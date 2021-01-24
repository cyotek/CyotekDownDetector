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