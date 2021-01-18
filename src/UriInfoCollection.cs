using Cyotek.SvnMigrate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Cyotek.DownDetector
{
  public class UriInfoCollection : KeyedCollection<string, UriInfo>, INotifyCollectionChanged
  {
    #region Public Events

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion Public Events

    #region Public Methods

    public UriInfo Add(string url)
    {
      return this.Add(new Uri(url));
    }

    public UriInfo Add(Uri uri)
    {
      UriInfo uriInfo;

      uriInfo = new UriInfo
      {
        Uri = uri
      };

      this.Add(uriInfo);

      return uriInfo;
    }

    public void AddRange(IEnumerable<UriInfo> items)
    {
      foreach (UriInfo item in items)
      {
        this.Add(item);
      }
    }

    public UriInfoCollection Clone()
    {
      UriInfoCollection clone;

      clone = new UriInfoCollection();

      for (int i = 0; i < this.Count; i++)
      {
        clone.Add(this[i].Clone());
      }

      return clone;
    }

    public void Sort()
    {
      SortHelpers.QuickSort(this.Items, (x, y) => x.Uri.AbsoluteUri.CompareTo(y.Uri.AbsoluteUri));

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public UriInfo[] ToArray()
    {
      UriInfo[] results;

      results = new UriInfo[this.Count];
      this.Items.CopyTo(results, 0);

      return results;
    }

    public bool TryGetValue(string url, out UriInfo value)
    {
      IDictionary<string, UriInfo> dictionary;
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

    public bool TryGetValue(Uri uri, out UriInfo value)
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

    protected override string GetKeyForItem(UriInfo item)
    {
      return item.Uri.AbsoluteUri;
    }

    protected override void InsertItem(int index, UriInfo item)
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
      UriInfo oldItem;

      oldItem = this[index];

      base.RemoveItem(index);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
    }

    protected override void SetItem(int index, UriInfo item)
    {
      UriInfo oldItem;

      oldItem = this[index];

      base.SetItem(index, item);

      this.OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, oldItem, index));
    }

    #endregion Protected Methods
  }
}