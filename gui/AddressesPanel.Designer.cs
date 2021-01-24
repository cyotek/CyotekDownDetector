
namespace Cyotek.DownDetector.Client
{
  partial class AddressesPanel
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
      this.uriInfoCollectionEditor = new Cyotek.DownDetector.Client.UriInfoCollectionEditor();
      this.SuspendLayout();
      // 
      // uriInfoCollectionEditor
      // 
      this.uriInfoCollectionEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uriInfoCollectionEditor.Location = new System.Drawing.Point(0, 0);
      this.uriInfoCollectionEditor.Name = "uriInfoCollectionEditor";
      this.uriInfoCollectionEditor.Size = new System.Drawing.Size(772, 496);
      this.uriInfoCollectionEditor.TabIndex = 0;
      // 
      // AddressesPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.uriInfoCollectionEditor);
      this.Name = "AddressesPanel";
      this.Size = new System.Drawing.Size(772, 496);
      this.ResumeLayout(false);

    }

    #endregion

    private UriInfoCollectionEditor uriInfoCollectionEditor;
  }
}
