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
  public class UriStatusInfoEventArgs : UriEventArgs
  {
    #region Private Fields

    private UriStatusInfo _statusInfo;

    #endregion Private Fields

    #region Public Constructors

    public UriStatusInfoEventArgs(UriStatusInfo statusInfo)
      : base(statusInfo.Uri)
    {
      _statusInfo = statusInfo;
    }

    #endregion Public Constructors

    #region Protected Constructors

    protected UriStatusInfoEventArgs()
    {
    }

    #endregion Protected Constructors

    #region Public Properties

    public UriStatusInfo StatusInfo
    {
      get { return _statusInfo; }
      protected set { _statusInfo = value; }
    }

    #endregion Public Properties
  }
}