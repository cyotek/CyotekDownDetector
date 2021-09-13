// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

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

    private TimeSpan _wakeUpDelay;

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
      _wakeUpDelay = TimeSpan.FromSeconds(30);
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
      get => _addresses;
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
      get => _interval;
      set => this.UpdateAssignment(ref _interval, value, nameof(this.Interval));
    }

    public bool LogDatesAsUtc
    {
      get => _logDatesAsUtc;
      set => this.UpdateAssignment(ref _logDatesAsUtc, value, nameof(this.LogDatesAsUtc));
    }

    public int MaximumDisplayItems
    {
      get => _maximumDisplayItems;
      set => this.UpdateAssignment(ref _maximumDisplayItems, value, nameof(this.MaximumDisplayItems));
    }

    public int MaximumRedirects
    {
      get => _maximumRedirects;
      set => this.UpdateAssignment(ref _maximumRedirects, value, nameof(this.MaximumRedirects));
    }

    public bool ShowDisplayItems
    {
      get => _showDisplayItems;
      set => this.UpdateAssignment(ref _showDisplayItems, value, nameof(this.ShowDisplayItems));
    }

    public bool ShowNotifications
    {
      get => _showNotifications;
      set => this.UpdateAssignment(ref _showNotifications, value, nameof(this.ShowNotifications));
    }

    public bool ShowOfflineItemsOnly
    {
      get => _showOfflineItemsOnly;
      set => this.UpdateAssignment(ref _showOfflineItemsOnly, value, nameof(this.ShowOfflineItemsOnly));
    }

    public UriStatusInfoCollection Statuses
    {
      get => _statuses;
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
      get => _unstableInterval;
      set => this.UpdateAssignment(ref _unstableInterval, value, nameof(this.UnstableInterval));
    }

    public TimeSpan WakeUpDelay
    {
      get => _wakeUpDelay;
      set => this.UpdateAssignment(ref _wakeUpDelay, value, nameof(this.WakeUpDelay));
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