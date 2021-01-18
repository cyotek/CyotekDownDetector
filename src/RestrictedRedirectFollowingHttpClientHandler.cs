using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Derived from
// https://stackoverflow.com/a/62121383/148962

namespace Cyotek.DownDetector
{
  internal sealed class RestrictedRedirectFollowingHttpClientHandler : HttpClientHandler
  {
    #region Private Fields

    private static readonly HttpStatusCode[] _redirectStatusCodes = new[]
    {
      HttpStatusCode.Moved,
      HttpStatusCode.Redirect,
      HttpStatusCode.RedirectMethod,
      HttpStatusCode.TemporaryRedirect,
      HttpStatusCode.MovedPermanently,
      (HttpStatusCode)308 // PermanentRedirect
    };

    private readonly Predicate<HttpResponseMessage> _isRedirectAllowed;

    #endregion Private Fields

    #region Public Constructors

    public RestrictedRedirectFollowingHttpClientHandler(Predicate<HttpResponseMessage> isRedirectAllowed)
    {
      this.AllowAutoRedirect = false;
      _isRedirectAllowed = response =>
      {
        return Array.BinarySearch(_redirectStatusCodes, response.StatusCode) >= 0 && isRedirectAllowed.Invoke(response);
      };
    }

    #endregion Public Constructors

    #region Public Properties

    public override bool SupportsRedirectConfiguration => false;

    #endregion Public Properties

    #region Protected Methods

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      int redirectCount;
      HttpResponseMessage response;

      redirectCount = 0;
      response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

      while (_isRedirectAllowed.Invoke(response)
          && (response.Headers.Location != request.RequestUri || (response.StatusCode == HttpStatusCode.RedirectMethod && request.Method != HttpMethod.Get))
          && redirectCount < this.MaxAutomaticRedirections)
      {
        if (response.StatusCode == HttpStatusCode.RedirectMethod)
        {
          request.Method = HttpMethod.Get;
        }

        request.RequestUri = response.Headers.Location;
        response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        redirectCount++;
      }

      return response;
    }

    #endregion Protected Methods
  }
}