using System;
using System.ComponentModel;
using System.Windows.Forms;

// Creating long running Windows Forms applications without a start-up form
// https://devblog.cyotek.com/post/creating-long-running-windows-forms-applications-without-a-start-up-form

// Copyright © 2013-2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek
{
  internal abstract class TrayIconApplicationContext : ApplicationContext
  {
    #region Private Fields

    private const string _placeholderMenuName = "#dummy";

    private readonly ContextMenuStrip _contextMenu;

    private readonly NotifyIcon _notifyIcon;

    private bool _contextMenuLoaded;

    #endregion Private Fields

    #region Protected Constructors

    protected TrayIconApplicationContext()
    {
      _contextMenu = new ContextMenuStrip();

      // the Opening event will be raised if the menu is empty,
      // but it won't actually display - even if the Opening event
      // then populates the menu. So I add a dummy item which I will
      // then remove
      _contextMenu.Items.Add(new ToolStripSeparator { Name = _placeholderMenuName });
      _contextMenu.Opening += this.ContextMenuOpeningHandler;

      _notifyIcon = new NotifyIcon
      {
        ContextMenuStrip = _contextMenu,
        Text = Application.ProductName,
        Visible = true
      };

      _notifyIcon.MouseDoubleClick += this.TrayIconDoubleClickHandler;
      _notifyIcon.MouseClick += this.TrayIconClickHandler;
    }

    #endregion Protected Constructors

    #region Public Properties

    protected bool InvokeRequired => _contextMenu.InvokeRequired;

    #endregion Public Properties

    #region Protected Properties

    protected ContextMenuStrip ContextMenu => _contextMenu;

    protected NotifyIcon TrayIcon => _notifyIcon;

    #endregion Protected Properties

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_contextMenu != null)
        {
          _contextMenu.Opening -= this.ContextMenuOpeningHandler;
          _contextMenu.Dispose();
        }

        if (_notifyIcon != null)
        {
          _notifyIcon.MouseDoubleClick += this.TrayIconDoubleClickHandler;
          _notifyIcon.MouseClick += this.TrayIconClickHandler;
          _notifyIcon.Dispose();
        }
      }

      base.Dispose(disposing);
    }

    protected object Invoke(Delegate method)
    {
      return _contextMenu.Invoke(method);
    }

    protected object Invoke(Delegate method, params object[] args)
    {
      return _contextMenu.Invoke(method, args);
    }

    protected virtual void OnContextMenuOpening(CancelEventArgs e)
    {
    }

    protected virtual void OnInitializeContextMenu()
    {
    }

    protected virtual void OnTrayIconClick(MouseEventArgs e)
    {
    }

    protected virtual void OnTrayIconDoubleClick(MouseEventArgs e)
    {
    }

    #endregion Protected Methods

    #region Private Methods

    private void ContextMenuOpeningHandler(object sender, CancelEventArgs e)
    {
      if (!_contextMenuLoaded)
      {
        // remove the dummy item. Don't just clear the menu though,
        // in case the menu is manipulated outside the initial call
        _contextMenu.Items.RemoveByKey(_placeholderMenuName);

        _contextMenuLoaded = true;

        this.OnInitializeContextMenu();
      }

      this.OnContextMenuOpening(e);
    }

    private void TrayIconClickHandler(object sender, MouseEventArgs e)
    {
      this.OnTrayIconClick(e);
    }

    private void TrayIconDoubleClickHandler(object sender, MouseEventArgs e)
    {
      this.OnTrayIconDoubleClick(e);
    }

    #endregion Private Methods
  }
}