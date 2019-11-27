using System;
using System.Drawing;
using System.Windows.Forms;

namespace biometrico
{
  /// <summary>
  /// Simple finger view form.
  /// </summary>
  public partial class FingerView : Form
  {
    #region Fields
    private Image sourceImage;
    private string fingerPosition;
    private int currentZoom = 1; 
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="FingerView"/> class.
    /// </summary>
    public FingerView()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="FingerView"/> class.
    /// </summary>
    /// <param name="fingerImage">The finger image.</param>
    /// <param name="positon">The positon.</param>
    public FingerView(Image fingerImage, string positon)
    {
      InitializeComponent();
      this.sourceImage = fingerImage;
      this.fingerPosition = positon;
      Init();
    } 
    #endregion

    /// <summary>
    /// Inits this instance.
    /// </summary>
    private void Init()
    {
      if (sourceImage != null)
      {
        this.Text = this.fingerPosition;
        if(sourceImage.Size.Width>=1000 || sourceImage.Height >=1000) 
            this.Size = new Size(sourceImage.Size.Width/2 + 30, sourceImage.Height/2 + 90);
        else{
            this.Size = new Size(sourceImage.Size.Width + 30, sourceImage.Height + 90);
        }

        this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        this.pictureBox1.Image = sourceImage;
        this.pictureBox1.Dock = DockStyle.None;
        this.pictureBox1.BackColor = flowLayoutPanel1.BackColor;
        if (sourceImage.Size.Width >= 1000 || sourceImage.Height >= 1000)
            this.pictureBox1.Size = new Size(sourceImage.Width/2, sourceImage.Height/2);
        else
        {
            this.pictureBox1.Size = new Size(sourceImage.Width, sourceImage.Height);
        }
        

        flowLayoutPanel1.Dock = DockStyle.Fill;
        flowLayoutPanel1.AutoScroll = true;
        flowLayoutPanel1.Controls.Add(pictureBox1);
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      }
    }

    #region Events
    /// <summary>
    /// Handles the Click event of the zoomINToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void zoomINToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SuspendLayout();
      if (currentZoom < 3)
      {
        currentZoom++;
        this.pictureBox1.Size = new Size(this.pictureBox1.Width * currentZoom, pictureBox1.Height * currentZoom);
        //middle of scrollbar - half of scrollbutton lenght.
        int horizPos = (flowLayoutPanel1.HorizontalScroll.Maximum / 2)-(flowLayoutPanel1.HorizontalScroll.LargeChange/2);
        int vertPos = (flowLayoutPanel1.VerticalScroll.Maximum / 2) - (flowLayoutPanel1.VerticalScroll.LargeChange / 2);
        flowLayoutPanel1.AutoScrollPosition = new Point(horizPos, vertPos); 
      }
      this.ResumeLayout();
    }
    /// <summary>
    /// Handles the Click event of the zoomOUTToolStripMenuItem control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void zoomOUTToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SuspendLayout();
      this.pictureBox1.Size = new Size(this.pictureBox1.Width / currentZoom, pictureBox1.Height / currentZoom);

      if (pictureBox1.Width < this.Width || pictureBox1.Height < this.Height)
      {
        this.pictureBox1.Size = new Size(this.Width - 30, this.Height - 90);
        //middle of scrollbar - half of scrollbutton lenght. 
      }
      int horizPos = (flowLayoutPanel1.HorizontalScroll.Maximum / 2) - (flowLayoutPanel1.HorizontalScroll.LargeChange / 2);
      int vertPos = (flowLayoutPanel1.VerticalScroll.Maximum / 2) - (flowLayoutPanel1.VerticalScroll.LargeChange / 2);
      flowLayoutPanel1.AutoScrollPosition = new Point(horizPos, vertPos);

      if (currentZoom > 1)
        currentZoom--;
      this.ResumeLayout();
    }
    /// <summary>
    /// Handles the Resize event of the FingerView control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void FingerView_Resize(object sender, EventArgs e)
    {
      if ((this.Width > pictureBox1.Width || this.Height > pictureBox1.Height) || currentZoom == 1)
        this.pictureBox1.Size = new Size(this.Width - 30, this.Height - 90);
    } 
    #endregion
  }
}
