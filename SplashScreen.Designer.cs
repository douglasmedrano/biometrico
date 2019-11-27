namespace LF10Demo
{
  partial class SplashScreen
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
        this.label1 = new System.Windows.Forms.Label();
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.progressBar1 = new System.Windows.Forms.ProgressBar();
        this.tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Dock = System.Windows.Forms.DockStyle.Top;
        this.label1.Location = new System.Drawing.Point(3, 238);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(526, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Loading...";
        this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 1);
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 3;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(532, 256);
        this.tableLayoutPanel1.TabIndex = 1;
        // 
        // pictureBox1
        // 
        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        this.pictureBox1.Location = new System.Drawing.Point(3, 3);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(526, 208);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox1.TabIndex = 1;
        this.pictureBox1.TabStop = false;
        // 
        // progressBar1
        // 
        this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
        this.progressBar1.Location = new System.Drawing.Point(3, 217);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new System.Drawing.Size(526, 18);
        this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.progressBar1.TabIndex = 2;
        // 
        // SplashScreen
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.ClientSize = new System.Drawing.Size(532, 256);
        this.ControlBox = false;
        this.Controls.Add(this.tableLayoutPanel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "SplashScreen";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = "LF10 Sample Application";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ProgressBar progressBar1;

  }
}