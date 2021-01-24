
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
      this.tabList = new Cyotek.Windows.Forms.TabList();
      this.addressTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.settingsTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.logTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.aboutTabListPage = new Cyotek.Windows.Forms.TabListPage();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.tabList.SuspendLayout();
      this.SuspendLayout();
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
      this.addressTabListPage.Name = "addressTabListPage";
      this.addressTabListPage.Size = new System.Drawing.Size(602, 506);
      this.addressTabListPage.Text = "Addresses";
      // 
      // settingsTabListPage
      // 
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
      this.tabList.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Cyotek.Windows.Forms.TabList tabList;
    private Cyotek.Windows.Forms.TabListPage addressTabListPage;
    private Cyotek.Windows.Forms.TabListPage settingsTabListPage;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private Windows.Forms.TabListPage aboutTabListPage;
    private Windows.Forms.TabListPage logTabListPage;
  }
}