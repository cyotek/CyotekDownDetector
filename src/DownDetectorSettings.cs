using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector
{
  public class DownDetectorSettings : INotifyPropertyChanged
  {
    #region Private Fields

    private UriInfoCollection _addresses;

    private TimeSpan _interval;

    private bool _logDatesAsUtc;

    private int _maximumDisplayItems;

    private int _maximumRedirects;

    private bool _showDisplayItems;

    private bool _showNotifications;

    private bool _showOfflineItemsOnly;

    private UriStatusInfoCollection _statuses;

    private TimeSpan _unstableInterval;

    #endregion Private Fields

    #region Public Constructors

    public DownDetectorSettings()
    {
      _addresses = new UriInfoCollection();
      _addresses.CollectionChanged += this.AddressesCollectionChangedHandler;

      _statuses = new UriStatusInfoCollection();
      _statuses.CollectionChanged += this.StatusesCollectionChangedHandler;

      _interval = TimeSpan.FromMinutes(1);
      _unstableInterval = TimeSpan.FromSeconds(90);
      _maximumDisplayItems = 25;
      _showNotifications = true;
      _showDisplayItems = true;
      _maximumRedirects = 3;
      _logDatesAsUtc = true;
    }

    #endregion Public Constructors

    #region Public Events

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion Public Events

    #region Public Properties

    public UriInfoCollection Addresses
    {
      get { return _addresses; }
      set
      {
        if (!object.ReferenceEquals(_addresses, value))
        {
          if (_addresses != null)
          {
            _addresses.CollectionChanged -= this.AddressesCollectionChangedHandler;
          }

          _addresses = value;

          if (value != null)
          {
            value.CollectionChanged += this.AddressesCollectionChangedHandler;
          }

          this.OnPropertyChanged(nameof(this.Addresses));
        }
      }
    }

    public TimeSpan Interval
    {
      get { return _interval; }
      set { this.UpdateAssignment(ref _interval, value, nameof(this.Interval)); }
    }

    public bool LogDatesAsUtc
    {
      get { return _logDatesAsUtc; }
      set { this.UpdateAssignment(ref _logDatesAsUtc, value, nameof(this.LogDatesAsUtc)); }
    }

    public int MaximumDisplayItems
    {
      get { return _maximumDisplayItems; }
      set { this.UpdateAssignment(ref _maximumDisplayItems, value, nameof(this.MaximumDisplayItems)); }
    }

    public int MaximumRedirects
    {
      get { return _maximumRedirects; }
      set { this.UpdateAssignment(ref _maximumRedirects, value, nameof(this.MaximumRedirects)); }
    }

    public bool ShowDisplayItems
    {
      get { return _showDisplayItems; }
      set { this.UpdateAssignment(ref _showDisplayItems, value, nameof(this.ShowDisplayItems)); }
    }

    public bool ShowNotifications
    {
      get { return _showNotifications; }
      set { this.UpdateAssignment(ref _showNotifications, value, nameof(this.ShowNotifications)); }
    }

    public bool ShowOfflineItemsOnly
    {
      get { return _showOfflineItemsOnly; }
      set { this.UpdateAssignment(ref _showOfflineItemsOnly, value, nameof(this.ShowOfflineItemsOnly)); }
    }

    public UriStatusInfoCollection Statuses
    {
      get { return _statuses; }
      set
      {
        if (!object.ReferenceEquals(_statuses, value))
        {
          if (_statuses != null)
          {
            _statuses.CollectionChanged -= this.StatusesCollectionChangedHandler;
          }

          _statuses = value;

          if (value != null)
          {
            value.CollectionChanged += this.StatusesCollectionChangedHandler;
          }

          this.OnPropertyChanged(nameof(this.Statuses));
        }
      }
    }

    public TimeSpan UnstableInterval
    {
      get { return _unstableInterval; }
      set { this.UpdateAssignment(ref _unstableInterval, value, nameof(this.UnstableInterval)); }
    }

    #endregion Public Properties

    #region Protected Methods

    /// <summary>
    /// Raises the <see cref="PropertyChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
      PropertyChangedEventHandler handler;

      handler = this.PropertyChanged;

      handler?.Invoke(this, e);
    }

    protected void OnPropertyChanged(string propertyName)
    {
      this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    protected void UpdateAssignment<T>(ref T value, T newValue, string propertyName)
    {
      if (!EqualityComparer<T>.Default.Equals(value, newValue))
      {
        value = newValue;

        this.OnPropertyChanged(propertyName);
      }
    }

    #endregion Protected Methods

    #region Private Methods

    private void AddressesCollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
      this.OnPropertyChanged(nameof(this.Addresses));
    }

    private void StatusesCollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
      this.OnPropertyChanged(nameof(this.Statuses));
    }

    #endregion Private Methods
  }
}