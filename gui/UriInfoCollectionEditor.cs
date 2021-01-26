using System;
using System.ComponentModel;
using System.Windows.Forms;

// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.DownDetector.Client
{
  public partial class UriInfoCollectionEditor : UserControl
  {
    #region Private Fields

    private UriInfoCollection _items;

    private UriInfo _selectedItem;

    private UriInfo[] _selectedItems;

    private bool _skipChangeEvents;

    private UriStatusInfoCollection _statuses;

    #endregion Private Fields

    #region Public Constructors

    public UriInfoCollectionEditor()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public UriInfoCollection Items
    {
      get { return _items; }
      set
      {
        if (!object.ReferenceEquals(_items, value))
        {
          _items = value;

          this.Populate();
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public UriStatusInfoCollection Statuses
    {
      get { return _statuses; }
      set
      {
        if (!object.ReferenceEquals(_statuses, value))
        {
          _statuses = value;

          this.Populate();
        }
      }
    }

    #endregion Public Properties

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      imageList.AddStatusImages();
    }

    #endregion Protected Methods

    #region Private Methods

    private void AddButton_Click(object sender, EventArgs e)
    {
      using (AddAddressesDialog dialog = new AddAddressesDialog())
      {
        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
          string[] addresses;

          addresses = dialog.Addresses;

          for (int i = 0; i < addresses.Length; i++)
          {
            string address;

            address = addresses[i];

            if (!_items.Contains(address))
            {
              UriInfo item;
              ListViewItem listViewItem;

              item = new UriInfo(address);

              listViewItem = this.CreateListViewItem(item);

              this.Populate(item, listViewItem);

              addressesListView.Items.Add(listViewItem);

              _items.Add(item);
            }
          }
        }
      }
    }

    private void AddressesListView_SelectedIndexChanged(object sender, EventArgs e)
    {
      selectionTimer.Stop();
      selectionTimer.Start();
    }

    private void AddressTextBox_TextChanged(object sender, EventArgs e)
    {
      if (!_skipChangeEvents && _selectedItem != null)
      {
        if (Uri.TryCreate(addressTextBox.Text, UriKind.Absolute, out Uri uri))
        {
          errorProvider.ClearError(addressTextBox);
          _selectedItem.Uri = uri;
          this.UpdateSelection(_selectedItem);
        }
        else
        {
          errorProvider.SetError(addressTextBox, "Invalid address.");
        }
      }
    }

    private ListViewItem CreateListViewItem(UriInfo item)
    {
      ListViewItem listViewItem;

      listViewItem = new ListViewItem
      {
        Tag = item
      };
      for (int j = 0; j < addressesListView.Columns.Count; j++)
      {
        listViewItem.SubItems.Add(string.Empty);
      }

      return listViewItem;
    }

    private void FollowRedirectsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (!_skipChangeEvents && _selectedItem != null)
      {
        this.UpdateSelection(i => i.FollowRedirects = followRedirectsCheckBox.Checked);
      }
    }

    private CheckState GetCheckState(Predicate<UriInfo> predicate)
    {
      CheckState checkState;

      checkState = (CheckState)(-1);

      for (int i = 0; i < _selectedItems.Length; i++)
      {
        bool isSet;

        isSet = predicate(_selectedItems[i]);

        if (checkState == (CheckState)(-1))
        {
          checkState = isSet ? CheckState.Checked : CheckState.Unchecked;
        }
        else if ((checkState == CheckState.Checked && !isSet) || (checkState == CheckState.Unchecked && isSet))
        {
          checkState = CheckState.Indeterminate;
          break;
        }
      }

      return checkState;
    }

    private int GetImageIndex(UriInfo item)
    {
      return _statuses != null && _statuses.TryGetValue(item, out UriStatusInfo info)
        ? (int)info.Status
        : 0;
    }

    private string GetLastUpdated(UriInfo item)
    {
      return _statuses != null && _statuses.TryGetValue(item, out UriStatusInfo info) && info.LastChange != DateTimeOffset.MinValue
        ? info.LastChange.LocalDateTime.ToString()
        : string.Empty;
    }

    private void IgnoreSslErrorsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (!_skipChangeEvents && _selectedItems != null)
      {
        this.UpdateSelection(i => i.IgnoreSslErrors = ignoreSslErrorsCheckBox.Checked);
      }
    }

    private void Populate()
    {
      addressesListView.BeginUpdate();
      addressesListView.Items.Clear();

      if (_items != null)
      {
        for (int i = 0; i < _items.Count; i++)
        {
          UriInfo item;
          ListViewItem listViewItem;

          item = _items[i];

          listViewItem = this.CreateListViewItem(item);

          this.Populate(item, listViewItem);

          addressesListView.Items.Add(listViewItem);
        }
      }

      addressesListView.EndUpdate();
    }

    private void Populate(UriInfo item, ListViewItem listViewItem)
    {
      listViewItem.ImageIndex = this.GetImageIndex(item);
      listViewItem.SubItems[1].Text = item.Uri.AbsoluteUri;
      listViewItem.SubItems[2].Text = item.IgnoreSslErrors.ToYesNoString();
      listViewItem.SubItems[3].Text = item.FollowRedirects.ToYesNoString();
      listViewItem.SubItems[4].Text = item.UseHead.ToYesNoString();
      listViewItem.SubItems[5].Text = this.GetLastUpdated(item);
    }

    private void PopulateMultiSelectionFields()
    {
      ignoreSslErrorsCheckBox.CheckState = this.GetCheckState(i => i.IgnoreSslErrors);
      followRedirectsCheckBox.CheckState = this.GetCheckState(i => i.FollowRedirects);
      useHeadCheckBox.CheckState = this.GetCheckState(i => i.UseHead);
    }

    private void PopulateSelectedFields()
    {
      addressTextBox.Text = _selectedItem.Uri.AbsoluteUri;
      ignoreSslErrorsCheckBox.Checked = _selectedItem.IgnoreSslErrors;
      followRedirectsCheckBox.Checked = _selectedItem.FollowRedirects;
      useHeadCheckBox.Checked = _selectedItem.UseHead;
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to remove the selected items?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        UriInfo[] items;
        int[] indexes;

        items = (UriInfo[])_selectedItems.Clone();

        indexes = new int[items.Length];
        addressesListView.SelectedIndices.CopyTo(indexes, 0);

        for (int i = 0; i < items.Length; i++)
        {
          _items.Remove(items[i]);
        }

        for (int i = indexes.Length; i > 0; i--)
        {
          addressesListView.Items.RemoveAt(indexes[i - 1]);
        }
      }
    }

    private void SelectionTimer_Tick(object sender, EventArgs e)
    {
      bool one;
      bool many;

      selectionTimer.Stop();

      one = addressesListView.FocusedItem != null;
      many = addressesListView.SelectedIndices.Count > 1;

      removeButton.Enabled = one || many;
      settingsGroupBox.Enabled = one || many;
      addressLabel.Enabled = one;
      addressTextBox.Enabled = one;

      if (one || many)
      {
        _selectedItem = (UriInfo)addressesListView.FocusedItem?.Tag;
        _selectedItems = new UriInfo[addressesListView.SelectedIndices.Count];
        for (int i = 0; i < addressesListView.SelectedIndices.Count; i++)
        {
          _selectedItems[i] = (UriInfo)addressesListView.Items[addressesListView.SelectedIndices[i]].Tag;
        }

        _skipChangeEvents = true;
        if (one)
        {
          this.PopulateSelectedFields();
        }
        if (many)
        {
          this.PopulateMultiSelectionFields();
        }
        _skipChangeEvents = false;
      }
      else
      {
        _selectedItem = null;
        _selectedItems = null;
      }
    }

    private void UpdateSelection(UriInfo item)
    {
      foreach (ListViewItem listViewItem in addressesListView.Items)
      {
        if (listViewItem.Tag != null && object.ReferenceEquals(listViewItem.Tag, item))
        {
          this.Populate(item, listViewItem);
          break;
        }
      }
    }

    private void UpdateSelection(Action<UriInfo> action)
    {
      foreach (ListViewItem listViewItem in addressesListView.SelectedItems)
      {
        UriInfo info;

        info = (UriInfo)listViewItem.Tag;

        action(info);

        this.Populate(info, listViewItem);
      }
    }

    private void UseHeadCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      if (!_skipChangeEvents && _selectedItem != null)
      {
        this.UpdateSelection(i => i.UseHead = useHeadCheckBox.Checked);
      }
    }

    #endregion Private Methods
  }
}