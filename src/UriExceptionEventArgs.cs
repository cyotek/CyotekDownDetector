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