using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Timers;

namespace Cyotek.DownDetector
{
  public class DownDetectorClient : IDisposable
  {
    #region Private Fields

    private static readonly object _eventChecked = new object();

    private static readonly object _eventChecking = new object();

    private static readonly object _eventUriChecked = new object();

    private static readonly object _eventUriChecking = new object();

    private static readonly object _eventUriException = new object();

    private static readonly object _eventUriSslPolicyError = new object();

    private static readonly object _eventUriStatusChanged = new object();

    private readonly HttpClient _httpClient;

    private readonly HttpMessageHandler _httpClientHandler;

    private bool _disposedValue;

    private EventHandlerList _events;

    private DownDetectorSettings _settings;

    private SslPolicyErrors _sslPolicyErrors;

    private ISynchronizeInvoke _synchronizingObject;

    private Timer _timer;

    #endregion Private Fields

    #region Public Constructors

    public DownDetectorClient()
    {
      ServicePointManager.MaxServicePointIdleTime = 1000;

      _httpClientHandler = new HttpClientHandler
      {
        AllowAutoRedirect = false,
        ServerCertificateCustomValidationCallback = this.ServerCertificateCustomValidationCallback,
      };

      _httpClient = new HttpClient(_httpClientHandler);

      _settings = new DownDetectorSettings();
      _settings.PropertyChanged += this.SettingsPropertyChangedHandler;

      _timer = new Timer
      {
        Interval = _settings.Interval.TotalMilliseconds,
        AutoReset = false
      };
      _timer.Elapsed += this.TimerElapsedHandler;
      _timer.Start();
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Action")]
    public event EventHandler Checked
    {
      add
      {
        this.Events.AddHandler(_eventChecked, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventChecked, value);
      }
    }

    [Category("Action")]
    public event EventHandler Checking
    {
      add
      {
        this.Events.AddHandler(_eventChecking, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventChecking, value);
      }
    }

    [Category("Action")]
    public event EventHandler<UriEventArgs> UriChecked
    {
      add
      {
        this.Events.AddHandler(_eventUriChecked, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventUriChecked, value);
      }
    }

    [Category("Action")]
    public event EventHandler<UriEventArgs> UriChecking
    {
      add
      {
        this.Events.AddHandler(_eventUriChecking, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventUriChecking, value);
      }
    }

    [Category("Action")]
    public event EventHandler<UriExceptionEventArgs> UriException
    {
      add
      {
        this.Events.AddHandler(_eventUriException, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventUriException, value);
      }
    }

    [Category("Action")]
    public event EventHandler<UriSslPolicyErrorEventArgs> UriSslPolicyError
    {
      add
      {
        this.Events.AddHandler(_eventUriSslPolicyError, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventUriSslPolicyError, value);
      }
    }

    [Category("Action")]
    public event EventHandler<UriStatusInfoEventArgs> UriStatusChanged
    {
      add
      {
        this.Events.AddHandler(_eventUriStatusChanged, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventUriStatusChanged, value);
      }
    }

    #endregion Public Events

    #region Public Properties

    public DownDetectorSettings Settings
    {
      get { return _settings; }
      set
      {
        if (!object.ReferenceEquals(_settings, value))
        {
          if (_settings != null)
          {
            _settings.PropertyChanged -= this.SettingsPropertyChangedHandler;
          }

          _settings = value;

          if (value != null)
          {
            value.PropertyChanged += this.SettingsPropertyChangedHandler;
          }
        }
      }
    }

    public ISynchronizeInvoke SynchronizingObject
    {
      get { return _synchronizingObject; }
      set
      {
        if (!object.ReferenceEquals(_synchronizingObject, value))
        {
          _synchronizingObject = value;

          _timer.SynchronizingObject = value;
        }
      }
    }

    #endregion Public Properties

    #region Protected Properties

    /// <summary>
    /// Gets the list of event handlers that are attached to this component.
    /// </summary>
    protected EventHandlerList Events
    {
      get { return _events ?? (_events = new EventHandlerList()); }
    }

    #endregion Protected Properties

    #region Public Methods

    public async Task CheckAll()
    {
      UriInfo[] info;

      this.OnChecking(EventArgs.Empty);

      _timer.Stop();

      info = _settings.Addresses.ToArray();

      for (int i = 0; i < info.Length; i++)
      {
        await this.CheckUri(info[i]).ConfigureAwait(false);
      }

      this.Reset();

      this.OnChecked(EventArgs.Empty);
    }

    public async Task CheckUri(UriInfo uriInfo)
    {
      Uri uri;
      UriEventArgs args;
      UriStatus newStatus;
      Exception error;
      HttpStatusCode httpStatus;

      uri = uriInfo.Uri;

      if (!_settings.Statuses.TryGetValue(uri, out UriStatusInfo status))
      {
        status = new UriStatusInfo
        {
          LastChange = DateTimeOffset.UtcNow,
          Status = UriStatus.Unknown,
          Uri = uri
        };

        _settings.Statuses.Add(status);
      }

      args = new UriEventArgs(uri);

      this.OnUriChecking(args);

      (newStatus, httpStatus, error) = await this.GetUriStatus(uriInfo).ConfigureAwait(false);

      if (error != null)
      {
        this.OnUriException(new UriExceptionEventArgs(uri, error));
      }

      this.UpdateStatus(status, httpStatus,newStatus);

      this.OnUriChecked(args);
    }

    public void Dispose()
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      this.Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    public void Reset()
    {
      _timer.Stop();
      _timer.Interval = _settings.Interval.TotalMilliseconds;
      _timer.Start();
    }

    #endregion Public Methods

    #region Protected Methods

    protected virtual void Dispose(bool disposing)
    {
      if (!_disposedValue)
      {
        if (disposing)
        {
          _timer.Stop();
          _timer.Dispose();
          _timer = null;
        }

        _disposedValue = true;
      }
    }

    /// <summary>
    /// Raises the <see cref="Checked" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnChecked(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventChecked];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="Checking" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnChecking(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventChecking];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="UriChecked" /> event.
    /// </summary>
    /// <param name="e">The <see cref="UriEventArgs" /> instance containing the event data.</param>
    protected virtual void OnUriChecked(UriEventArgs e)
    {
      EventHandler<UriEventArgs> handler;

      handler = (EventHandler<UriEventArgs>)this.Events[_eventUriChecked];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="UriChecking" /> event.
    /// </summary>
    /// <param name="e">The <see cref="UriEventArgs" /> instance containing the event data.</param>
    protected virtual void OnUriChecking(UriEventArgs e)
    {
      EventHandler<UriEventArgs> handler;

      handler = (EventHandler<UriEventArgs>)this.Events[_eventUriChecking];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="UriException" /> event.
    /// </summary>
    /// <param name="e">The <see cref="UriExceptionEventArgs" /> instance containing the event data.</param>
    protected virtual void OnUriException(UriExceptionEventArgs e)
    {
      EventHandler<UriExceptionEventArgs> handler;

      handler = (EventHandler<UriExceptionEventArgs>)this.Events[_eventUriException];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="UriSslPolicyError" /> event.
    /// </summary>
    /// <param name="e">The <see cref="UriSslPolicyErrorEventArgs" /> instance containing the event data.</param>
    protected virtual void OnUriSslPolicyError(UriSslPolicyErrorEventArgs e)
    {
      EventHandler<UriSslPolicyErrorEventArgs> handler;

      handler = (EventHandler<UriSslPolicyErrorEventArgs>)this.Events[_eventUriSslPolicyError];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="UriStatusChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="UriEventArgs" /> instance containing the event data.</param>
    protected virtual void OnUriStatusChanged(UriStatusInfoEventArgs e)
    {
      EventHandler<UriStatusInfoEventArgs> handler;

      handler = (EventHandler<UriStatusInfoEventArgs>)this.Events[_eventUriStatusChanged];

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private static HttpRequestMessage CreateRequest(UriInfo uriInfo, Uri uri)
    {
      return new HttpRequestMessage
      {
        Method = uriInfo.UseHead ? HttpMethod.Head : HttpMethod.Get,
        RequestUri = uri
      };
    }

    private static bool IsRedirectResponse(HttpStatusCode statusCode)
    {
      return statusCode == HttpStatusCode.Moved
      || statusCode == HttpStatusCode.Redirect
      || statusCode == HttpStatusCode.RedirectMethod
      || statusCode == HttpStatusCode.TemporaryRedirect
      || statusCode == HttpStatusCode.MovedPermanently
      || statusCode == (HttpStatusCode)308; // PermanentRedirect
    }

    private async Task<HttpStatusCode> GetResponseCode(UriInfo uriInfo)
    {
      int redirectCount;
      bool done;
      HttpRequestMessage request;
      HttpStatusCode statusCode;

      redirectCount = 0;
      done = false;

      request = DownDetectorClient.CreateRequest(uriInfo, uriInfo.Uri);

      do
      {
        HttpResponseMessage response;

        response = await _httpClient.SendAsync(request).ConfigureAwait(false);
        statusCode = response.StatusCode;

        if (DownDetectorClient.IsRedirectResponse(statusCode) && uriInfo.FollowRedirects)
        {
          redirectCount++;

          if (redirectCount > _settings.MaximumRedirects)
          {
            done = true;
          }
          else
          {
            Uri redirectUri;

            redirectUri = response.Headers.Location;

            if (!redirectUri.IsAbsoluteUri)
            {
              redirectUri = new Uri(request.RequestUri, redirectUri);
            }

            request = DownDetectorClient.CreateRequest(uriInfo, redirectUri);
          }
        }
        else
        {
          done = true;
        }
      } while (!done);

      return statusCode;
    }

    private async Task<Tuple<UriStatus, HttpStatusCode, Exception>> GetUriStatus(UriInfo uriInfo)
    {
      UriStatus newStatus;
      Exception error;
      HttpStatusCode httpStatus;

      _sslPolicyErrors = SslPolicyErrors.None;

      try
      {

        httpStatus = await this.GetResponseCode(uriInfo).ConfigureAwait(false);

        newStatus = httpStatus == HttpStatusCode.OK
          ? UriStatus.Online
          : UriStatus.Unstable;

        if (newStatus == UriStatus.Online && _sslPolicyErrors != SslPolicyErrors.None)
        {
          newStatus = uriInfo.IgnoreSslErrors
            ? UriStatus.InvalidCertificate
            : UriStatus.Unstable;
        }

        error = null;
      }
      catch (Exception ex)
      {
        newStatus = UriStatus.Unstable;
        httpStatus = 0;
        error = ex;
      }

      return Tuple.Create(newStatus, httpStatus, error);
    }

    private bool ServerCertificateCustomValidationCallback(HttpRequestMessage request, X509Certificate2 certificate, X509Chain certificateChain, SslPolicyErrors sslPolicyErrors)
    {
      if (sslPolicyErrors != SslPolicyErrors.None)
      {
        _sslPolicyErrors = sslPolicyErrors;
        this.OnUriSslPolicyError(new UriSslPolicyErrorEventArgs(request.RequestUri, sslPolicyErrors));
      }

      return true;
    }

    private void SettingsPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      if (string.Equals(e.PropertyName, nameof(DownDetectorSettings.Interval)))
      {
        this.Reset();
      }
    }

    private async void TimerElapsedHandler(object sender, ElapsedEventArgs e)
    {
      await this.CheckAll().ConfigureAwait(false);
    }

    private void UpdateStatus(UriStatusInfo status, HttpStatusCode httpStatus, UriStatus newStatus)
    {
      UriStatus previousStatus;

      previousStatus = status.Status;

      if (newStatus == UriStatus.Unstable)
      {
        if (previousStatus == UriStatus.Offline
          || (previousStatus == UriStatus.Unstable && status.LastChange + _settings.UnstableInterval < DateTimeOffset.UtcNow))
        {
          newStatus = UriStatus.Offline;
        }
      }

      if (newStatus != previousStatus)
      {
        status.LastChange = DateTimeOffset.UtcNow;
        status.Status = newStatus;
        status.HttpStatus = httpStatus;

        this.OnUriStatusChanged(new UriStatusInfoEventArgs(status));
      }
    }

    #endregion Private Methods
  }
}