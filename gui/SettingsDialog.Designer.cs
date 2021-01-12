
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
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.Label displayCountLabel;
      System.Windows.Forms.GroupBox groupBox2;
      this.unstableIntervalTimeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
      this.intervalTimeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
      this.showNotificationsCheckBox = new System.Windows.Forms.CheckBox();
      this.displayCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
      this.tabList = new Cyotek.Windows.Forms.TabList();
      this.addressTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.uriInfoCollectionEditor = new Cyotek.DownDetector.Client.UriInfoCollectionEditor();
      this.settingsTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.aboutTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.aboutPanel = new Cyotek.Demo.Windows.Forms.AboutPanel();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      intervalLabel = new System.Windows.Forms.Label();
      checkSettingsGroupBox = new System.Windows.Forms.GroupBox();
      label1 = new System.Windows.Forms.Label();
      unstableIntervalLabel = new System.Windows.Forms.Label();
      intervalHelpLabel = new System.Windows.Forms.Label();
      groupBox1 = new System.Windows.Forms.GroupBox();
      displayCountLabel = new System.Windows.Forms.Label();
      groupBox2 = new System.Windows.Forms.GroupBox();
      checkSettingsGroupBox.SuspendLayout();
      groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.displayCountNumericUpDown)).BeginInit();
      groupBox2.SuspendLayout();
      this.tabList.SuspendLayout();
      this.addressTabListPage.SuspendLayout();
      this.settingsTabListPage.SuspendLayout();
      this.aboutTabListPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // intervalLabel
      // 
      intervalLabel.AutoSize = true;
      intervalLabel.Location = new System.Drawing.Point(6, 22);
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
      label1.Location = new System.Drawing.Point(98, 89);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(417, 13);
      label1.TabIndex = 5;
      label1.Text = "Defines how long a website remains in an unstable state before being classed as o" +
    "ffline";
      // 
      // unstableIntervalTimeSpanPicker
      // 
      this.unstableIntervalTimeSpanPicker.Location = new System.Drawing.Point(101, 65);
      this.unstableIntervalTimeSpanPicker.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
      this.unstableIntervalTimeSpanPicker.Name = "unstableIntervalTimeSpanPicker";
      this.unstableIntervalTimeSpanPicker.Size = new System.Drawing.Size(235, 21);
      this.unstableIntervalTimeSpanPicker.TabIndex = 4;
      // 
      // unstableIntervalLabel
      // 
      unstableIntervalLabel.AutoSize = true;
      unstableIntervalLabel.Location = new System.Drawing.Point(6, 68);
      unstableIntervalLabel.Name = "unstableIntervalLabel";
      unstableIntervalLabel.Size = new System.Drawing.Size(89, 13);
      unstableIntervalLabel.TabIndex = 3;
      unstableIntervalLabel.Text = "&Unstable interval:";
      // 
      // intervalHelpLabel
      // 
      intervalHelpLabel.AutoSize = true;
      intervalHelpLabel.ForeColor = System.Drawing.SystemColors.GrayText;
      intervalHelpLabel.Location = new System.Drawing.Point(98, 43);
      intervalHelpLabel.Name = "intervalHelpLabel";
      intervalHelpLabel.Size = new System.Drawing.Size(293, 13);
      intervalHelpLabel.TabIndex = 2;
      intervalHelpLabel.Text = "Defines how often the status of the websites will be checked";
      // 
      // intervalTimeSpanPicker
      // 
      this.intervalTimeSpanPicker.Location = new System.Drawing.Point(101, 19);
      this.intervalTimeSpanPicker.Name = "intervalTimeSpanPicker";
      this.intervalTimeSpanPicker.Size = new System.Drawing.Size(235, 21);
      this.intervalTimeSpanPicker.TabIndex = 1;
      // 
      // groupBox1
      // 
      groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      groupBox1.Controls.Add(this.showNotificationsCheckBox);
      groupBox1.Controls.Add(this.displayCountNumericUpDown);
      groupBox1.Controls.Add(displayCountLabel);
      groupBox1.Location = new System.Drawing.Point(0, 125);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(602, 76);
      groupBox1.TabIndex = 6;
      groupBox1.TabStop = false;
      groupBox1.Text = "Display";
      // 
      // showNotificationsCheckBox
      // 
      this.showNotificationsCheckBox.AutoSize = true;
      this.showNotificationsCheckBox.Location = new System.Drawing.Point(8, 45);
      this.showNotificationsCheckBox.Name = "showNotificationsCheckBox";
      this.showNotificationsCheckBox.Size = new System.Drawing.Size(221, 17);
      this.showNotificationsCheckBox.TabIndex = 7;
      this.showNotificationsCheckBox.Text = "Show &notification when a site goes offline";
      this.showNotificationsCheckBox.UseVisualStyleBackColor = true;
      // 
      // displayCountNumericUpDown
      // 
      this.displayCountNumericUpDown.Location = new System.Drawing.Point(189, 19);
      this.displayCountNumericUpDown.Name = "displayCountNumericUpDown";
      this.displayCountNumericUpDown.Size = new System.Drawing.Size(59, 20);
      this.displayCountNumericUpDown.TabIndex = 1;
      // 
      // displayCountLabel
      // 
      displayCountLabel.AutoSize = true;
      displayCountLabel.Location = new System.Drawing.Point(6, 21);
      displayCountLabel.Name = "displayCountLabel";
      displayCountLabel.Size = new System.Drawing.Size(177, 13);
      displayCountLabel.TabIndex = 0;
      displayCountLabel.Text = "Number of items to &display on menu:";
      // 
      // groupBox2
      // 
      groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      groupBox2.Controls.Add(this.startWithWindowsCheckBox);
      groupBox2.Location = new System.Drawing.Point(0, 207);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(602, 76);
      groupBox2.TabIndex = 8;
      groupBox2.TabStop = false;
      groupBox2.Text = "Startup";
      // 
      // startWithWindowsCheckBox
      // 
      this.startWithWindowsCheckBox.AutoSize = true;
      this.startWithWindowsCheckBox.Location = new System.Drawing.Point(6, 19);
      this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
      this.startWithWindowsCheckBox.Size = new System.Drawing.Size(117, 17);
      this.startWithWindowsCheckBox.TabIndex = 7;
      this.startWithWindowsCheckBox.Text = "Start &with Windows";
      this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
      // 
      // tabList
      // 
      this.tabList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabList.Controls.Add(this.addressTabListPage);
      this.tabList.Controls.Add(this.settingsTabListPage);
      this.tabList.Controls.Add(this.aboutTabListPage);
      this.tabList.Location = new System.Drawing.Point(12, 12);
      this.tabList.Name = "tabList";
      this.tabList.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
      this.tabList.Size = new System.Drawing.Size(760, 508);
      this.tabList.TabIndex = 0;
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
      this.settingsTabListPage.Controls.Add(groupBox2);
      this.settingsTabListPage.Controls.Add(groupBox1);
      this.settingsTabListPage.Controls.Add(checkSettingsGroupBox);
      this.settingsTabListPage.Name = "settingsTabListPage";
      this.settingsTabListPage.Size = new System.Drawing.Size(602, 506);
      this.settingsTabListPage.Text = "Settings";
      // 
      // aboutTabListPage
      // 
      this.aboutTabListPage.Controls.Add(this.aboutPanel);
      this.aboutTabListPage.Name = "aboutTabListPage";
      this.aboutTabListPage.Size = new System.Drawing.Size(602, 506);
      this.aboutTabListPage.Text = "About";
      // 
      // aboutPanel
      // 
      this.aboutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.aboutPanel.Location = new System.Drawing.Point(0, 0);
      this.aboutPanel.Name = "aboutPanel";
      this.aboutPanel.Size = new System.Drawing.Size(602, 506);
      this.aboutPanel.TabIndex = 0;
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
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.displayCountNumericUpDown)).EndInit();
      groupBox2.ResumeLayout(false);
      groupBox2.PerformLayout();
      this.tabList.ResumeLayout(false);
      this.addressTabListPage.ResumeLayout(false);
      this.settingsTabListPage.ResumeLayout(false);
      this.aboutTabListPage.ResumeLayout(false);
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
    private Demo.Windows.Forms.AboutPanel aboutPanel;
  }
}