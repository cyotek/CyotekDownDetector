using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Cyotek.DownDetector
{
  public class UriStatusInfoCollection : KeyedCollection<string, UriStatusInfo>, INotifyCollectionChanged
  {
    #region Public Events

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion Public Events

    #region Public Methods

    public bool TryGetValue(string url, out UriStatusInfo value)
    {
      IDictionary<string, UriStatusInfo> dictionary;
      bool result;

      dictionary = this.Dictionary;

      if (dictionary != null)
      {
        result = dictionary.TryGetValue(url, out value);
      }
      else
      {
        result = false;
        value = null;
      }

      return result;
    }

    public bool TryGetValue(Uri uri, out UriStatusInfo value)
    {
      return this.TryGetValue(uri.AbsoluteUri, out value);
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void ClearItems()
    {
      base.ClearItems();

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    protected override string GetKeyForItem(UriStatusInfo item)
    {
      return item.Uri.AbsoluteUri;
    }

    protected override void InsertItem(int index, UriStatusInfo item)
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
      UriStatusInfo oldItem;

      oldItem = this[index];

      base.RemoveItem(index);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
    }

    protected override void SetItem(int index, UriStatusInfo item)
    {
      UriStatusInfo oldItem;

      oldItem = this[index];

      base.SetItem(index, item);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, oldItem, index));
    }

    #endregion Protected Methods
  }
}