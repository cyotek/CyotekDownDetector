using System;

namespace Cyotek.DownDetector
{
  public class UriExceptionEventArgs : UriEventArgs
  {
    #region Private Fields

    private Exception _exception;

    #endregion Private Fields

    #region Public Constructors

    public UriExceptionEventArgs(Uri uri, Exception exception)
      : base(uri)
    {
      _exception = exception;
    }

    #endregion Public Constructors

    #region Protected Constructors

    protected UriExceptionEventArgs()
    {
    }

    #endregion Protected Constructors

    #region Public Properties

    public Exception Exception
    {
      get { return _exception; }
      protected set { _exception = value; }
    }

    #endregion Public Properties
  }
}