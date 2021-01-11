
namespace Cyotek.Demo.Windows.Forms
{
  partial class AboutPanel
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
      this.infoLinkLabel = new System.Windows.Forms.LinkLabel();
      this.versionLabel = new System.Windows.Forms.Label();
      this.iconPictureBox = new System.Windows.Forms.PictureBox();
      this.webLinkLabel = new System.Windows.Forms.LinkLabel();
      this.copyrightLabel = new System.Windows.Forms.Label();
      this.nameLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
      this.SuspendLayout();
      // 
      // infoLinkLabel
      // 
      this.infoLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.infoLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.infoLinkLabel.Location = new System.Drawing.Point(41, 66);
      this.infoLinkLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
      this.infoLinkLabel.Name = "infoLinkLabel";
      this.infoLinkLabel.Size = new System.Drawing.Size(439, 229);
      this.infoLinkLabel.TabIndex = 10;
      this.infoLinkLabel.UseMnemonic = false;
      this.infoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InfoLinkLabel_LinkClicked);
      // 
      // versionLabel
      // 
      this.versionLabel.AutoSize = true;
      this.versionLabel.Location = new System.Drawing.Point(38, 13);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(42, 13);
      this.versionLabel.TabIndex = 8;
      this.versionLabel.Text = "Version";
      // 
      // iconPictureBox
      // 
      this.iconPictureBox.Location = new System.Drawing.Point(0, 0);
      this.iconPictureBox.Name = "iconPictureBox";
      this.iconPictureBox.Size = new System.Drawing.Size(32, 32);
      this.iconPictureBox.TabIndex = 11;
      this.iconPictureBox.TabStop = false;
      // 
      // webLinkLabel
      // 
      this.webLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.webLinkLabel.AutoSize = true;
      this.webLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.webLinkLabel.Location = new System.Drawing.Point(38, 307);
      this.webLinkLabel.Name = "webLinkLabel";
      this.webLinkLabel.Size = new System.Drawing.Size(89, 13);
      this.webLinkLabel.TabIndex = 12;
      this.webLinkLabel.TabStop = true;
      this.webLinkLabel.Text = "www.cyotek.com";
      this.webLinkLabel.Click += new System.EventHandler(this.WebLinkLabel_LinkClicked);
      // 
      // copyrightLabel
      // 
      this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.copyrightLabel.Location = new System.Drawing.Point(38, 32);
      this.copyrightLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
      this.copyrightLabel.Name = "copyrightLabel";
      this.copyrightLabel.Size = new System.Drawing.Size(442, 34);
      this.copyrightLabel.TabIndex = 9;
      this.copyrightLabel.Text = "Copyright";
      // 
      // nameLabel
      // 
      this.nameLabel.AutoSize = true;
      this.nameLabel.Location = new System.Drawing.Point(38, 0);
      this.nameLabel.Name = "nameLabel";
      this.nameLabel.Size = new System.Drawing.Size(27, 13);
      this.nameLabel.TabIndex = 7;
      this.nameLabel.Text = "Title";
      // 
      // AboutPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.infoLinkLabel);
      this.Controls.Add(this.versionLabel);
      this.Controls.Add(this.iconPictureBox);
      this.Controls.Add(this.webLinkLabel);
      this.Controls.Add(this.copyrightLabel);
      this.Controls.Add(this.nameLabel);
      this.Name = "AboutPanel";
      this.Size = new System.Drawing.Size(480, 320);
      ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.LinkLabel infoLinkLabel;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.PictureBox iconPictureBox;
    private System.Windows.Forms.LinkLabel webLinkLabel;
    private System.Windows.Forms.Label copyrightLabel;
    private System.Windows.Forms.Label nameLabel;
  }
}
