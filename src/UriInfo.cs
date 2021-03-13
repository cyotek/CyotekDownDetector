using System;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector
{
  public class UriInfo
  {
    #region Private Fields

    private bool _enabled;

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
      _enabled = copyFrom.Enabled;
    }

    public UriInfo()
    {
      _followRedirects = true;
      _useHead = true;
      _enabled = true;
    }

    public UriInfo(string uri)
      : this()
    {
      _uri = new Uri(uri);
    }

    #endregion Public Constructors

    #region Public Properties

    public bool Enabled
    {
      get => _enabled;
      set => _enabled = value;
    }

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