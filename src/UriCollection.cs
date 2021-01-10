using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Cyotek.DownDetector
{
  public class UriCollection : Collection<Uri>, INotifyCollectionChanged
  {
    #region Public Events

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion Public Events

    #region Protected Methods

    protected override void ClearItems()
    {
      base.ClearItems();

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    protected override void InsertItem(int index, Uri item)
    {
      base.InsertItem(index, item);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
    }

    protected virtual void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      NotifyCollectionChangedEventHandler handler;

      handler = this.CollectionChanged;

      handler?.Invoke(this, e);
    }

    protected override void RemoveItem(int index)
    {
      Uri oldItem;

      oldItem = this[index];

      base.RemoveItem(index);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
    }

    protected override void SetItem(int index, Uri item)
    {
      Uri oldItem;

      oldItem = this[index];

      base.SetItem(index, item);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, oldItem, index));
    }

    #endregion Protected Methods
  }
}