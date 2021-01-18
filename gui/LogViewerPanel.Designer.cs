
namespace Cyotek.DownDetector.Client
{
  partial class LogViewerPanel
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
      System.Windows.Forms.GroupBox logGroupBox;
      System.Windows.Forms.GroupBox logTailGroupBox;
      this.linesNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.refreshButton = new System.Windows.Forms.Button();
      this.refreshTimer = new System.Windows.Forms.Timer(this.components);
      this.richTextBox = new System.Windows.Forms.RichTextBox();
      logGroupBox = new System.Windows.Forms.GroupBox();
      logTailGroupBox = new System.Windows.Forms.GroupBox();
      logGroupBox.SuspendLayout();
      logTailGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.linesNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // logGroupBox
      // 
      logGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      logGroupBox.Controls.Add(this.refreshButton);
      logGroupBox.Controls.Add(this.label1);
      logGroupBox.Controls.Add(this.linesNumericUpDown);
      logGroupBox.Location = new System.Drawing.Point(0, 0);
      logGroupBox.Name = "logGroupBox";
      logGroupBox.Size = new System.Drawing.Size(790, 53);
      logGroupBox.TabIndex = 0;
      logGroupBox.TabStop = false;
      logGroupBox.Text = "Log";
      // 
      // logTailGroupBox
      // 
      logTailGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      logTailGroupBox.Controls.Add(this.richTextBox);
      logTailGroupBox.Location = new System.Drawing.Point(0, 59);
      logTailGroupBox.Name = "logTailGroupBox";
      logTailGroupBox.Size = new System.Drawing.Size(790, 257);
      logTailGroupBox.TabIndex = 1;
      logTailGroupBox.TabStop = false;
      logTailGroupBox.Text = "Log Tail";
      // 
      // linesNumericUpDown
      // 
      this.linesNumericUpDown.Location = new System.Drawing.Point(87, 19);
      this.linesNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.linesNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.linesNumericUpDown.Name = "linesNumericUpDown";
      this.linesNumericUpDown.Size = new System.Drawing.Size(81, 20);
      this.linesNumericUpDown.TabIndex = 1;
      this.linesNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.linesNumericUpDown.ValueChanged += new System.EventHandler(this.RefreshButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Lines to show:";
      // 
      // refreshButton
      // 
      this.refreshButton.Location = new System.Drawing.Point(174, 16);
      this.refreshButton.Name = "refreshButton";
      this.refreshButton.Size = new System.Drawing.Size(75, 23);
      this.refreshButton.TabIndex = 2;
      this.refreshButton.Text = "&Refresh";
      this.refreshButton.UseVisualStyleBackColor = true;
      this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
      // 
      // refreshTimer
      // 
      this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
      // 
      // richTextBox
      // 
      this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBox.BackColor = System.Drawing.SystemColors.Window;
      this.richTextBox.Location = new System.Drawing.Point(6, 19);
      this.richTextBox.Name = "richTextBox";
      this.richTextBox.ReadOnly = true;
      this.richTextBox.Size = new System.Drawing.Size(778, 232);
      this.richTextBox.TabIndex = 0;
      this.richTextBox.Text = "";
      this.richTextBox.WordWrap = false;
      this.richTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);
      // 
      // LogViewerPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(logGroupBox);
      this.Controls.Add(logTailGroupBox);
      this.Name = "LogViewerPanel";
      this.Size = new System.Drawing.Size(790, 319);
      logGroupBox.ResumeLayout(false);
      logGroupBox.PerformLayout();
      logTailGroupBox.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.linesNumericUpDown)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button refreshButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown linesNumericUpDown;
    private System.Windows.Forms.Timer refreshTimer;
    private System.Windows.Forms.RichTextBox richTextBox;
  }
}
