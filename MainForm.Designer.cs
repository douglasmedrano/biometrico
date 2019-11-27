﻿namespace biometrico
{
  partial class MainForm
  {

    //LOCAL
    //public string path_fingerprint = "\\\\192.168.2.120\\utic\\PVT\\fingerprint";
    //public string path_picture = "\\\\192.168.2.120\\utic\\PVT\\picture";
    public string path_local = "";  //Get from data.xml "D:\\tst\\04"
    public string path_fingerprint = "\\\\192.168.2.120\\pvt\\fingerprint";
    public string path_picture = "\\\\192.168.2.120\\pvt\\picture";
    //REMOTE
    public string path_remote_user = "pvt";
    public string path_remote_password = "s4turn0";
    //USUSARIO
    public string affiliate_id = "12";
    public string affiliate_ci = "ci";
    public string affiliate_name = "name";
    //USER
    public string user_id = "";
   //HOST
    //public string host_ip = "http://192.168.2.99";
    public string host_ip = "";


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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
        this.tableLayoutPanelCurrenScan = new System.Windows.Forms.TableLayoutPanel();
        this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
        this.btnExit = new System.Windows.Forms.Button();
        this.btnStop = new System.Windows.Forms.Button();
        this.btnStart = new System.Windows.Forms.Button();
        this.btnOptions = new System.Windows.Forms.Button();
        this.flowLayoutPanelCuttedFingers = new System.Windows.Forms.FlowLayoutPanel();
        this.pictureBoxCurrentCapturing = new System.Windows.Forms.PictureBox();
        this.groupBoxExtended2 = new biometrico.GroupBoxExtended();
        this.tableLayoutPanelCurCapturing = new System.Windows.Forms.TableLayoutPanel();
        this.buttonSuccResults = new System.Windows.Forms.Button();
        this.buttonSuccSave = new System.Windows.Forms.Button();
        this.buttonPrevCapturing = new System.Windows.Forms.Button();
        this.buttonNextCapturing = new System.Windows.Forms.Button();
        this.labelHeaderState = new System.Windows.Forms.Label();
        this.picBoxCurLeftHand = new System.Windows.Forms.PictureBox();
        this.picBoxCurRightHand = new System.Windows.Forms.PictureBox();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.tableLayoutPanelDoubleBuffered1 = new biometrico.TableLayoutPanelDoubleBuffered();
        this.groupBoxExtended3 = new biometrico.GroupBoxExtended();
        this.tableLayoutPanelScore = new System.Windows.Forms.TableLayoutPanel();
        this.textBoxScore4 = new System.Windows.Forms.TextBox();
        this.textBoxScore3 = new System.Windows.Forms.TextBox();
        this.textBoxScore2 = new System.Windows.Forms.TextBox();
        this.textBoxScore1 = new System.Windows.Forms.TextBox();
        this.listViewMessages = new System.Windows.Forms.ListView();
        this.columnHeaderProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.groupBoxExtended1 = new biometrico.GroupBoxExtended();
        this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
        this.pictureBox442 = new System.Windows.Forms.PictureBox();
        this.radioButton442 = new System.Windows.Forms.RadioButton();
        this.radioButton424 = new System.Windows.Forms.RadioButton();
        this.radioButton1Flat = new System.Windows.Forms.RadioButton();
        this.imageListSeg = new System.Windows.Forms.ImageList(this.components);
        this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
        this.buttonClearResultMessages = new System.Windows.Forms.Button();
        this.tableLayoutPanelMainSkeleton = new System.Windows.Forms.TableLayoutPanel();
        this.pictureBox3 = new System.Windows.Forms.PictureBox();
        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        this.pictureBox2 = new System.Windows.Forms.PictureBox();
        this.Afiliado = new System.Windows.Forms.GroupBox();
        this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
        this.label3 = new System.Windows.Forms.Label();
        this.f_matricula = new System.Windows.Forms.TextBox();
        this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        this.label1 = new System.Windows.Forms.Label();
        this.f_afiliado = new System.Windows.Forms.TextBox();
        this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
        this.label2 = new System.Windows.Forms.Label();
        this.f_ci = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.tableLayoutPanelCaptSequence = new System.Windows.Forms.TableLayoutPanel();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.pictureBox442x10_bot = new System.Windows.Forms.PictureBox();
        this.pictureBox442x10_top = new System.Windows.Forms.PictureBox();
        this.tableLayoutPanelMain.SuspendLayout();
        this.tableLayoutPanelCurrenScan.SuspendLayout();
        this.tableLayoutPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentCapturing)).BeginInit();
        this.groupBoxExtended2.SuspendLayout();
        this.tableLayoutPanelCurCapturing.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picBoxCurLeftHand)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.picBoxCurRightHand)).BeginInit();
        this.tableLayoutPanelDoubleBuffered1.SuspendLayout();
        this.groupBoxExtended3.SuspendLayout();
        this.tableLayoutPanelScore.SuspendLayout();
        this.groupBoxExtended1.SuspendLayout();
        this.tableLayoutPanel4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox442)).BeginInit();
        this.tableLayoutPanel2.SuspendLayout();
        this.tableLayoutPanelMainSkeleton.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
        this.flowLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        this.Afiliado.SuspendLayout();
        this.flowLayoutPanel2.SuspendLayout();
        this.flowLayoutPanel6.SuspendLayout();
        this.flowLayoutPanel4.SuspendLayout();
        this.flowLayoutPanel5.SuspendLayout();
        this.tableLayoutPanelCaptSequence.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        this.tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox442x10_bot)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox442x10_top)).BeginInit();
        this.SuspendLayout();
        // 
        // tableLayoutPanelMain
        // 
        this.tableLayoutPanelMain.ColumnCount = 2;
        this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.53479F));
        this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.46521F));
        this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCurrenScan, 1, 0);
        this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelDoubleBuffered1, 0, 0);
        this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelMain.ForeColor = System.Drawing.Color.Black;
        this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 191);
        this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
        this.tableLayoutPanelMain.RowCount = 1;
        this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 457F));
        this.tableLayoutPanelMain.Size = new System.Drawing.Size(1021, 457);
        this.tableLayoutPanelMain.TabIndex = 2;
        // 
        // tableLayoutPanelCurrenScan
        // 
        this.tableLayoutPanelCurrenScan.ColumnCount = 2;
        this.tableLayoutPanelCurrenScan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.02976F));
        this.tableLayoutPanelCurrenScan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.97024F));
        this.tableLayoutPanelCurrenScan.Controls.Add(this.tableLayoutPanel3, 1, 1);
        this.tableLayoutPanelCurrenScan.Controls.Add(this.flowLayoutPanelCuttedFingers, 0, 1);
        this.tableLayoutPanelCurrenScan.Controls.Add(this.pictureBoxCurrentCapturing, 0, 0);
        this.tableLayoutPanelCurrenScan.Controls.Add(this.groupBoxExtended2, 1, 0);
        this.tableLayoutPanelCurrenScan.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelCurrenScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.tableLayoutPanelCurrenScan.Location = new System.Drawing.Point(284, 3);
        this.tableLayoutPanelCurrenScan.Name = "tableLayoutPanelCurrenScan";
        this.tableLayoutPanelCurrenScan.RowCount = 3;
        this.tableLayoutPanelCurrenScan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 280F));
        this.tableLayoutPanelCurrenScan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
        this.tableLayoutPanelCurrenScan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelCurrenScan.Size = new System.Drawing.Size(734, 451);
        this.tableLayoutPanelCurrenScan.TabIndex = 1;
        this.tableLayoutPanelCurrenScan.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelCurrenScan_Paint);
        // 
        // tableLayoutPanel3
        // 
        this.tableLayoutPanel3.ColumnCount = 2;
        this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.06367F));
        this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.93633F));
        this.tableLayoutPanel3.Controls.Add(this.btnExit, 0, 1);
        this.tableLayoutPanel3.Controls.Add(this.btnStop, 0, 0);
        this.tableLayoutPanel3.Controls.Add(this.btnStart, 0, 0);
        this.tableLayoutPanel3.Controls.Add(this.btnOptions, 1, 0);
        this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel3.Location = new System.Drawing.Point(480, 283);
        this.tableLayoutPanel3.Name = "tableLayoutPanel3";
        this.tableLayoutPanel3.RowCount = 2;
        this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel3.Size = new System.Drawing.Size(251, 110);
        this.tableLayoutPanel3.TabIndex = 8;
        // 
        // btnExit
        // 
        this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
        this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnExit.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnExit.ForeColor = System.Drawing.Color.Navy;
        this.btnExit.Location = new System.Drawing.Point(126, 58);
        this.btnExit.Name = "btnExit";
        this.btnExit.Size = new System.Drawing.Size(122, 49);
        this.btnExit.TabIndex = 4;
        this.btnExit.Text = "      Salir";
        this.btnExit.UseVisualStyleBackColor = true;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // btnStop
        // 
        this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
        this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnStop.Enabled = false;
        this.btnStop.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnStop.ForeColor = System.Drawing.Color.Navy;
        this.btnStop.Location = new System.Drawing.Point(126, 3);
        this.btnStop.Name = "btnStop";
        this.btnStop.Size = new System.Drawing.Size(122, 49);
        this.btnStop.TabIndex = 3;
        this.btnStop.Text = "      Parar";
        this.btnStop.UseVisualStyleBackColor = true;
        this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
        // 
        // btnStart
        // 
        this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
        this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnStart.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnStart.ForeColor = System.Drawing.Color.Navy;
        this.btnStart.Location = new System.Drawing.Point(3, 3);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(117, 49);
        this.btnStart.TabIndex = 1;
        this.btnStart.Text = "      Inicio";
        this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        this.btnStart.UseVisualStyleBackColor = true;
        this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
        // 
        // btnOptions
        // 
        this.btnOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOptions.BackgroundImage")));
        this.btnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.btnOptions.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnOptions.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.btnOptions.ForeColor = System.Drawing.Color.Navy;
        this.btnOptions.Location = new System.Drawing.Point(3, 58);
        this.btnOptions.Name = "btnOptions";
        this.btnOptions.Size = new System.Drawing.Size(117, 49);
        this.btnOptions.TabIndex = 2;
        this.btnOptions.Text = "      Config";
        this.btnOptions.UseVisualStyleBackColor = true;
        this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
        // 
        // flowLayoutPanelCuttedFingers
        // 
        this.flowLayoutPanelCuttedFingers.BackColor = System.Drawing.Color.White;
        this.flowLayoutPanelCuttedFingers.Location = new System.Drawing.Point(3, 283);
        this.flowLayoutPanelCuttedFingers.Name = "flowLayoutPanelCuttedFingers";
        this.flowLayoutPanelCuttedFingers.Size = new System.Drawing.Size(468, 110);
        this.flowLayoutPanelCuttedFingers.TabIndex = 7;
        // 
        // pictureBoxCurrentCapturing
        // 
        this.pictureBoxCurrentCapturing.BackColor = System.Drawing.Color.White;
        this.pictureBoxCurrentCapturing.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBoxCurrentCapturing.Location = new System.Drawing.Point(3, 3);
        this.pictureBoxCurrentCapturing.Name = "pictureBoxCurrentCapturing";
        this.pictureBoxCurrentCapturing.Size = new System.Drawing.Size(471, 274);
        this.pictureBoxCurrentCapturing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBoxCurrentCapturing.TabIndex = 4;
        this.pictureBoxCurrentCapturing.TabStop = false;
        this.pictureBoxCurrentCapturing.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox_Paint_1);
        // 
        // groupBoxExtended2
        // 
        this.groupBoxExtended2.BorderColor = System.Drawing.Color.Black;
        this.groupBoxExtended2.Controls.Add(this.tableLayoutPanelCurCapturing);
        this.groupBoxExtended2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBoxExtended2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.groupBoxExtended2.Location = new System.Drawing.Point(480, 3);
        this.groupBoxExtended2.Name = "groupBoxExtended2";
        this.groupBoxExtended2.Size = new System.Drawing.Size(251, 274);
        this.groupBoxExtended2.TabIndex = 9;
        this.groupBoxExtended2.TabStop = false;
        this.groupBoxExtended2.Text = "CONTROL";
        // 
        // tableLayoutPanelCurCapturing
        // 
        this.tableLayoutPanelCurCapturing.ColumnCount = 2;
        this.tableLayoutPanelCurCapturing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanelCurCapturing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanelCurCapturing.Controls.Add(this.buttonSuccResults, 0, 4);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.buttonSuccSave, 1, 4);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.buttonPrevCapturing, 0, 3);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.buttonNextCapturing, 1, 3);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.labelHeaderState, 0, 1);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.picBoxCurLeftHand, 0, 2);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.picBoxCurRightHand, 1, 2);
        this.tableLayoutPanelCurCapturing.Controls.Add(this.comboBox1, 0, 0);
        this.tableLayoutPanelCurCapturing.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelCurCapturing.Location = new System.Drawing.Point(3, 19);
        this.tableLayoutPanelCurCapturing.Name = "tableLayoutPanelCurCapturing";
        this.tableLayoutPanelCurCapturing.RowCount = 5;
        this.tableLayoutPanelCurCapturing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        this.tableLayoutPanelCurCapturing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        this.tableLayoutPanelCurCapturing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
        this.tableLayoutPanelCurCapturing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        this.tableLayoutPanelCurCapturing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        this.tableLayoutPanelCurCapturing.Size = new System.Drawing.Size(245, 252);
        this.tableLayoutPanelCurCapturing.TabIndex = 4;
        // 
        // buttonSuccResults
        // 
        this.buttonSuccResults.Dock = System.Windows.Forms.DockStyle.Top;
        this.buttonSuccResults.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonSuccResults.Location = new System.Drawing.Point(3, 198);
        this.buttonSuccResults.Name = "buttonSuccResults";
        this.buttonSuccResults.Size = new System.Drawing.Size(116, 30);
        this.buttonSuccResults.TabIndex = 4;
        this.buttonSuccResults.Text = "Huellas capturadas";
        this.buttonSuccResults.UseVisualStyleBackColor = true;
        this.buttonSuccResults.Click += new System.EventHandler(this.buttonSuccResults_Click);
        // 
        // buttonSuccSave
        // 
        this.buttonSuccSave.Dock = System.Windows.Forms.DockStyle.Top;
        this.buttonSuccSave.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.buttonSuccSave.Location = new System.Drawing.Point(125, 198);
        this.buttonSuccSave.Name = "buttonSuccSave";
        this.buttonSuccSave.Size = new System.Drawing.Size(117, 30);
        this.buttonSuccSave.TabIndex = 4;
        this.buttonSuccSave.Text = "Guardar";
        this.buttonSuccSave.UseVisualStyleBackColor = true;
        this.buttonSuccSave.Click += new System.EventHandler(this.buttonSuccSave_Click);
        // 
        // buttonPrevCapturing
        // 
        this.buttonPrevCapturing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrevCapturing.BackgroundImage")));
        this.buttonPrevCapturing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        this.buttonPrevCapturing.Dock = System.Windows.Forms.DockStyle.Fill;
        this.buttonPrevCapturing.Location = new System.Drawing.Point(3, 158);
        this.buttonPrevCapturing.Name = "buttonPrevCapturing";
        this.buttonPrevCapturing.Size = new System.Drawing.Size(116, 34);
        this.buttonPrevCapturing.TabIndex = 1;
        this.buttonPrevCapturing.UseVisualStyleBackColor = true;
        this.buttonPrevCapturing.Click += new System.EventHandler(this.buttonPrevCapturing_Click);
        // 
        // buttonNextCapturing
        // 
        this.buttonNextCapturing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNextCapturing.BackgroundImage")));
        this.buttonNextCapturing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        this.buttonNextCapturing.Dock = System.Windows.Forms.DockStyle.Fill;
        this.buttonNextCapturing.Location = new System.Drawing.Point(125, 158);
        this.buttonNextCapturing.Name = "buttonNextCapturing";
        this.buttonNextCapturing.Size = new System.Drawing.Size(117, 34);
        this.buttonNextCapturing.TabIndex = 2;
        this.buttonNextCapturing.UseVisualStyleBackColor = true;
        this.buttonNextCapturing.Click += new System.EventHandler(this.buttonNextCapturing_Click);
        // 
        // labelHeaderState
        // 
        this.labelHeaderState.Anchor = System.Windows.Forms.AnchorStyles.Top;
        this.labelHeaderState.AutoSize = true;
        this.tableLayoutPanelCurCapturing.SetColumnSpan(this.labelHeaderState, 2);
        this.labelHeaderState.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.labelHeaderState.Location = new System.Drawing.Point(89, 65);
        this.labelHeaderState.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
        this.labelHeaderState.Name = "labelHeaderState";
        this.labelHeaderState.Size = new System.Drawing.Size(67, 15);
        this.labelHeaderState.TabIndex = 0;
        this.labelHeaderState.Text = "One Rolled";
        // 
        // picBoxCurLeftHand
        // 
        this.picBoxCurLeftHand.Dock = System.Windows.Forms.DockStyle.Fill;
        this.picBoxCurLeftHand.Image = ((System.Drawing.Image)(resources.GetObject("picBoxCurLeftHand.Image")));
        this.picBoxCurLeftHand.Location = new System.Drawing.Point(3, 88);
        this.picBoxCurLeftHand.Name = "picBoxCurLeftHand";
        this.picBoxCurLeftHand.Size = new System.Drawing.Size(116, 64);
        this.picBoxCurLeftHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.picBoxCurLeftHand.TabIndex = 0;
        this.picBoxCurLeftHand.TabStop = false;
        // 
        // picBoxCurRightHand
        // 
        this.picBoxCurRightHand.Dock = System.Windows.Forms.DockStyle.Fill;
        this.picBoxCurRightHand.Location = new System.Drawing.Point(125, 88);
        this.picBoxCurRightHand.Name = "picBoxCurRightHand";
        this.picBoxCurRightHand.Size = new System.Drawing.Size(117, 64);
        this.picBoxCurRightHand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.picBoxCurRightHand.TabIndex = 3;
        this.picBoxCurRightHand.TabStop = false;
        // 
        // comboBox1
        // 
        this.tableLayoutPanelCurCapturing.SetColumnSpan(this.comboBox1, 2);
        this.comboBox1.Enabled = false;
        this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(3, 3);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(239, 37);
        this.comboBox1.TabIndex = 5;
        // 
        // tableLayoutPanelDoubleBuffered1
        // 
        this.tableLayoutPanelDoubleBuffered1.ColumnCount = 1;
        this.tableLayoutPanelDoubleBuffered1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelDoubleBuffered1.Controls.Add(this.groupBoxExtended3, 0, 1);
        this.tableLayoutPanelDoubleBuffered1.Controls.Add(this.listViewMessages, 0, 1);
        this.tableLayoutPanelDoubleBuffered1.Controls.Add(this.groupBoxExtended1, 0, 0);
        this.tableLayoutPanelDoubleBuffered1.Location = new System.Drawing.Point(3, 3);
        this.tableLayoutPanelDoubleBuffered1.Name = "tableLayoutPanelDoubleBuffered1";
        this.tableLayoutPanelDoubleBuffered1.RowCount = 2;
        this.tableLayoutPanelDoubleBuffered1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanelDoubleBuffered1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
        this.tableLayoutPanelDoubleBuffered1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
        this.tableLayoutPanelDoubleBuffered1.Size = new System.Drawing.Size(275, 451);
        this.tableLayoutPanelDoubleBuffered1.TabIndex = 2;
        // 
        // groupBoxExtended3
        // 
        this.groupBoxExtended3.BorderColor = System.Drawing.Color.Black;
        this.groupBoxExtended3.Controls.Add(this.tableLayoutPanelScore);
        this.groupBoxExtended3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBoxExtended3.Location = new System.Drawing.Point(3, 90);
        this.groupBoxExtended3.Name = "groupBoxExtended3";
        this.groupBoxExtended3.Size = new System.Drawing.Size(269, 94);
        this.groupBoxExtended3.TabIndex = 12;
        this.groupBoxExtended3.TabStop = false;
        // 
        // tableLayoutPanelScore
        // 
        this.tableLayoutPanelScore.ColumnCount = 5;
        this.tableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        this.tableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanelScore.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableLayoutPanelScore.Controls.Add(this.textBoxScore4, 4, 0);
        this.tableLayoutPanelScore.Controls.Add(this.textBoxScore3, 3, 0);
        this.tableLayoutPanelScore.Controls.Add(this.textBoxScore2, 2, 0);
        this.tableLayoutPanelScore.Controls.Add(this.textBoxScore1, 1, 0);
        this.tableLayoutPanelScore.Dock = System.Windows.Forms.DockStyle.Top;
        this.tableLayoutPanelScore.Location = new System.Drawing.Point(3, 16);
        this.tableLayoutPanelScore.Name = "tableLayoutPanelScore";
        this.tableLayoutPanelScore.RowCount = 2;
        this.tableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelScore.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelScore.Size = new System.Drawing.Size(263, 25);
        this.tableLayoutPanelScore.TabIndex = 1;
        // 
        // textBoxScore4
        // 
        this.textBoxScore4.BackColor = System.Drawing.SystemColors.Control;
        this.textBoxScore4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBoxScore4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBoxScore4.ForeColor = System.Drawing.Color.Navy;
        this.textBoxScore4.Location = new System.Drawing.Point(198, 3);
        this.textBoxScore4.Name = "textBoxScore4";
        this.textBoxScore4.ReadOnly = true;
        this.textBoxScore4.Size = new System.Drawing.Size(62, 20);
        this.textBoxScore4.TabIndex = 4;
        this.textBoxScore4.Text = "0";
        this.textBoxScore4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // textBoxScore3
        // 
        this.textBoxScore3.BackColor = System.Drawing.SystemColors.Control;
        this.textBoxScore3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBoxScore3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBoxScore3.ForeColor = System.Drawing.Color.Navy;
        this.textBoxScore3.Location = new System.Drawing.Point(133, 3);
        this.textBoxScore3.Name = "textBoxScore3";
        this.textBoxScore3.ReadOnly = true;
        this.textBoxScore3.Size = new System.Drawing.Size(59, 20);
        this.textBoxScore3.TabIndex = 3;
        this.textBoxScore3.Text = "0";
        this.textBoxScore3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // textBoxScore2
        // 
        this.textBoxScore2.BackColor = System.Drawing.SystemColors.Control;
        this.textBoxScore2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBoxScore2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBoxScore2.ForeColor = System.Drawing.Color.Navy;
        this.textBoxScore2.Location = new System.Drawing.Point(68, 3);
        this.textBoxScore2.Name = "textBoxScore2";
        this.textBoxScore2.ReadOnly = true;
        this.textBoxScore2.Size = new System.Drawing.Size(59, 20);
        this.textBoxScore2.TabIndex = 2;
        this.textBoxScore2.Text = "0";
        this.textBoxScore2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // textBoxScore1
        // 
        this.textBoxScore1.BackColor = System.Drawing.SystemColors.Control;
        this.textBoxScore1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBoxScore1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.textBoxScore1.ForeColor = System.Drawing.Color.Navy;
        this.textBoxScore1.Location = new System.Drawing.Point(3, 3);
        this.textBoxScore1.Name = "textBoxScore1";
        this.textBoxScore1.ReadOnly = true;
        this.textBoxScore1.Size = new System.Drawing.Size(59, 20);
        this.textBoxScore1.TabIndex = 1;
        this.textBoxScore1.Text = "0";
        this.textBoxScore1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // listViewMessages
        // 
        this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderProcess,
            this.columnHeaderDuration});
        this.listViewMessages.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listViewMessages.ForeColor = System.Drawing.Color.Navy;
        this.listViewMessages.GridLines = true;
        this.listViewMessages.Location = new System.Drawing.Point(3, 190);
        this.listViewMessages.Name = "listViewMessages";
        this.listViewMessages.Size = new System.Drawing.Size(269, 258);
        this.listViewMessages.TabIndex = 11;
        this.listViewMessages.UseCompatibleStateImageBehavior = false;
        this.listViewMessages.View = System.Windows.Forms.View.Details;
        this.listViewMessages.SelectedIndexChanged += new System.EventHandler(this.listViewMessages_SelectedIndexChanged);
        // 
        // columnHeaderProcess
        // 
        this.columnHeaderProcess.Text = "Process";
        this.columnHeaderProcess.Width = 130;
        // 
        // columnHeaderDuration
        // 
        this.columnHeaderDuration.Text = "Duration";
        this.columnHeaderDuration.Width = 89;
        // 
        // groupBoxExtended1
        // 
        this.groupBoxExtended1.BorderColor = System.Drawing.Color.Black;
        this.groupBoxExtended1.Controls.Add(this.tableLayoutPanel4);
        this.groupBoxExtended1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupBoxExtended1.Location = new System.Drawing.Point(3, 3);
        this.groupBoxExtended1.Name = "groupBoxExtended1";
        this.groupBoxExtended1.Size = new System.Drawing.Size(269, 81);
        this.groupBoxExtended1.TabIndex = 3;
        this.groupBoxExtended1.TabStop = false;
        this.groupBoxExtended1.Text = "SECUENCIA CALIDAD";
        this.groupBoxExtended1.UseCompatibleTextRendering = true;
        // 
        // tableLayoutPanel4
        // 
        this.tableLayoutPanel4.ColumnCount = 2;
        this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
        this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel4.Controls.Add(this.pictureBox442, 1, 0);
        this.tableLayoutPanel4.Controls.Add(this.radioButton442, 0, 0);
        this.tableLayoutPanel4.Controls.Add(this.radioButton424, 0, 1);
        this.tableLayoutPanel4.Controls.Add(this.radioButton1Flat, 1, 1);
        this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
        this.tableLayoutPanel4.Name = "tableLayoutPanel4";
        this.tableLayoutPanel4.RowCount = 2;
        this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99F));
        this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
        this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel4.Size = new System.Drawing.Size(263, 62);
        this.tableLayoutPanel4.TabIndex = 5;
        // 
        // pictureBox442
        // 
        this.pictureBox442.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox442.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox442.Image")));
        this.pictureBox442.Location = new System.Drawing.Point(117, 3);
        this.pictureBox442.Name = "pictureBox442";
        this.pictureBox442.Size = new System.Drawing.Size(143, 55);
        this.pictureBox442.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox442.TabIndex = 12;
        this.pictureBox442.TabStop = false;
        // 
        // radioButton442
        // 
        this.radioButton442.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.radioButton442.AutoSize = true;
        this.radioButton442.Location = new System.Drawing.Point(3, 22);
        this.radioButton442.Name = "radioButton442";
        this.radioButton442.Size = new System.Drawing.Size(49, 17);
        this.radioButton442.TabIndex = 11;
        this.radioButton442.Tag = "FourFourTwo";
        this.radioButton442.Text = "4-4-2";
        this.radioButton442.UseVisualStyleBackColor = true;
        // 
        // radioButton424
        // 
        this.radioButton424.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.radioButton424.AutoSize = true;
        this.radioButton424.Location = new System.Drawing.Point(3, 64);
        this.radioButton424.Name = "radioButton424";
        this.radioButton424.Size = new System.Drawing.Size(49, 1);
        this.radioButton424.TabIndex = 3;
        this.radioButton424.TabStop = true;
        this.radioButton424.Tag = "FourTwoFour";
        this.radioButton424.Text = "4-2-4";
        this.radioButton424.UseVisualStyleBackColor = true;
        // 
        // radioButton1Flat
        // 
        this.radioButton1Flat.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.radioButton1Flat.AutoSize = true;
        this.radioButton1Flat.Location = new System.Drawing.Point(117, 64);
        this.radioButton1Flat.Name = "radioButton1Flat";
        this.radioButton1Flat.Size = new System.Drawing.Size(78, 1);
        this.radioButton1Flat.TabIndex = 0;
        this.radioButton1Flat.TabStop = true;
        this.radioButton1Flat.Tag = "OneRolled";
        this.radioButton1Flat.Text = "One Rolled";
        this.radioButton1Flat.UseVisualStyleBackColor = true;
        // 
        // imageListSeg
        // 
        this.imageListSeg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSeg.ImageStream")));
        this.imageListSeg.TransparentColor = System.Drawing.Color.Transparent;
        this.imageListSeg.Images.SetKeyName(0, "LeftThumb.bmp");
        // 
        // tableLayoutPanel2
        // 
        this.tableLayoutPanel2.ColumnCount = 1;
        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel2.Controls.Add(this.buttonClearResultMessages, 0, 1);
        this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel2.Name = "tableLayoutPanel2";
        this.tableLayoutPanel2.RowCount = 2;
        this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
        this.tableLayoutPanel2.TabIndex = 0;
        // 
        // buttonClearResultMessages
        // 
        this.buttonClearResultMessages.Dock = System.Windows.Forms.DockStyle.Fill;
        this.buttonClearResultMessages.Location = new System.Drawing.Point(3, 23);
        this.buttonClearResultMessages.Name = "buttonClearResultMessages";
        this.buttonClearResultMessages.Size = new System.Drawing.Size(194, 74);
        this.buttonClearResultMessages.TabIndex = 2;
        this.buttonClearResultMessages.Text = "Clear";
        this.buttonClearResultMessages.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanelMainSkeleton
        // 
        this.tableLayoutPanelMainSkeleton.ColumnCount = 1;
        this.tableLayoutPanelMainSkeleton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelMainSkeleton.Controls.Add(this.pictureBox3, 0, 2);
        this.tableLayoutPanelMainSkeleton.Controls.Add(this.tableLayoutPanelMain, 0, 1);
        this.tableLayoutPanelMainSkeleton.Controls.Add(this.flowLayoutPanel1, 0, 0);
        this.tableLayoutPanelMainSkeleton.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanelMainSkeleton.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanelMainSkeleton.Name = "tableLayoutPanelMainSkeleton";
        this.tableLayoutPanelMainSkeleton.RowCount = 3;
        this.tableLayoutPanelMainSkeleton.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanelMainSkeleton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelMainSkeleton.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanelMainSkeleton.Size = new System.Drawing.Size(1027, 749);
        this.tableLayoutPanelMainSkeleton.TabIndex = 4;
        this.tableLayoutPanelMainSkeleton.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelMainSkeleton_Paint);
        // 
        // pictureBox3
        // 
        this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
        this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox3.Location = new System.Drawing.Point(0, 651);
        this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
        this.pictureBox3.Name = "pictureBox3";
        this.pictureBox3.Size = new System.Drawing.Size(1027, 98);
        this.pictureBox3.TabIndex = 4;
        this.pictureBox3.TabStop = false;
        this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
        // 
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
        this.flowLayoutPanel1.Controls.Add(this.Afiliado);
        this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new System.Drawing.Size(1021, 182);
        this.flowLayoutPanel1.TabIndex = 5;
        // 
        // pictureBox2
        // 
        this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
        this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
        this.pictureBox2.Location = new System.Drawing.Point(3, 0);
        this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
        this.pictureBox2.Name = "pictureBox2";
        this.pictureBox2.Size = new System.Drawing.Size(1018, 95);
        this.pictureBox2.TabIndex = 4;
        this.pictureBox2.TabStop = false;
        this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
        // 
        // Afiliado
        // 
        this.Afiliado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.Afiliado.BackColor = System.Drawing.Color.LightGray;
        this.Afiliado.Controls.Add(this.flowLayoutPanel2);
        this.Afiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
        this.Afiliado.Location = new System.Drawing.Point(3, 95);
        this.Afiliado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
        this.Afiliado.Name = "Afiliado";
        this.Afiliado.Size = new System.Drawing.Size(1015, 87);
        this.Afiliado.TabIndex = 5;
        this.Afiliado.TabStop = false;
        this.Afiliado.Text = "AFILIADO";
        this.Afiliado.Enter += new System.EventHandler(this.Afiliado_Enter);
        // 
        // flowLayoutPanel2
        // 
        this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel6);
        this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel4);
        this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel5);
        this.flowLayoutPanel2.Controls.Add(this.button1);
        this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel2.Location = new System.Drawing.Point(20, 14);
        this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
        this.flowLayoutPanel2.Name = "flowLayoutPanel2";
        this.flowLayoutPanel2.Size = new System.Drawing.Size(986, 67);
        this.flowLayoutPanel2.TabIndex = 1;
        this.flowLayoutPanel2.Tag = "";
        // 
        // flowLayoutPanel6
        // 
        this.flowLayoutPanel6.Controls.Add(this.label3);
        this.flowLayoutPanel6.Controls.Add(this.f_matricula);
        this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel6.Name = "flowLayoutPanel6";
        this.flowLayoutPanel6.Size = new System.Drawing.Size(254, 62);
        this.flowLayoutPanel6.TabIndex = 2;
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.label3.Location = new System.Drawing.Point(3, 0);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(45, 20);
        this.label3.TabIndex = 0;
        this.label3.Text = "NUP";
        // 
        // f_matricula
        // 
        this.f_matricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
        this.f_matricula.Location = new System.Drawing.Point(3, 23);
        this.f_matricula.Multiline = true;
        this.f_matricula.Name = "f_matricula";
        this.f_matricula.ReadOnly = true;
        this.f_matricula.Size = new System.Drawing.Size(222, 35);
        this.f_matricula.TabIndex = 1;
        // 
        // flowLayoutPanel4
        // 
        this.flowLayoutPanel4.Controls.Add(this.label1);
        this.flowLayoutPanel4.Controls.Add(this.f_afiliado);
        this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel4.Location = new System.Drawing.Point(263, 3);
        this.flowLayoutPanel4.Name = "flowLayoutPanel4";
        this.flowLayoutPanel4.Size = new System.Drawing.Size(269, 62);
        this.flowLayoutPanel4.TabIndex = 0;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.label1.Location = new System.Drawing.Point(3, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(85, 20);
        this.label1.TabIndex = 0;
        this.label1.Text = "NOMBRE";
        // 
        // f_afiliado
        // 
        this.f_afiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
        this.f_afiliado.Location = new System.Drawing.Point(3, 23);
        this.f_afiliado.Multiline = true;
        this.f_afiliado.Name = "f_afiliado";
        this.f_afiliado.ReadOnly = true;
        this.f_afiliado.Size = new System.Drawing.Size(250, 35);
        this.f_afiliado.TabIndex = 1;
        // 
        // flowLayoutPanel5
        // 
        this.flowLayoutPanel5.Controls.Add(this.label2);
        this.flowLayoutPanel5.Controls.Add(this.f_ci);
        this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel5.Location = new System.Drawing.Point(538, 3);
        this.flowLayoutPanel5.Name = "flowLayoutPanel5";
        this.flowLayoutPanel5.Size = new System.Drawing.Size(254, 62);
        this.flowLayoutPanel5.TabIndex = 1;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
        this.label2.Location = new System.Drawing.Point(3, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(37, 20);
        this.label2.TabIndex = 0;
        this.label2.Text = "C.I.";
        // 
        // f_ci
        // 
        this.f_ci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
        this.f_ci.Location = new System.Drawing.Point(3, 23);
        this.f_ci.Multiline = true;
        this.f_ci.Name = "f_ci";
        this.f_ci.ReadOnly = true;
        this.f_ci.Size = new System.Drawing.Size(222, 35);
        this.f_ci.TabIndex = 1;
        // 
        // button1
        // 
        this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.button1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Bold);
        this.button1.ForeColor = System.Drawing.Color.Black;
        this.button1.Location = new System.Drawing.Point(798, 14);
        this.button1.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(188, 47);
        this.button1.TabIndex = 3;
        this.button1.Text = "ACTUALIZAR";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click_1);
        // 
        // tableLayoutPanelCaptSequence
        // 
        this.tableLayoutPanelCaptSequence.ColumnCount = 2;
        this.tableLayoutPanelCaptSequence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
        this.tableLayoutPanelCaptSequence.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanelCaptSequence.Controls.Add(this.pictureBox1, 1, 4);
        this.tableLayoutPanelCaptSequence.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanelCaptSequence.Name = "tableLayoutPanelCaptSequence";
        this.tableLayoutPanelCaptSequence.RowCount = 2;
        this.tableLayoutPanelCaptSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelCaptSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelCaptSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelCaptSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelCaptSequence.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanelCaptSequence.Size = new System.Drawing.Size(200, 100);
        this.tableLayoutPanelCaptSequence.TabIndex = 0;
        // 
        // pictureBox1
        // 
        this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        this.pictureBox1.Location = new System.Drawing.Point(117, 83);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(80, 14);
        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.pictureBox1.TabIndex = 2;
        this.pictureBox1.TabStop = false;
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.Controls.Add(this.pictureBox442x10_bot, 0, 1);
        this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 2;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // pictureBox442x10_bot
        // 
        this.pictureBox442x10_bot.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox442x10_bot.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox442x10_bot.Image")));
        this.pictureBox442x10_bot.Location = new System.Drawing.Point(3, 23);
        this.pictureBox442x10_bot.Name = "pictureBox442x10_bot";
        this.pictureBox442x10_bot.Size = new System.Drawing.Size(194, 74);
        this.pictureBox442x10_bot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox442x10_bot.TabIndex = 14;
        this.pictureBox442x10_bot.TabStop = false;
        // 
        // pictureBox442x10_top
        // 
        this.pictureBox442x10_top.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pictureBox442x10_top.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox442x10_top.Image")));
        this.pictureBox442x10_top.Location = new System.Drawing.Point(3, 3);
        this.pictureBox442x10_top.Name = "pictureBox442x10_top";
        this.pictureBox442x10_top.Size = new System.Drawing.Size(186, 43);
        this.pictureBox442x10_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pictureBox442x10_top.TabIndex = 13;
        this.pictureBox442x10_top.TabStop = false;
        // 
        // MainForm
        // 
        this.AllowDrop = true;
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(1027, 749);
        this.Controls.Add(this.tableLayoutPanelMainSkeleton);
        this.ForeColor = System.Drawing.Color.Navy;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Muserpol / Biometrico V 1.0";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.tableLayoutPanelMain.ResumeLayout(false);
        this.tableLayoutPanelCurrenScan.ResumeLayout(false);
        this.tableLayoutPanel3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrentCapturing)).EndInit();
        this.groupBoxExtended2.ResumeLayout(false);
        this.tableLayoutPanelCurCapturing.ResumeLayout(false);
        this.tableLayoutPanelCurCapturing.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.picBoxCurLeftHand)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.picBoxCurRightHand)).EndInit();
        this.tableLayoutPanelDoubleBuffered1.ResumeLayout(false);
        this.groupBoxExtended3.ResumeLayout(false);
        this.tableLayoutPanelScore.ResumeLayout(false);
        this.tableLayoutPanelScore.PerformLayout();
        this.groupBoxExtended1.ResumeLayout(false);
        this.tableLayoutPanel4.ResumeLayout(false);
        this.tableLayoutPanel4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox442)).EndInit();
        this.tableLayoutPanel2.ResumeLayout(false);
        this.tableLayoutPanelMainSkeleton.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
        this.flowLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        this.Afiliado.ResumeLayout(false);
        this.flowLayoutPanel2.ResumeLayout(false);
        this.flowLayoutPanel6.ResumeLayout(false);
        this.flowLayoutPanel6.PerformLayout();
        this.flowLayoutPanel4.ResumeLayout(false);
        this.flowLayoutPanel4.PerformLayout();
        this.flowLayoutPanel5.ResumeLayout(false);
        this.flowLayoutPanel5.PerformLayout();
        this.tableLayoutPanelCaptSequence.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        this.tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox442x10_bot)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pictureBox442x10_top)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurrenScan;
    private System.Windows.Forms.PictureBox pictureBoxCurrentCapturing;
    private System.Windows.Forms.ImageList imageListSeg;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button buttonClearResultMessages;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainSkeleton;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCaptSequence;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox pictureBox442x10_bot;
    private System.Windows.Forms.PictureBox pictureBox442x10_top;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private TableLayoutPanelDoubleBuffered tableLayoutPanelDoubleBuffered1;
    private GroupBoxExtended groupBoxExtended1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    private System.Windows.Forms.PictureBox pictureBox442;
    private System.Windows.Forms.RadioButton radioButton442;
    private System.Windows.Forms.RadioButton radioButton424;
    private System.Windows.Forms.RadioButton radioButton1Flat;
    private System.Windows.Forms.ListView listViewMessages;
    private System.Windows.Forms.ColumnHeader columnHeaderProcess;
    private System.Windows.Forms.ColumnHeader columnHeaderDuration;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnOptions;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCuttedFingers;
    private GroupBoxExtended groupBoxExtended2;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurCapturing;
    private System.Windows.Forms.Button buttonPrevCapturing;
    private System.Windows.Forms.Button buttonNextCapturing;
    private System.Windows.Forms.Label labelHeaderState;
    private System.Windows.Forms.PictureBox picBoxCurLeftHand;
    private System.Windows.Forms.PictureBox picBoxCurRightHand;
    private GroupBoxExtended groupBoxExtended3;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScore;
    private System.Windows.Forms.TextBox textBoxScore4;
    private System.Windows.Forms.TextBox textBoxScore3;
    private System.Windows.Forms.TextBox textBoxScore2;
    private System.Windows.Forms.TextBox textBoxScore1;
    private System.Windows.Forms.Button buttonSuccResults;
    private System.Windows.Forms.Button buttonSuccSave;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.GroupBox Afiliado;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox f_afiliado;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox f_ci;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox f_matricula;
    private System.Windows.Forms.Button button1;

  }
}

