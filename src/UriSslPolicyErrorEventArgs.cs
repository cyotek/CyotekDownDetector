using System;
using System.Net.Security;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector
{
  public class UriSslPolicyErrorEventArgs : UriEventArgs
  {
    #region Private Fields

    private SslPolicyErrors _sslPolicyErrors;

    #endregion Private Fields

    #region Public Constructors

    public UriSslPolicyErrorEventArgs(Uri uri, SslPolicyErrors sslPolicyErrors)
      : base(uri)
    {
      _sslPolicyErrors = sslPolicyErrors;
    }

    #endregion Public Constructors

    #region Protected Constructors

    protected UriSslPolicyErrorEventArgs()
    {
    }

    #endregion Protected Constructors

    #region Public Properties

    public SslPolicyErrors SslPolicyErrors
    {
      get { return _sslPolicyErrors; }
      protected set { _sslPolicyErrors = value; }
    }

    #endregion Public Properties
  }
}