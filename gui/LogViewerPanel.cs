using Cyotek.Demo.Windows.Forms;
using System;
using System.IO;
using System.Text;
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
  public partial class LogViewerPanel : UserControl
  {
    #region Private Fields

    private string _fileName;

    #endregion Private Fields

    #region Public Constructors

    public LogViewerPanel()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      // TODO: Pass filename from application
      _fileName = Path.ChangeExtension(Application.ExecutablePath, ".log"); ;

      this.LoadLog();
    }

    #endregion Protected Methods

    #region Private Methods

    private void LoadLog()
    {
      int count;
      int maximum;
      //List<string> lines;
      StringBuilder lines;

      count = 0;
      maximum = (int)linesNumericUpDown.Value;
      //lines = new List<string>(maximum);
      lines = new StringBuilder();

      if (File.Exists(_fileName))
      {
        ReverseLineReader reader;

        reader = new ReverseLineReader(_fileName);

        foreach (string line in reader)
        {
          //lines.Insert(0, line);
          lines.AppendLine(line);

          if (count++ > maximum /*lines.Count == maximum*/)
          {
            break;
          }
        }
      }

      //richTextBox.Text = string.Join(Environment.NewLine, lines);
      richTextBox.Text = lines.ToString();
    }

    private void RefreshButton_Click(object sender, EventArgs e)
    {
      refreshTimer.Stop();
      refreshTimer.Start();
    }

    private void RefreshTimer_Tick(object sender, EventArgs e)
    {
      refreshTimer.Stop();

      this.LoadLog();
    }

    private void RichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      AboutPanel.OpenUrl(e.LinkText);
    }

    #endregion Private Methods
  }
}