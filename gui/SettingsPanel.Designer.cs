
namespace Cyotek.DownDetector.Client
{
  partial class SettingsPanel
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
      System.Windows.Forms.GroupBox notificationsGroupBox;
      System.Windows.Forms.GroupBox startupGroupBox;
      System.Windows.Forms.GroupBox menuGroupBox;
      System.Windows.Forms.Label displayCountLabel;
      System.Windows.Forms.GroupBox checkSettingsGroupBox;
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label unstableIntervalLabel;
      System.Windows.Forms.Label intervalHelpLabel;
      System.Windows.Forms.Label intervalLabel;
      this.showNotificationsCheckBox = new System.Windows.Forms.CheckBox();
      this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
      this.offlineOnlyCheckBox = new System.Windows.Forms.CheckBox();
      this.showMenuItemsCheckBox = new System.Windows.Forms.CheckBox();
      this.displayCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.unstableIntervalTimeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
      this.intervalTimeSpanPicker = new System.Windows.Forms.TimeSpanPicker();
      notificationsGroupBox = new System.Windows.Forms.GroupBox();
      startupGroupBox = new System.Windows.Forms.GroupBox();
      menuGroupBox = new System.Windows.Forms.GroupBox();
      displayCountLabel = new System.Windows.Forms.Label();
      checkSettingsGroupBox = new System.Windows.Forms.GroupBox();
      label1 = new System.Windows.Forms.Label();
      unstableIntervalLabel = new System.Windows.Forms.Label();
      intervalHelpLabel = new System.Windows.Forms.Label();
      intervalLabel = new System.Windows.Forms.Label();
      notificationsGroupBox.SuspendLayout();
      startupGroupBox.SuspendLayout();
      menuGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.displayCountNumericUpDown)).BeginInit();
      checkSettingsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // notificationsGroupBox
      // 
      notificationsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      notificationsGroupBox.Controls.Add(this.showNotificationsCheckBox);
      notificationsGroupBox.Location = new System.Drawing.Point(0, 230);
      notificationsGroupBox.Name = "notificationsGroupBox";
      notificationsGroupBox.Size = new System.Drawing.Size(932, 53);
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
      // startupGroupBox
      // 
      startupGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      startupGroupBox.Controls.Add(this.startWithWindowsCheckBox);
      startupGroupBox.Location = new System.Drawing.Point(0, 289);
      startupGroupBox.Name = "startupGroupBox";
      startupGroupBox.Size = new System.Drawing.Size(932, 53);
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
      // menuGroupBox
      // 
      menuGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      menuGroupBox.Controls.Add(this.offlineOnlyCheckBox);
      menuGroupBox.Controls.Add(this.showMenuItemsCheckBox);
      menuGroupBox.Controls.Add(this.displayCountNumericUpDown);
      menuGroupBox.Controls.Add(displayCountLabel);
      menuGroupBox.Location = new System.Drawing.Point(0, 126);
      menuGroupBox.Name = "menuGroupBox";
      menuGroupBox.Size = new System.Drawing.Size(932, 98);
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
      checkSettingsGroupBox.Location = new System.Drawing.Point(0, 0);
      checkSettingsGroupBox.Name = "checkSettingsGroupBox";
      checkSettingsGroupBox.Size = new System.Drawing.Size(932, 120);
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
      // intervalLabel
      // 
      intervalLabel.AutoSize = true;
      intervalLabel.Location = new System.Drawing.Point(3, 22);
      intervalLabel.Name = "intervalLabel";
      intervalLabel.Size = new System.Drawing.Size(78, 13);
      intervalLabel.TabIndex = 0;
      intervalLabel.Text = "Check &interval:";
      // 
      // intervalTimeSpanPicker
      // 
      this.intervalTimeSpanPicker.Location = new System.Drawing.Point(98, 19);
      this.intervalTimeSpanPicker.Name = "intervalTimeSpanPicker";
      this.intervalTimeSpanPicker.Size = new System.Drawing.Size(235, 21);
      this.intervalTimeSpanPicker.TabIndex = 1;
      // 
      // SettingsPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(notificationsGroupBox);
      this.Controls.Add(startupGroupBox);
      this.Controls.Add(menuGroupBox);
      this.Controls.Add(checkSettingsGroupBox);
      this.Name = "SettingsPanel";
      this.Size = new System.Drawing.Size(932, 644);
      notificationsGroupBox.ResumeLayout(false);
      notificationsGroupBox.PerformLayout();
      startupGroupBox.ResumeLayout(false);
      startupGroupBox.PerformLayout();
      menuGroupBox.ResumeLayout(false);
      menuGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.displayCountNumericUpDown)).EndInit();
      checkSettingsGroupBox.ResumeLayout(false);
      checkSettingsGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckBox showNotificationsCheckBox;
    private System.Windows.Forms.CheckBox startWithWindowsCheckBox;
    private System.Windows.Forms.CheckBox offlineOnlyCheckBox;
    private System.Windows.Forms.CheckBox showMenuItemsCheckBox;
    private System.Windows.Forms.NumericUpDown displayCountNumericUpDown;
    private System.Windows.Forms.TimeSpanPicker unstableIntervalTimeSpanPicker;
    private System.Windows.Forms.TimeSpanPicker intervalTimeSpanPicker;
  }
}
