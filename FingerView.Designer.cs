namespace biometrico
{
  partial class FingerView
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingerView));
        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
        this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
        this.pictureBox1 = new biometrico.PictureBoxDoubleBuffered();
        this.flowLayoutPanel1.SuspendLayout();
        this.toolStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.AutoScroll = true;
        this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
        this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
        this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 39);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new System.Drawing.Size(395, 388);
        this.flowLayoutPanel1.TabIndex = 2;
        // 
        // toolStrip1
        // 
        this.toolStrip1.BackColor = System.Drawing.Color.White;
        this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonZoomIn,
            this.toolStripButton2});
        this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(395, 39);
        this.toolStrip1.TabIndex = 2;
        this.toolStrip1.Text = "toolStrip1";
        // 
        // toolStripButtonZoomIn
        // 
        this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomIn.Image")));
        this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
        this.toolStripButtonZoomIn.Size = new System.Drawing.Size(36, 36);
        this.toolStripButtonZoomIn.Text = "toolStripButton1";
        this.toolStripButtonZoomIn.Click += new System.EventHandler(this.zoomINToolStripMenuItem_Click);
        // 
        // toolStripButton2
        // 
        this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
        this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
        this.toolStripButton2.Name = "toolStripButton2";
        this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
        this.toolStripButton2.Text = "toolStripButton2";
        this.toolStripButton2.Click += new System.EventHandler(this.zoomOUTToolStripMenuItem_Click);
        // 
        // pictureBox1
        // 
        this.pictureBox1.BackColor = System.Drawing.Color.White;
        this.pictureBox1.Location = new System.Drawing.Point(3, 3);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(238, 175);
        this.pictureBox1.TabIndex = 1;
        this.pictureBox1.TabStop = false;
        // 
        // FingerView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(395, 427);
        this.Controls.Add(this.flowLayoutPanel1);
        this.Controls.Add(this.toolStrip1);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "FingerView";
        this.Text = "Finger View";
        this.Resize += new System.EventHandler(this.FingerView_Resize);
        this.flowLayoutPanel1.ResumeLayout(false);
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private PictureBoxDoubleBuffered pictureBox1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
    private System.Windows.Forms.ToolStripButton toolStripButton2;
  }
}