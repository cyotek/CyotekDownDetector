using System;

namespace Cyotek.DownDetector
{
  public class UriInfo
  {
    #region Private Fields

    private bool _followRedirects;

    private bool _ignoreSslErrors;

    private Uri _uri;

    private bool _useHead;

    #endregion Private Fields

    #region Public Constructors

    public UriInfo(UriInfo copyFrom)
    {
      _followRedirects = copyFrom._followRedirects;
      _ignoreSslErrors = copyFrom._ignoreSslErrors;
      _useHead = copyFrom._useHead;
      _uri = new Uri(copyFrom._uri.OriginalString);
    }

    public UriInfo()
    {
      _followRedirects = false;
      _useHead = true;
    }

    public UriInfo(string uri)
      : this()
    {
      _uri = new Uri(uri);
    }

    #endregion Public Constructors

    #region Public Properties

    public bool FollowRedirects
    {
      get { return _followRedirects; }
      set { _followRedirects = value; }
    }

    public bool IgnoreSslErrors
    {
      get { return _ignoreSslErrors; }
      set { _ignoreSslErrors = value; }
    }

    public Uri Uri
    {
      get { return _uri; }
      set { _uri = value; }
    }

    public bool UseHead
    {
      get { return _useHead; }
      set { _useHead = value; }
    }

    #endregion Public Properties

    #region Public Methods

    public UriInfo Clone()
    {
      return new UriInfo(this);
    }

    #endregion Public Methods
  }
}