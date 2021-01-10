using System;

namespace Cyotek.DownDetector
{
  public class UriStatusInfoEventArgs : UriEventArgs
  {
    #region Private Fields

    private UriStatusInfo _statusInfo;

    #endregion Private Fields

    #region Public Constructors

    public UriStatusInfoEventArgs(UriStatusInfo statusInfo)
      : base(statusInfo.Uri)
    {
      _statusInfo = statusInfo;
    }

    #endregion Public Constructors

    #region Protected Constructors

    protected UriStatusInfoEventArgs()
    {
    }

    #endregion Protected Constructors

    #region Public Properties

    public UriStatusInfo StatusInfo
    {
      get { return _statusInfo; }
      protected set { _statusInfo = value; }
    }

    #endregion Public Properties
  }
}