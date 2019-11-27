using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LF10Demo
{
  /// <summary>
  /// Simple Form for visualisation of finger segmenation results.
  /// </summary>
  public partial class ResultsView : Form
  {
    private Dictionary<string, LF10ResultItem> lf10Results;
    /// <summary>
    /// Gets or sets the LF10 results.
    /// </summary>
    /// <value>The LF10 results.</value>
    public Dictionary<string, LF10ResultItem> Lf10Results
    {
      get { return lf10Results; }
      set 
      { 
        lf10Results = value;
        this.ShowResults(value);
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResultsView"/> class.
    /// </summary>
    public ResultsView()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Shows the results.
    /// </summary>
    /// <param name="value">The value.</param>
    private void ShowResults(Dictionary<string, LF10ResultItem> value)
    {
      foreach (KeyValuePair<string, LF10ResultItem> resItem in this.Lf10Results)
      {
        foreach (Control ctrl in this.tableLayoutPanelMain.Controls)
        {
          if (ctrl is PictureBox)
          {
            if ((ctrl.Tag as string).Equals(resItem.Key))
            {
              (ctrl as PictureBox).Image = resItem.Value.Image;
            }
          }
        }
      }
    }
    /// <summary>
    /// Handles the Click event of the pictureBox control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void pictureBox_Click(object sender, EventArgs e)
    {
     
      PictureBox picB = sender as PictureBox;
      if (picB.Image != null)
      {
        FingerView fingerView = new FingerView(picB.Image, picB.Tag.ToString());
        fingerView.StartPosition = FormStartPosition.CenterParent;
        fingerView.ShowDialog(this);
      }
    }

  }
}
