namespace biometrico
{
  partial class OptionForm
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
        this.groupBoxCaptOptions = new System.Windows.Forms.GroupBox();
        this.tableLayoutPanelCapturingOptions = new System.Windows.Forms.TableLayoutPanel();
        this.label5 = new System.Windows.Forms.Label();
        this.checkBoxAutoStepping = new System.Windows.Forms.CheckBox();
        this.checkBoxShowQuality = new System.Windows.Forms.CheckBox();
        this.label1 = new System.Windows.Forms.Label();
        this.tableLayoutPanelQualityThreshold = new System.Windows.Forms.TableLayoutPanel();
        this.numericUpDownNQPoor = new System.Windows.Forms.NumericUpDown();
        this.numericUpDownNQGood = new System.Windows.Forms.NumericUpDown();
        this.checkBoxFakeDetection = new System.Windows.Forms.CheckBox();
        this.numericUpDownFakeThreshold = new System.Windows.Forms.NumericUpDown();
        this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
        this.buttonOptionOk = new System.Windows.Forms.Button();
        this.buttonOptionCancel = new System.Windows.Forms.Button();
        this.checkBoxAutoCaptureBeep = new System.Windows.Forms.CheckBox();
        this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        this.groupBoxCaptOptions.SuspendLayout();
        this.tableLayoutPanelCapturingOptions.SuspendLayout();
        this.tableLayoutPanelQualityThreshold.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNQPoor)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNQGood)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFakeThreshold)).BeginInit();
        this.flowLayoutPanelButtons.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBoxCaptOptions
        // 
        this.groupBoxCaptOptions.Controls.Add(this.tableLayoutPanelCapturingOptions);
        this.groupBoxCaptOptions.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBoxCaptOptions.ForeColor = System.Drawing.Color.Navy;
        this.groupBoxCaptOptions.Location = new System.Drawing.Point(0, 0);
        this.groupBoxCaptOptions.Name = "groupBoxCaptOptions";
        this.groupBoxCaptOptions.Size = new System.Drawing.Size(422, 197);
        this.groupBoxCaptOptions.TabIndex = 6;
        this.groupBoxCaptOptions.TabStop = false;
        this.groupBoxCaptOptions.Text = "Capturing Options";
        // 
        // tableLayoutPanelCapturingOptions
        // 
        this.tableLayoutPanelCapturingOptions.ColumnCount = 3;
        this.tableLayoutPanelCapturingOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.43935F));
        this.tableLayoutPanelCapturingOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.56065F));
        this.tableLayoutPanelCapturingOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.label5, 1, 3);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.checkBoxAutoStepping, 0, 0);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.checkBoxShowQuality, 1, 0);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.label1, 0, 1);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.tableLayoutPanelQualityThreshold, 1, 1);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.checkBoxFakeDetection, 0, 3);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.numericUpDownFakeThreshold, 2, 3);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.flowLayoutPanelButtons, 1, 4);
        this.tableLayoutPanelCapturingOptions.Controls.Add(this.checkBoxAutoCaptureBeep, 0, 4);
        this.tableLayoutPanelCapturingOptions.Location = new System.Drawing.Point(3, 16);
        this.tableLayoutPanelCapturingOptions.Margin = new System.Windows.Forms.Padding(10);
        this.tableLayoutPanelCapturingOptions.Name = "tableLayoutPanelCapturingOptions";
        this.tableLayoutPanelCapturingOptions.RowCount = 5;
        this.tableLayoutPanelCapturingOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanelCapturingOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanelCapturingOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanelCapturingOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanelCapturingOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
        this.tableLayoutPanelCapturingOptions.Size = new System.Drawing.Size(417, 174);
        this.tableLayoutPanelCapturingOptions.TabIndex = 3;
        // 
        // label5
        // 
        this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(150, 58);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(157, 13);
        this.label5.TabIndex = 12;
        this.label5.Text = "Fake Detection Threshold:";
        // 
        // checkBoxAutoStepping
        // 
        this.checkBoxAutoStepping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.checkBoxAutoStepping.AutoSize = true;
        this.checkBoxAutoStepping.Enabled = false;
        this.checkBoxAutoStepping.Location = new System.Drawing.Point(3, 3);
        this.checkBoxAutoStepping.Name = "checkBoxAutoStepping";
        this.checkBoxAutoStepping.Size = new System.Drawing.Size(141, 17);
        this.checkBoxAutoStepping.TabIndex = 0;
        this.checkBoxAutoStepping.Text = "Auto Stepping";
        this.checkBoxAutoStepping.UseVisualStyleBackColor = true;
        // 
        // checkBoxShowQuality
        // 
        this.checkBoxShowQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.checkBoxShowQuality.AutoSize = true;
        this.tableLayoutPanelCapturingOptions.SetColumnSpan(this.checkBoxShowQuality, 2);
        this.checkBoxShowQuality.Enabled = false;
        this.checkBoxShowQuality.Location = new System.Drawing.Point(150, 3);
        this.checkBoxShowQuality.Name = "checkBoxShowQuality";
        this.checkBoxShowQuality.Size = new System.Drawing.Size(264, 17);
        this.checkBoxShowQuality.TabIndex = 1;
        this.checkBoxShowQuality.Text = "Show Quality";
        this.checkBoxShowQuality.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(3, 24);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(141, 26);
        this.label1.TabIndex = 5;
        this.label1.Text = "NFIQ2 Threshold: Good - Poor";
        // 
        // tableLayoutPanelQualityThreshold
        // 
        this.tableLayoutPanelQualityThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanelQualityThreshold.ColumnCount = 5;
        this.tableLayoutPanelCapturingOptions.SetColumnSpan(this.tableLayoutPanelQualityThreshold, 2);
        this.tableLayoutPanelQualityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
        this.tableLayoutPanelQualityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        this.tableLayoutPanelQualityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
        this.tableLayoutPanelQualityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        this.tableLayoutPanelQualityThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        this.tableLayoutPanelQualityThreshold.Controls.Add(this.numericUpDownNQPoor, 4, 0);
        this.tableLayoutPanelQualityThreshold.Controls.Add(this.numericUpDownNQGood, 0, 0);
        this.tableLayoutPanelQualityThreshold.Location = new System.Drawing.Point(150, 26);
        this.tableLayoutPanelQualityThreshold.Name = "tableLayoutPanelQualityThreshold";
        this.tableLayoutPanelQualityThreshold.RowCount = 1;
        this.tableLayoutPanelQualityThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelQualityThreshold.Size = new System.Drawing.Size(264, 23);
        this.tableLayoutPanelQualityThreshold.TabIndex = 6;
        // 
        // numericUpDownNQPoor
        // 
        this.numericUpDownNQPoor.Dock = System.Windows.Forms.DockStyle.Fill;
        this.numericUpDownNQPoor.Enabled = false;
        this.numericUpDownNQPoor.Location = new System.Drawing.Point(178, 3);
        this.numericUpDownNQPoor.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
        this.numericUpDownNQPoor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDownNQPoor.Name = "numericUpDownNQPoor";
        this.numericUpDownNQPoor.Size = new System.Drawing.Size(83, 20);
        this.numericUpDownNQPoor.TabIndex = 5;
        this.numericUpDownNQPoor.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
        // 
        // numericUpDownNQGood
        // 
        this.numericUpDownNQGood.Dock = System.Windows.Forms.DockStyle.Fill;
        this.numericUpDownNQGood.Enabled = false;
        this.numericUpDownNQGood.Location = new System.Drawing.Point(3, 3);
        this.numericUpDownNQGood.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDownNQGood.Name = "numericUpDownNQGood";
        this.numericUpDownNQGood.Size = new System.Drawing.Size(81, 20);
        this.numericUpDownNQGood.TabIndex = 7;
        this.numericUpDownNQGood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // checkBoxFakeDetection
        // 
        this.checkBoxFakeDetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        this.checkBoxFakeDetection.AutoSize = true;
        this.checkBoxFakeDetection.Enabled = false;
        this.checkBoxFakeDetection.Location = new System.Drawing.Point(3, 56);
        this.checkBoxFakeDetection.Name = "checkBoxFakeDetection";
        this.checkBoxFakeDetection.Size = new System.Drawing.Size(141, 17);
        this.checkBoxFakeDetection.TabIndex = 9;
        this.checkBoxFakeDetection.Text = "Fake Detection Enable";
        this.checkBoxFakeDetection.UseVisualStyleBackColor = true;
        // 
        // numericUpDownFakeThreshold
        // 
        this.numericUpDownFakeThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.numericUpDownFakeThreshold.Enabled = false;
        this.numericUpDownFakeThreshold.Location = new System.Drawing.Point(313, 55);
        this.numericUpDownFakeThreshold.Name = "numericUpDownFakeThreshold";
        this.numericUpDownFakeThreshold.Size = new System.Drawing.Size(50, 20);
        this.numericUpDownFakeThreshold.TabIndex = 11;
        this.numericUpDownFakeThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // flowLayoutPanelButtons
        // 
        this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanelCapturingOptions.SetColumnSpan(this.flowLayoutPanelButtons, 2);
        this.flowLayoutPanelButtons.Controls.Add(this.buttonOptionOk);
        this.flowLayoutPanelButtons.Controls.Add(this.buttonOptionCancel);
        this.flowLayoutPanelButtons.Location = new System.Drawing.Point(246, 139);
        this.flowLayoutPanelButtons.MinimumSize = new System.Drawing.Size(168, 31);
        this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
        this.flowLayoutPanelButtons.Size = new System.Drawing.Size(168, 32);
        this.flowLayoutPanelButtons.TabIndex = 4;
        // 
        // buttonOptionOk
        // 
        this.buttonOptionOk.Enabled = false;
        this.buttonOptionOk.ForeColor = System.Drawing.Color.SlateGray;
        this.buttonOptionOk.Location = new System.Drawing.Point(3, 3);
        this.buttonOptionOk.Name = "buttonOptionOk";
        this.buttonOptionOk.Size = new System.Drawing.Size(75, 23);
        this.buttonOptionOk.TabIndex = 0;
        this.buttonOptionOk.Text = "OK";
        this.buttonOptionOk.UseVisualStyleBackColor = true;
        this.buttonOptionOk.Click += new System.EventHandler(this.buttonOptionOk_Click);
        // 
        // buttonOptionCancel
        // 
        this.buttonOptionCancel.Location = new System.Drawing.Point(84, 3);
        this.buttonOptionCancel.Name = "buttonOptionCancel";
        this.buttonOptionCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonOptionCancel.TabIndex = 1;
        this.buttonOptionCancel.Text = "Cancel";
        this.buttonOptionCancel.UseVisualStyleBackColor = true;
        this.buttonOptionCancel.Click += new System.EventHandler(this.buttonOptionCancel_Click);
        // 
        // checkBoxAutoCaptureBeep
        // 
        this.checkBoxAutoCaptureBeep.AutoSize = true;
        this.checkBoxAutoCaptureBeep.Enabled = false;
        this.checkBoxAutoCaptureBeep.Location = new System.Drawing.Point(3, 81);
        this.checkBoxAutoCaptureBeep.Name = "checkBoxAutoCaptureBeep";
        this.checkBoxAutoCaptureBeep.Size = new System.Drawing.Size(114, 17);
        this.checkBoxAutoCaptureBeep.TabIndex = 13;
        this.checkBoxAutoCaptureBeep.Text = "Auto capture beep";
        this.checkBoxAutoCaptureBeep.UseVisualStyleBackColor = true;
        // 
        // OptionForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(422, 197);
        this.Controls.Add(this.groupBoxCaptOptions);
        this.ForeColor = System.Drawing.Color.Navy;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Name = "OptionForm";
        this.Text = "Configuracion";
        this.Load += new System.EventHandler(this.OptionForm_Load);
        this.groupBoxCaptOptions.ResumeLayout(false);
        this.tableLayoutPanelCapturingOptions.ResumeLayout(false);
        this.tableLayoutPanelCapturingOptions.PerformLayout();
        this.tableLayoutPanelQualityThreshold.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNQPoor)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNQGood)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFakeThreshold)).EndInit();
        this.flowLayoutPanelButtons.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxCaptOptions;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCapturingOptions;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.CheckBox checkBoxAutoStepping;
    private System.Windows.Forms.CheckBox checkBoxShowQuality;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelQualityThreshold;
    private System.Windows.Forms.NumericUpDown numericUpDownNQPoor;    
    private System.Windows.Forms.NumericUpDown numericUpDownNQGood;
    private System.Windows.Forms.CheckBox checkBoxFakeDetection;
    private System.Windows.Forms.NumericUpDown numericUpDownFakeThreshold;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
    private System.Windows.Forms.Button buttonOptionOk;
    private System.Windows.Forms.Button buttonOptionCancel;
    private System.Windows.Forms.CheckBox checkBoxAutoCaptureBeep;
  }
}