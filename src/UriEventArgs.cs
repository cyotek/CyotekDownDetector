using System;

namespace Cyotek.DownDetector
{
  public class UriEventArgs : EventArgs
  {
    #region Private Fields

    private Uri _uri;

    #endregion Private Fields

    #region Public Constructors

    public UriEventArgs(Uri uri)
    {
      _uri = uri;
    }

    #endregion Public Constructors

    #region Protected Constructors

    protected UriEventArgs()
    {
    }

    #endregion Protected Constructors

    #region Public Properties

    public Uri Uri
    {
      get { return _uri; }
      protected set { _uri = value; }
    }

    #endregion Public Properties
  }
}