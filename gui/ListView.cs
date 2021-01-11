﻿using System;

namespace Cyotek.Windows.Forms
{
  internal class ListView : System.Windows.Forms.ListView
  {
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      if (!this.DesignMode && Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
      {
        NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
      }
    }
  }
}
