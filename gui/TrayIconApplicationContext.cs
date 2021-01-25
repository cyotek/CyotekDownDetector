using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Cyotek
{
  internal abstract class TrayIconApplicationContext : ApplicationContext
  {
    #region Private Fields

    private const string _placeholderMenuName = "#dummy";

    private ContextMenuStrip _contextMenu;

    private bool _contextMenuLoaded;

    private NotifyIcon _notifyIcon;

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

    #region Protected Properties

    protected ContextMenuStrip ContextMenu
    {
      get { return _contextMenu; }
    }

    protected bool InvokeRequired
    {
      get { return _contextMenu.InvokeRequired; }
    }

    protected NotifyIcon TrayIcon
    {
      get { return _notifyIcon; }
    }

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
          _contextMenu = null;
        }

        if (_notifyIcon != null)
        {
          _notifyIcon.MouseDoubleClick += this.TrayIconDoubleClickHandler;
          _notifyIcon.MouseClick += this.TrayIconClickHandler;
          _notifyIcon.Dispose();
          _notifyIcon = null;
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