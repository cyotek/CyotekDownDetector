
namespace Cyotek.DownDetector.Client
{
  partial class SettingsDialog
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.Label intervalLabel;
      System.Windows.Forms.GroupBox checkSettingsGroupBox;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label unstableIntervalLabel;
      System.Windows.Forms.Label intervalHelpLabel;
      System.Windows.Forms.GroupBox menuGroupBox;
      System.Windows.Forms.Label displayCountLabel;
      System.Windows.Forms.GroupBox startupGroupBox;
      System.Windows.Forms.GroupBox notificationsGroupBox;
      this.unstableIntervalTimeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
      this.intervalTimeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
      this.offlineOnlyCheckBox = new System.Windows.Forms.CheckBox();
      this.showMenuItemsCheckBox = new System.Windows.Forms.CheckBox();
      this.displayCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
      this.showNotificationsCheckBox = new System.Windows.Forms.CheckBox();
      this.tabList = new Cyotek.Windows.Forms.TabList();
      this.addressTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.uriInfoCollectionEditor = new Cyotek.DownDetector.Client.UriInfoCollectionEditor();
      this.settingsTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.logTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.aboutTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      intervalLabel = new System.Windows.Forms.Label();
      checkSettingsGroupBox = new System.Windows.Forms.GroupBox();
      label1 = new System.Windows.Forms.Label();
      unstableIntervalLabel = new System.Windows.Forms.Label();
      intervalHelpLabel = new System.Windows.Forms.Label();
      menuGroupBox = new System.Windows.Forms.GroupBox();
      displayCountLabel = new System.Windows.Forms.Label();
      startupGroupBox = new System.Windows.Forms.GroupBox();
      notificationsGroupBox = new System.Windows.Forms.GroupBox();
      checkSettingsGroupBox.SuspendLayout();
      menuGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.displayCountNumericUpDown)).BeginInit();
      startupGroupBox.SuspendLayout();
      notificationsGroupBox.SuspendLayout();
      this.tabList.SuspendLayout();
      this.addressTabListPage.SuspendLayout();
      this.settingsTabListPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // intervalLabel
      // 
      intervalLabel.AutoSize = true;
      intervalLabel.Location = new System.Drawing.Point(3, 22);
      intervalLabel.Name = "intervalLabel";
      intervalLabel.Size = new System.Drawing.Size(78, 13);
      intervalLabel.TabIndex = 0;
      intervalLabel.Text = "Check &interval:";
      // 
      // checkSettingsGroupBox
      // 
      checkSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      checkSettingsGroupBox.Controls.Add(label1);
      checkSettingsGroupBox.Controls.Add(this.unstableIntervalTimeSpanPicker);
      checkSettingsGroupBox.Controls.Add(unstableIntervalLabel);
      checkSettingsGroupBox.Controls.Add(intervalHelpLabel);
      checkSettingsGroupBox.Controls.Add(intervalLabel);
      checkSettingsGroupBox.Controls.Add(this.intervalTimeSpanPicker);
      checkSettingsGroupBox.Location = new System.Drawing.Point(0, -1);
      checkSettingsGroupBox.Name = "checkSettingsGroupBox";
      checkSettingsGroupBox.Size = new System.Drawing.Size(602, 120);
      checkSettingsGroupBox.TabIndex = 0;
      checkSettingsGroupBox.TabStop = false;
      checkSettingsGroupBox.Text = "Availability Checks";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.ForeColor = System.Drawing.SystemColors.GrayText;
      label1.Location = new System.Drawing.Point(95, 89);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(417, 13);
      label1.TabIndex = 5;
      label1.Text = "Defines how long a website remains in an unstable state before being classed as o" +
    "ffline";
      // 
      // unstableIntervalTimeSpanPicker
      // 
      this.unstableIntervalTimeSpanPicker.Location = new System.Drawing.Point(98, 65);
      this.unstableIntervalTimeSpanPicker.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
      this.unstableIntervalTimeSpanPicker.Name = "unstableIntervalTimeSpanPicker";
      this.unstableIntervalTimeSpanPicker.Size = new System.Drawing.Size(235, 21);
      this.unstableIntervalTimeSpanPicker.TabIndex = 4;
      // 
      // unstableIntervalLabel
      // 
      unstableIntervalLabel.AutoSize = true;
      unstableIntervalLabel.Location = new System.Drawing.Point(3, 68);
      unstableIntervalLabel.Name = "unstableIntervalLabel";
      unstableIntervalLabel.Size = new System.Drawing.Size(89, 13);
      unstableIntervalLabel.TabIndex = 3;
      unstableIntervalLabel.Text = "&Unstable interval:";
      // 
      // intervalHelpLabel
      // 
      intervalHelpLabel.AutoSize = true;
      intervalHelpLabel.ForeColor = System.Drawing.SystemColors.GrayText;
      intervalHelpLabel.Location = new System.Drawing.Point(95, 43);
      intervalHelpLabel.Name = "intervalHelpLabel";
      intervalHelpLabel.Size = new System.Drawing.Size(293, 13);
      intervalHelpLabel.TabIndex = 2;
      intervalHelpLabel.Text = "Defines how often the status of the websites will be checked";
      // 
      // intervalTimeSpanPicker
      // 
      this.intervalTimeSpanPicker.Location = new System.Drawing.Point(98, 19);
      this.intervalTimeSpanPicker.Name = "intervalTimeSpanPicker";
      this.intervalTimeSpanPicker.Size = new System.Drawing.Size(235, 21);
      this.intervalTimeSpanPicker.TabIndex = 1;
      // 
      // menuGroupBox
      // 
      menuGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      menuGroupBox.Controls.Add(this.offlineOnlyCheckBox);
      menuGroupBox.Controls.Add(this.showMenuItemsCheckBox);
      menuGroupBox.Controls.Add(this.displayCountNumericUpDown);
      menuGroupBox.Controls.Add(displayCountLabel);
      menuGroupBox.Location = new System.Drawing.Point(0, 125);
      menuGroupBox.Name = "menuGroupBox";
      menuGroupBox.Size = new System.Drawing.Size(602, 98);
      menuGroupBox.TabIndex = 1;
      menuGroupBox.TabStop = false;
      menuGroupBox.Text = "Display";
      // 
      // offlineOnlyCheckBox
      // 
      this.offlineOnlyCheckBox.AutoSize = true;
      this.offlineOnlyCheckBox.Location = new System.Drawing.Point(23, 42);
      this.offlineOnlyCheckBox.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
      this.offlineOnlyCheckBox.Name = "offlineOnlyCheckBox";
      this.offlineOnlyCheckBox.Size = new System.Drawing.Size(169, 17);
      this.offlineOnlyCheckBox.TabIndex = 1;
      this.offlineOnlyCheckBox.Text = "Only show sites that are &offline";
      this.offlineOnlyCheckBox.UseVisualStyleBackColor = true;
      // 
      // showMenuItemsCheckBox
      // 
      this.showMenuItemsCheckBox.AutoSize = true;
      this.showMenuItemsCheckBox.Location = new System.Drawing.Point(6, 19);
      this.showMenuItemsCheckBox.Name = "showMenuItemsCheckBox";
      this.showMenuItemsCheckBox.Size = new System.Drawing.Size(159, 17);
      this.showMenuItemsCheckBox.TabIndex = 0;
      this.showMenuItemsCheckBox.Text = "Show &sites on context menu";
      this.showMenuItemsCheckBox.UseVisualStyleBackColor = true;
      // 
      // displayCountNumericUpDown
      // 
      this.displayCountNumericUpDown.Location = new System.Drawing.Point(190, 65);
      this.displayCountNumericUpDown.Name = "displayCountNumericUpDown";
      this.displayCountNumericUpDown.Size = new System.Drawing.Size(59, 20);
      this.displayCountNumericUpDown.TabIndex = 3;
      // 
      // displayCountLabel
      // 
      displayCountLabel.AutoSize = true;
      displayCountLabel.Location = new System.Drawing.Point(3, 67);
      displayCountLabel.Name = "displayCountLabel";
      displayCountLabel.Size = new System.Drawing.Size(172, 13);
      displayCountLabel.TabIndex = 2;
      displayCountLabel.Text = "Maximum items to &display on menu:";
      // 
      // startupGroupBox
      // 
      startupGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      startupGroupBox.Controls.Add(this.startWithWindowsCheckBox);
      startupGroupBox.Location = new System.Drawing.Point(0, 288);
      startupGroupBox.Name = "startupGroupBox";
      startupGroupBox.Size = new System.Drawing.Size(602, 53);
      startupGroupBox.TabIndex = 3;
      startupGroupBox.TabStop = false;
      startupGroupBox.Text = "Startup";
      // 
      // startWithWindowsCheckBox
      // 
      this.startWithWindowsCheckBox.AutoSize = true;
      this.startWithWindowsCheckBox.Location = new System.Drawing.Point(6, 19);
      this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
      this.startWithWindowsCheckBox.Size = new System.Drawing.Size(117, 17);
      this.startWithWindowsCheckBox.TabIndex = 0;
      this.startWithWindowsCheckBox.Text = "Start &with Windows";
      this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
      // 
      // notificationsGroupBox
      // 
      notificationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      notificationsGroupBox.Controls.Add(this.showNotificationsCheckBox);
      notificationsGroupBox.Location = new System.Drawing.Point(0, 229);
      notificationsGroupBox.Name = "notificationsGroupBox";
      notificationsGroupBox.Size = new System.Drawing.Size(602, 53);
      notificationsGroupBox.TabIndex = 2;
      notificationsGroupBox.TabStop = false;
      notificationsGroupBox.Text = "Notifications";
      // 
      // showNotificationsCheckBox
      // 
      this.showNotificationsCheckBox.AutoSize = true;
      this.showNotificationsCheckBox.Location = new System.Drawing.Point(6, 19);
      this.showNotificationsCheckBox.Name = "showNotificationsCheckBox";
      this.showNotificationsCheckBox.Size = new System.Drawing.Size(221, 17);
      this.showNotificationsCheckBox.TabIndex = 0;
      this.showNotificationsCheckBox.Text = "Show &notification when a site goes offline";
      this.showNotificationsCheckBox.UseVisualStyleBackColor = true;
      // 
      // tabList
      // 
      this.tabList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabList.Controls.Add(this.addressTabListPage);
      this.tabList.Controls.Add(this.settingsTabListPage);
      this.tabList.Controls.Add(this.logTabListPage);
      this.tabList.Controls.Add(this.aboutTabListPage);
      this.tabList.Location = new System.Drawing.Point(12, 12);
      this.tabList.Name = "tabList";
      this.tabList.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
      this.tabList.Size = new System.Drawing.Size(760, 508);
      this.tabList.TabIndex = 0;
      this.tabList.Selected += new System.EventHandler<Cyotek.Windows.Forms.TabListEventArgs>(this.TabList_Selected);
      // 
      // addressTabListPage
      // 
      this.addressTabListPage.Controls.Add(this.uriInfoCollectionEditor);
      this.addressTabListPage.Name = "addressTabListPage";
      this.addressTabListPage.Size = new System.Drawing.Size(602, 506);
      this.addressTabListPage.Text = "Addresses";
      // 
      // uriInfoCollectionEditor
      // 
      this.uriInfoCollectionEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uriInfoCollectionEditor.Location = new System.Drawing.Point(0, 0);
      this.uriInfoCollectionEditor.Name = "uriInfoCollectionEditor";
      this.uriInfoCollectionEditor.Size = new System.Drawing.Size(602, 506);
      this.uriInfoCollectionEditor.TabIndex = 0;
      // 
      // settingsTabListPage
      // 
      this.settingsTabListPage.Controls.Add(notificationsGroupBox);
      this.settingsTabListPage.Controls.Add(startupGroupBox);
      this.settingsTabListPage.Controls.Add(menuGroupBox);
      this.settingsTabListPage.Controls.Add(checkSettingsGroupBox);
      this.settingsTabListPage.Name = "settingsTabListPage";
      this.settingsTabListPage.Size = new System.Drawing.Size(602, 506);
      this.settingsTabListPage.Text = "Settings";
      // 
      // logTabListPage
      // 
      this.logTabListPage.Name = "logTabListPage";
      this.logTabListPage.Size = new System.Drawing.Size(602, 506);
      this.logTabListPage.Text = "Log Tail";
      // 
      // aboutTabListPage
      // 
      this.aboutTabListPage.Name = "aboutTabListPage";
      this.aboutTabListPage.Size = new System.Drawing.Size(602, 506);
      this.aboutTabListPage.Text = "About";
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(616, 526);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 0;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(697, 526);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // SettingsDialog
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(784, 561);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.tabList);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "SettingsDialog";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Cyotek Down Detector";
      checkSettingsGroupBox.ResumeLayout(false);
      checkSettingsGroupBox.PerformLayout();
      menuGroupBox.ResumeLayout(false);
      menuGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.displayCountNumericUpDown)).EndInit();
      startupGroupBox.ResumeLayout(false);
      startupGroupBox.PerformLayout();
      notificationsGroupBox.ResumeLayout(false);
      notificationsGroupBox.PerformLayout();
      this.tabList.ResumeLayout(false);
      this.addressTabListPage.ResumeLayout(false);
      this.settingsTabListPage.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Cyotek.Windows.Forms.TabList tabList;
    private Cyotek.Windows.Forms.TabListPage addressTabListPage;
    private Cyotek.Windows.Forms.TabListPage settingsTabListPage;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.TimeSpanPicker intervalTimeSpanPicker;
    private System.Windows.Forms.TimeSpanPicker unstableIntervalTimeSpanPicker;
    private System.Windows.Forms.NumericUpDown displayCountNumericUpDown;
    private System.Windows.Forms.CheckBox showNotificationsCheckBox;
    private System.Windows.Forms.CheckBox startWithWindowsCheckBox;
    private UriInfoCollectionEditor uriInfoCollectionEditor;
    private Windows.Forms.TabListPage aboutTabListPage;
    private System.Windows.Forms.CheckBox offlineOnlyCheckBox;
    private System.Windows.Forms.CheckBox showMenuItemsCheckBox;
    private Windows.Forms.TabListPage logTabListPage;
  }
}