using System;
using System.Net;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

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