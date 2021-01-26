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