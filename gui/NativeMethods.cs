using System;
using System.Runtime.InteropServices;

// Enabling shell styles for the ListView and TreeView controls in C#
// https://devblog.cyotek.com/post/enabling-shell-styles-for-the-listview-and-treeview-controls-in-csharp

// Copyright © 2011 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Windows.Forms
{
  internal static class NativeMethods
  {
    #region Public Methods

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion Public Methods
  }
}