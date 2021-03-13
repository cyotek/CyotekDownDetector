using System;
using System.Windows.Forms;

// Enabling shell styles for the ListView and TreeView controls in C#
// https://devblog.cyotek.com/post/enabling-shell-styles-for-the-listview-and-treeview-controls-in-csharp

// Copyright © 2011 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Windows.Forms
{
  internal class ListView : System.Windows.Forms.ListView
  {
    #region Private Fields

    private bool _ignoreEvents;

    #endregion Private Fields

    #region Protected Methods

    protected override void OnHandleCreated(EventArgs e)
    {
      _ignoreEvents = true;
      
      base.OnHandleCreated(e);

      if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
      {
        NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
      }

      _ignoreEvents = false;
    }

    protected override void OnItemChecked(ItemCheckedEventArgs e)
    {
      if (!_ignoreEvents)
      {
        base.OnItemChecked(e);
      }
    }

    #endregion Protected Methods
  }
}