using System;

namespace Cyotek.DownDetector
{
  public class UriStatusInfo
  {
    #region Private Fields

    private DateTimeOffset _lastChange;

    private UriStatus _status;

    private Uri _uri;

    #endregion Private Fields

    #region Public Properties

    public DateTimeOffset LastChange
    {
      get { return _lastChange; }
      set { _lastChange = value; }
    }

    public UriStatus Status
    {
      get { return _status; }
      set { _status = value; }
    }

    public Uri Uri
    {
      get { return _uri; }
      set { _uri = value; }
    }

    #endregion Public Properties
  }
}