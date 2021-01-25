using System;
using System.Net;

namespace Cyotek.DownDetector
{
  public class UriStatusInfo
  {
    #region Private Fields

    private HttpStatusCode _httpStatus;

    private DateTimeOffset _lastChange;

    private UriStatus _status;

    private Uri _uri;

    #endregion Private Fields

    #region Public Properties

    public HttpStatusCode HttpStatus
    {
      get => _httpStatus;
      set => _httpStatus = value;
    }

    public DateTimeOffset LastChange
    {
      get => _lastChange;
      set => _lastChange = value;
    }

    public UriStatus Status
    {
      get => _status;
      set => _status = value;
    }

    public Uri Uri
    {
      get => _uri;
      set => _uri = value;
    }

    #endregion Public Properties
  }
}