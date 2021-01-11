
namespace Cyotek.DownDetector.Client
{
  partial class UriInfoCollectionEditor
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.Label addressesLabel;
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.addButton = new System.Windows.Forms.Button();
      this.removeButton = new System.Windows.Forms.Button();
      this.settingsGroupBox = new System.Windows.Forms.GroupBox();
      this.useHeadCheckBox = new System.Windows.Forms.CheckBox();
      this.followRedirectsCheckBox = new System.Windows.Forms.CheckBox();
      this.ignoreSslErrorsCheckBox = new System.Windows.Forms.CheckBox();
      this.addressTextBox = new System.Windows.Forms.TextBox();
      this.addressLabel = new System.Windows.Forms.Label();
      this.selectionTimer = new System.Windows.Forms.Timer(this.components);
      this.addressesListView = new Cyotek.Windows.Forms.ListView();
      this.statusColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.uriColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ignoreSslErrorsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.followRedirectsColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.useHeadColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lastChangeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.errorProvider = new Cyotek.Windows.Forms.ErrorProvider(this.components);
      addressesLabel = new System.Windows.Forms.Label();
      this.settingsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // addressesLabel
      // 
      addressesLabel.AutoSize = true;
      this.errorProvider.SetErrorBackColor(addressesLabel, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      addressesLabel.Location = new System.Drawing.Point(-3, 0);
      addressesLabel.Name = "addressesLabel";
      addressesLabel.Size = new System.Drawing.Size(59, 13);
      addressesLabel.TabIndex = 0;
      addressesLabel.Text = "&Addresses:";
      // 
      // imageList
      // 
      this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
      this.imageList.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // addButton
      // 
      this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.errorProvider.SetErrorBackColor(this.addButton, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.addButton.Location = new System.Drawing.Point(599, 16);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(75, 23);
      this.addButton.TabIndex = 2;
      this.addButton.Text = "&Add...";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.AddButton_Click);
      // 
      // removeButton
      // 
      this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.removeButton.Enabled = false;
      this.errorProvider.SetErrorBackColor(this.removeButton, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.removeButton.Location = new System.Drawing.Point(599, 45);
      this.removeButton.Name = "removeButton";
      this.removeButton.Size = new System.Drawing.Size(75, 23);
      this.removeButton.TabIndex = 3;
      this.removeButton.Text = "&Remove";
      this.removeButton.UseVisualStyleBackColor = true;
      this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // settingsGroupBox
      // 
      this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.settingsGroupBox.Controls.Add(this.useHeadCheckBox);
      this.settingsGroupBox.Controls.Add(this.followRedirectsCheckBox);
      this.settingsGroupBox.Controls.Add(this.ignoreSslErrorsCheckBox);
      this.settingsGroupBox.Controls.Add(this.addressTextBox);
      this.settingsGroupBox.Controls.Add(this.addressLabel);
      this.settingsGroupBox.Enabled = false;
      this.errorProvider.SetErrorBackColor(this.settingsGroupBox, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.settingsGroupBox.Location = new System.Drawing.Point(0, 330);
      this.settingsGroupBox.Name = "settingsGroupBox";
      this.settingsGroupBox.Size = new System.Drawing.Size(593, 76);
      this.settingsGroupBox.TabIndex = 4;
      this.settingsGroupBox.TabStop = false;
      this.settingsGroupBox.Text = "Settings";
      // 
      // useHeadCheckBox
      // 
      this.useHeadCheckBox.AutoSize = true;
      this.errorProvider.SetErrorBackColor(this.useHeadCheckBox, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.useHeadCheckBox.Location = new System.Drawing.Point(231, 45);
      this.useHeadCheckBox.Name = "useHeadCheckBox";
      this.useHeadCheckBox.Size = new System.Drawing.Size(113, 17);
      this.useHeadCheckBox.TabIndex = 4;
      this.useHeadCheckBox.Text = "Use &Head Method";
      this.useHeadCheckBox.UseVisualStyleBackColor = true;
      this.useHeadCheckBox.CheckedChanged += new System.EventHandler(this.UseHeadCheckBox_CheckedChanged);
      // 
      // followRedirectsCheckBox
      // 
      this.followRedirectsCheckBox.AutoSize = true;
      this.errorProvider.SetErrorBackColor(this.followRedirectsCheckBox, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.followRedirectsCheckBox.Location = new System.Drawing.Point(121, 45);
      this.followRedirectsCheckBox.Name = "followRedirectsCheckBox";
      this.followRedirectsCheckBox.Size = new System.Drawing.Size(104, 17);
      this.followRedirectsCheckBox.TabIndex = 3;
      this.followRedirectsCheckBox.Text = "&Follow Redirects";
      this.followRedirectsCheckBox.UseVisualStyleBackColor = true;
      this.followRedirectsCheckBox.CheckedChanged += new System.EventHandler(this.FollowRedirectsCheckBox_CheckedChanged);
      // 
      // ignoreSslErrorsCheckBox
      // 
      this.ignoreSslErrorsCheckBox.AutoSize = true;
      this.errorProvider.SetErrorBackColor(this.ignoreSslErrorsCheckBox, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.ignoreSslErrorsCheckBox.Location = new System.Drawing.Point(6, 45);
      this.ignoreSslErrorsCheckBox.Name = "ignoreSslErrorsCheckBox";
      this.ignoreSslErrorsCheckBox.Size = new System.Drawing.Size(109, 17);
      this.ignoreSslErrorsCheckBox.TabIndex = 2;
      this.ignoreSslErrorsCheckBox.Text = "&Ignore SSL Errors";
      this.ignoreSslErrorsCheckBox.UseVisualStyleBackColor = true;
      this.ignoreSslErrorsCheckBox.CheckedChanged += new System.EventHandler(this.IgnoreSslErrorsCheckBox_CheckedChanged);
      // 
      // addressTextBox
      // 
      this.addressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.addressTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
      this.addressTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
      this.errorProvider.SetErrorBackColor(this.addressTextBox, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.addressTextBox.Location = new System.Drawing.Point(57, 19);
      this.addressTextBox.Name = "addressTextBox";
      this.addressTextBox.Size = new System.Drawing.Size(530, 20);
      this.addressTextBox.TabIndex = 1;
      this.addressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
      // 
      // addressLabel
      // 
      this.addressLabel.AutoSize = true;
      this.errorProvider.SetErrorBackColor(this.addressLabel, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.addressLabel.Location = new System.Drawing.Point(3, 22);
      this.addressLabel.Name = "addressLabel";
      this.addressLabel.Size = new System.Drawing.Size(48, 13);
      this.addressLabel.TabIndex = 0;
      this.addressLabel.Text = "A&ddress:";
      // 
      // selectionTimer
      // 
      this.selectionTimer.Tick += new System.EventHandler(this.SelectionTimer_Tick);
      // 
      // addressesListView
      // 
      this.addressesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.addressesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.statusColumnHeader,
            this.uriColumnHeader,
            this.ignoreSslErrorsColumnHeader,
            this.followRedirectsColumnHeader,
            this.useHeadColumnHeader,
            this.lastChangeColumnHeader});
      this.errorProvider.SetErrorBackColor(this.addressesListView, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.addressesListView.FullRowSelect = true;
      this.addressesListView.GridLines = true;
      this.addressesListView.HideSelection = false;
      this.addressesListView.Location = new System.Drawing.Point(0, 16);
      this.addressesListView.Name = "addressesListView";
      this.addressesListView.Size = new System.Drawing.Size(593, 308);
      this.addressesListView.SmallImageList = this.imageList;
      this.addressesListView.TabIndex = 1;
      this.addressesListView.UseCompatibleStateImageBehavior = false;
      this.addressesListView.View = System.Windows.Forms.View.Details;
      this.addressesListView.SelectedIndexChanged += new System.EventHandler(this.AddressesListView_SelectedIndexChanged);
      // 
      // statusColumnHeader
      // 
      this.statusColumnHeader.Text = "";
      this.statusColumnHeader.Width = 20;
      // 
      // uriColumnHeader
      // 
      this.uriColumnHeader.Text = "Address";
      this.uriColumnHeader.Width = 240;
      // 
      // ignoreSslErrorsColumnHeader
      // 
      this.ignoreSslErrorsColumnHeader.Text = "Ignore SSL?";
      // 
      // followRedirectsColumnHeader
      // 
      this.followRedirectsColumnHeader.Text = "Follow Redirects?";
      // 
      // useHeadColumnHeader
      // 
      this.useHeadColumnHeader.Text = "Head?";
      // 
      // lastChangeColumnHeader
      // 
      this.lastChangeColumnHeader.Text = "Last Change";
      this.lastChangeColumnHeader.Width = 120;
      // 
      // UriInfoCollectionEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.settingsGroupBox);
      this.Controls.Add(this.removeButton);
      this.Controls.Add(this.addButton);
      this.Controls.Add(this.addressesListView);
      this.Controls.Add(addressesLabel);
      this.errorProvider.SetErrorBackColor(this, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220))))));
      this.Name = "UriInfoCollectionEditor";
      this.Size = new System.Drawing.Size(674, 406);
      this.settingsGroupBox.ResumeLayout(false);
      this.settingsGroupBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Cyotek.Windows.Forms.ListView addressesListView;
    private System.Windows.Forms.ColumnHeader statusColumnHeader;
    private System.Windows.Forms.ColumnHeader uriColumnHeader;
    private System.Windows.Forms.ColumnHeader useHeadColumnHeader;
    private System.Windows.Forms.ColumnHeader ignoreSslErrorsColumnHeader;
    private System.Windows.Forms.ColumnHeader followRedirectsColumnHeader;
    private System.Windows.Forms.ColumnHeader lastChangeColumnHeader;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.Button removeButton;
    private System.Windows.Forms.CheckBox useHeadCheckBox;
    private System.Windows.Forms.CheckBox followRedirectsCheckBox;
    private System.Windows.Forms.CheckBox ignoreSslErrorsCheckBox;
    private System.Windows.Forms.TextBox addressTextBox;
    private System.Windows.Forms.GroupBox settingsGroupBox;
    private System.Windows.Forms.Label addressLabel;
    private System.Windows.Forms.Timer selectionTimer;
    private Windows.Forms.ErrorProvider errorProvider;
  }
}
