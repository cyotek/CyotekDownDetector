using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector
{
  public class UriStatusInfoCollection : KeyedCollection<string, UriStatusInfo>, INotifyCollectionChanged
  {
    #region Public Events

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion Public Events

    #region Public Methods

    public bool TryGetValue(UriInfo uriInfo, out UriStatusInfo value)
    {
      return this.TryGetValue(uriInfo.Uri, out value);
    }

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