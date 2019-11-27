using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using Dermalog.AFIS.FourprintSegmentation;
using Dermalog.Imaging.Capturing;
using System.Reflection;
using Dermalog.Afis.NistQualityCheck;
using System.IO;
using Dermalog.Afis.ImageContainer.Enums;
using Dermalog.Afis.ImageContainer;


namespace LF10Demo
{
    /// <summary>
    /// Sequece Type
    /// </summary>
    public enum ActiveSequence
    {
        /// <summary>
        /// OneRolled 
        /// </summary>
        OneRolled,
        /// <summary>
        /// FourTwoFour Sequence
        /// </summary>
        FourTwoFour,
        /// <summary>
        /// FourFourTwo Sequence
        /// </summary>
        FourFourTwo,
    }

    /// <summary>
    /// Application State.
    /// </summary>
    public enum ApplicationState
    {
        Idle,
        Init,
        InitScanner,
        Init4PSegmentation,
        Scan,
        SequenceCheck,
        SequenceCheckSuccessful,
        SequenceCheckFailed,
        Validation,
        ValidationSuccessful,
        ValidationFailed,
        DeviceError
    }

    /// <summary>
    /// The Main Form of this Demo.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        /// <summary>
        /// Before time stamp for statistic.
        /// </summary>
        private DateTime beforeTime;
        /// <summary>
        /// For measuring time span of complete sequence.
        /// </summary>
        private DateTime sequenceStartTime;
        /// <summary>
        /// SplashScreen
        /// </summary>
        SplashScreen splashScreen;
        /// <summary>
        /// Max steps in current sequence.
        /// </summary>
        private int maxSequenceSteps;
        /// <summary>
        /// Scanner device
        /// </summary>
        private Device _scanner;
        /// <summary>
        /// Object for validation of scanner results.
        /// </summary>
        private LF10ResultValidator lf10Validator;
        /// <summary>
        /// Object for segmentation of fingers.
        /// </summary>
        private FourprintSegmenation _fpSegmentation;
        /// <summary>
        /// Object for waiting asynchrony for scanner results and result validation.
        /// </summary>
        private AutoResetEvent waitOfValidation = new AutoResetEvent(false);
        /// <summary>
        /// Thread for Scanning process.
        /// </summary>
        private Thread ScanThread;
        /// <summary>
        /// Result of validation.
        /// </summary>
        private bool validSuccessful = false;
        /// <summary>
        /// List for succesful capturing results.
        /// </summary>
        private Dictionary<string, LF10ResultItem> lf10Results;
        /// <summary>
        /// Current state of application.
        /// </summary>
        private ApplicationState state;
        /// <summary>
        /// Active sequence.
        /// </summary>
        private ActiveSequence activeSequence;
        /// <summary>
        /// Current step in a sequence.
        /// </summary>
        private int currentStep = 1;
        /// <summary>
        /// Fake detected flag.
        /// </summary>
        private bool fakeDetected = false;

        private bool msgboxOpen = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            RedirectAssembly("Dermalog.Imaging.Capturing");
            RedirectAssembly("Dermalog.AFIS.FourprintSegmentation");

            RedirectAssembly("Dermalog.Afis.NistQualityCheck");
            RedirectAssembly("Dermalog.Afis.ImageContainer");

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ShowSplashScreen();
                this.Init();
                this.StartSequence();
                CloseSplashScreen();
                this.TopMost = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                CloseSplashScreen();
                this.TopMost = true;
                MessageBox.Show(this, "Error: " + ex.Message + "\n\nMake sure the LF10/ZF10 is connected to your computer \nand restart the application.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static void RedirectAssembly(string shortName)
        {
            ResolveEventHandler handler = null;
            handler = (sender, args) =>
            {
                var requestedAssembly = new AssemblyName(args.Name);
                if (requestedAssembly.Name != shortName)
                    return null;

                AppDomain.CurrentDomain.AssemblyResolve -= handler;
                return Assembly.LoadWithPartialName(shortName);
            };
            AppDomain.CurrentDomain.AssemblyResolve += handler;
        }

        // redraws image using nearest neighbour resampling
        private void picBox_Paint_1(object sender, PaintEventArgs e)
        {
            try
            {
                PictureBox pbSender = sender as PictureBox;
                System.Drawing.Image imgOriginal = pbSender.Image;

                if (imgOriginal == null)
                    return;

                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                e.Graphics.DrawImage(
                   imgOriginal,
                    new Rectangle(0, 0, pbSender.Width, pbSender.Height),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    imgOriginal.Width,       // width of source rectangle
                    imgOriginal.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);
            }
            catch (System.Exception)
            {

            }

        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether  <see cref="autoStepping"/>.
        /// </summary>
        /// <value><c>true</c> if [autoStepping]; otherwise, <c>false</c>.</value>
        public bool AutoStepping
        {
            get { return Properties.Settings.Default.AutoStepping; }
            set
            {
                Properties.Settings.Default.AutoStepping = value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [fake detected].
        /// </summary>
        /// <value><c>true</c> if [fake detected]; otherwise, <c>false</c>.</value>
        public bool FakeDetected
        {
            get { return this.fakeDetected; }
            set { this.fakeDetected = value; }
        }
        /// <summary>
        /// Gets or sets the state of the application.
        /// </summary>
        /// <value>The state of the appliaction. <see cref="ApplicationState"/></value>
        private ApplicationState State
        {
            get { return state; }
            set
            {
                if (this.state == ApplicationState.DeviceError && value != ApplicationState.InitScanner)
                {
                    return;
                }
                else
                {
                    if (splashScreen != null)
                        this.splashScreen.State = value;
                    state = value;
                    this.AddStateMessage("State: " + value.ToString(), Color.Navy);
                }
            }
        }
        #endregion


        #region Private Methods

        public class SegmentedFingerprintImage
        {
            public SegmentedFingerprintImage()
            {

            }
            public SegmentedFingerprint fpSeg = null;
            public int quality = 0;
        }

        /// <summary>
        /// Main method of the application. Starts the segmentation and validation process.
        /// After validation is ready, add results to the GUI
        /// </summary>
        /// <param name="image">The image from LF10/ZF10</param>
        /// 
        private void StartSegmentation(Image image, byte[] imageData)
        {
            try
            {
                this.ClearControlsOfLastCapturing();
                DateTime SegmentationTimeStart = DateTime.Now;

                //Segmentation of finger with FourprintSegmintation
                if (this.activeSequence != ActiveSequence.OneRolled)
                {
                    //use byte data to avoid serialization
                    uint count = _fpSegmentation.GetSegmentationCount(imageData);
                    DateTime SegmentationTimeEnd = DateTime.Now;

                    SegmentedFingerprintImage[] segments = new SegmentedFingerprintImage[count];

                    //get segments and calculate quality
                    DateTime NISTQualityTimeStart = DateTime.Now;
                    for (int i = 0; i < count; i++)
                    {
                        SegmentedFingerprintImage seg = new SegmentedFingerprintImage();
                        seg.fpSeg = _fpSegmentation.GetSegmentedFingerprint((uint)i);
                        using(Decoder decoder = new Decoder())
                        {
                            using(RawImage rawImg = decoder.Decode(seg.fpSeg.ImageData))
                            {
                                seg.quality = DermalogNistQualityCheck.CheckNfiq2(rawImg);
                                segments[i] = seg;
                            }
                        }                                                                        
                    }
                    DateTime NISTQualityTimeEnd = DateTime.Now;

                    //Set scanner LEDs
                    for (int i = 0; i < segments.Length; i++)
                    {
                        this.SetFingerPrintQualityToLed((int)segments[i].fpSeg.Position, segments[i].quality);
                    }

                    //update GUI
                    for (int i = 0; i < count; i++)//Iterate segmented fingers.
                    {
                        SegmentedFingerprintImage seg = segments[i];
                        this.ShowQuality(i, seg.quality);

                        image = this.DrawSegments(image, seg.fpSeg.Rect, seg.quality);
                        this.pictureBoxCurrentCapturing.BackColor = Color.White;
                        this.pictureBoxCurrentCapturing.Image = image; //Show segment in GUI                        
                        this.AddFingerToCollection(seg.fpSeg, count);

                        //Stop sequence if quality is to bad.
                        if (seg.quality < Properties.Settings.Default.NFIQ2ThresholdPoor )
                        {
                            return;
                        }
                    }

                    //add slap Image to Resultview with/out segmentation
                    AddSlapToCollection(image);
                    this.AddResultMessage(Properties.LF10Demo.TXT_Segmentation, (SegmentationTimeEnd - SegmentationTimeStart).TotalMilliseconds + " ms", Color.Navy);
                    this.AddResultMessage(Properties.LF10Demo.TXT_NISTQualityTime, (NISTQualityTimeEnd - NISTQualityTimeStart).TotalMilliseconds + " ms", Color.Navy);

                    //Start finger position validation if auto stepping is on.
                    if (this.AutoStepping)
                    {
                        this.State = ApplicationState.Validation;
                        this.validSuccessful = lf10Validator.ValidateCapturingSequence(segments, this.activeSequence, this.currentStep, this.FakeDetected);
                        if (validSuccessful)
                        {
                            this.State = ApplicationState.ValidationSuccessful;
                            //close MsgBox if successful Validation   
                            if (this.msgboxOpen)
                            {
                                SendKeys.Send("{ESC}");
                                this.msgboxOpen = false;
                            }
                        }
                        else
                        {
                            this.State = ApplicationState.SequenceCheckFailed;
                            if (!string.IsNullOrEmpty(lf10Validator.ValidError))
                                //check for open MsgBox
                                if (!this.msgboxOpen)
                                {
                                    this.msgboxOpen = true;
                                    DialogResult result = MessageBox.Show(lf10Validator.ValidError, Properties.LF10Demo.TXT_CapturingFailed, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //reset the possibility to open MsgBox if MsgBox is closed
                                    if (result == DialogResult.OK || result == DialogResult.Abort)
                                    {
                                        this.msgboxOpen = false;
                                    }
                                }
                        }
                        this.waitOfValidation.Set(); // Signal validation is done. 
                    }
                    else
                    {
                        this.validSuccessful = true;
                    }
                }
                else //No validation and drawing by one rolled.
                {
                    DateTime NISTQualityTimeStart = DateTime.Now;
                    int quality = Dermalog.Afis.NistQualityCheck.DermalogNistQualityCheck.Check(image);
                    this.ShowQuality(0, quality);
                    this.pictureBoxCurrentCapturing.BackColor = Color.White;
                    this.pictureBoxCurrentCapturing.Image = image;
                    this.CreateFingerButton(image, Properties.LF10Demo.TXT_FingerPrint);
                    validSuccessful = true;
                    DateTime NISTQualityTimeEnd = DateTime.Now;
                    this.AddResultMessage(Properties.LF10Demo.TXT_NISTQualityTime, (NISTQualityTimeEnd - NISTQualityTimeStart).TotalMilliseconds + " ms", Color.Navy);
                }


                //this.AddResultMessage(Properties.LF10Demo.TXT_SegmentationAndNFIQ, (DateTime.Now - beforeTime).TotalMilliseconds + " ms", Color.Navy);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// Inits this instance.
        /// </summary>
        private void Init()
        {
            //init settings, when starting application            
            Properties.Settings.Default.FakeDetectionEnable = false;
            Properties.Settings.Default.FakeDetectionThreshold = 70;
            Properties.Settings.Default.ShowQuality = true;
            Properties.Settings.Default.AutoStepping = true;
            Properties.Settings.Default.WSQCompressionEnable = false;
            Properties.Settings.Default.WSQValue = 100;
            Properties.Settings.Default.Save();

            this.State = ApplicationState.Init;
            this.lf10Results = new Dictionary<string, LF10ResultItem>();
            this.lf10Validator = new LF10ResultValidator();

            this.beforeTime = DateTime.Now;
            this.State = ApplicationState.Init4PSegmentation;
            _fpSegmentation = new FourprintSegmenation();
            this.AddResultMessage(Properties.LF10Demo.TXT_FourprintSegmenationInit, (DateTime.Now - beforeTime).TotalMilliseconds + " ms", Color.Navy);
            this.InitScanner();
            this.State = ApplicationState.Idle;
        }

        /// <summary>
        /// Loads the settings from config file.
        /// </summary>
        private void LoadSettings()
        {
            this.AutoStepping = Properties.Settings.Default.AutoStepping;
        }
        /// <summary>
        /// Start the Scan process.
        /// </summary>
        private void Scan()
        {
            try
            {
                this.lf10Results.Clear();
                if (this.State == ApplicationState.DeviceError)
                {
                    this.InitScanner();
                }
                if (this.State != ApplicationState.DeviceError)
                {
                    this.sequenceStartTime = DateTime.Now;
                    if (this.AutoStepping)
                    {
                        while (currentStep <= this.maxSequenceSteps && this.State != ApplicationState.DeviceError)
                        {
                            this.ScannerStartScan();
                            RefreshGuiSteps();
                            if (this.WaitOfScannerValidation())
                            {
                                currentStep++;
                            }
                            else
                            {
                                this.ValidationFailed();
                            }
                            ScannerStopScan();
                        }
                        if (this.validSuccessful)
                        {
                            this.AfterSequenceDone();
                        }
                    }
                    else
                    {
                        RefreshGuiSteps();
                        this.ScannerStartScan();
                    }
                }
            }
            catch (ThreadAbortException)
            {
                Debug.WriteLine("ScanThread aborted. Ignore this exception.");
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        private void Clear()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.Clear));
                    return;
                }
                else
                {
                    this.ClearControlsOfLastCapturing();
                    this.picBoxCurLeftHand.Image = Properties.Resources.LeftHandEmpty;
                    this.picBoxCurRightHand.Image = Properties.Resources.RightHandEmpty;
                    this.listViewMessages.Items.Clear();
                    this.labelHeaderState.Text = string.Empty;
                    this.SetScannerLeds(SegmentType.All, LedColor.Blue, false);
                    this.currentStep = 1;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// Afters the sequence done.
        /// </summary>
        private void AfterSequenceDone()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(this.AfterSequenceDone));
                return;
            }
            else
            {
                this.AbortSequence();
                this.State = ApplicationState.SequenceCheckSuccessful;
                this.AddResultMessage(Properties.LF10Demo.TXT_CompleteSequence, string.Format("{0:f2}", (DateTime.Now - this.sequenceStartTime).TotalSeconds) + " s", Color.Navy);
                this.State = ApplicationState.Idle;
                this.SetSequenceHeaderState(Properties.LF10Demo.TXT_SequenceComplete, Color.Navy);
                this.RefreshButtonState();
            }
        }
        /// <summary>
        /// Delegate for HandelException Invoke.
        /// </summary>
        delegate void HandelExceptionDelegate(Exception ex);
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private void HandleException(Exception exception)
        {
            if (this.InvokeRequired)
            {
                //this.Invoke(new MethodInvoker(delegate
                //  {
                //    this.HandleException(exception);
                //  }));
                HandelExceptionDelegate handExpDel = this.HandleException;
                this.Invoke(handExpDel, new object[] { exception });
                return;
            }
            else
            {
                if (exception.GetType().Equals(typeof(DeviceException)) || exception.Message.Contains("Error: 38"))
                {
                    this.State = ApplicationState.DeviceError;
                    this.AddStateMessage(exception.Message.ToString(), Color.Red);
                }
                else
                {
                    if (exception.Source.Equals("Dermalog.Imaging.Capturing"))
                    {
                        this.State = ApplicationState.DeviceError;
                    }
                    this.AddResultMessage(Properties.LF10Demo.TXT_Error, exception.Message.ToString(), Color.Red);
                }
                this.RefreshButtonState();
            }
        }
        /// <summary>
        /// Aborts the sequence.
        /// </summary>
        private void AbortSequence()
        {
            btnStart.Enabled = true;
            btnOptions.Enabled = true;
            btnStop.Enabled = false;

            ScannerStopScan();

            if (ScanThread != null && ScanThread.IsAlive)
            {
                ScanThread.Abort();
            }
            this.State = ApplicationState.Idle;
            this.RefreshButtonState();
        }

        #region Gui
        /// <summary>
        /// Refreshes the GUI steps.
        /// </summary>
        private void RefreshGuiSteps()
        {
            this.RefreshButtonState();
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(this.RefreshGuiSteps));
                return;
            }
            else
            {
                Debug.WriteLine("StartCapturing : ActSeq = " + this.activeSequence.ToString() + "Cur Step = " + this.currentStep);

                this.picBoxCurRightHand.Visible = true;
                this.tableLayoutPanelCurCapturing.SetColumnSpan(this.picBoxCurLeftHand, 1);

                switch (activeSequence)
                {
                    case ActiveSequence.OneRolled:
                        this.SetOneRolledActive(currentStep);
                        this.maxSequenceSteps = 1;
                        this.AutoStepping = false;
                        break;
                    case ActiveSequence.FourTwoFour:
                        this.SetGuiFourTwoFourActive(currentStep);
                        this.maxSequenceSteps = 3;
                        break;
                    case ActiveSequence.FourFourTwo:
                        this.SetGuiFourFourTwoActive(currentStep);
                        this.maxSequenceSteps = 3;
                        break;
                    default:
                        this.AutoStepping = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Refreshes the state of the button.
        /// </summary>
        private void RefreshButtonState()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.RefreshButtonState));
                return;
            }
            else
            {
                //Scan Button
                if (this.State == ApplicationState.Idle || this.State == ApplicationState.DeviceError)
                    this.btnStart.Enabled = this.btnOptions.Enabled = true;
                else
                    this.btnStart.Enabled = this.btnOptions.Enabled = false;

                //Stop button
                if (this.State != ApplicationState.InitScanner && this.State == ApplicationState.Scan
                                                              || this.State == ApplicationState.Validation
                                                              || this.State == ApplicationState.ValidationSuccessful)
                    this.btnStop.Enabled = true;
                else
                    this.btnStop.Enabled = false;

                //TenprintView Button                
                this.buttonSuccResults.Enabled = this.lf10Results != null && this.lf10Results.Count > 0;
                this.buttonSuccSave.Enabled = this.buttonSuccResults.Enabled;

                buttonNextCapturing.Enabled = buttonPrevCapturing.Enabled = (State == ApplicationState.Scan) && (!AutoStepping);
            }
        }
        /// <summary>
        /// Shows the quality in GUI.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="quality">The quality.</param>
        private void ShowQuality(int i, int quality)
        {
            if (Properties.Settings.Default.ShowQuality)
            {
                Color fontColor = Color.Navy;
                Color backColor = Color.White;
                if (quality < Properties.Settings.Default.NFIQ2ThresholdPoor)
                {
                    fontColor = Color.Red;
                    this.AddStateMessage(Properties.LF10Demo.TXT_QualityToBad, fontColor);
                }
                else
                {
                    this.AddStateMessage("State: " + this.State.ToString(), Color.Navy);
                }

                switch (i)
                {
                    case 0:
                        this.textBoxScore1.Enabled = true;
                        this.textBoxScore1.BackColor = backColor;
                        this.textBoxScore1.ForeColor = fontColor;
                        this.textBoxScore1.Text = quality.ToString();
                        break;
                    case 1:
                        this.textBoxScore2.Enabled = true;
                        this.textBoxScore2.BackColor = backColor;
                        this.textBoxScore2.ForeColor = fontColor;
                        this.textBoxScore2.Text = quality.ToString();
                        break;
                    case 2:
                        this.textBoxScore3.Enabled = true;
                        this.textBoxScore3.BackColor = backColor;
                        this.textBoxScore3.ForeColor = fontColor;
                        this.textBoxScore3.Text = quality.ToString();
                        break;
                    case 3:
                        this.textBoxScore4.Enabled = true;
                        this.textBoxScore4.BackColor = backColor;
                        this.textBoxScore4.ForeColor = fontColor;
                        this.textBoxScore4.Text = quality.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Clears the controls of last capturing.
        /// </summary>
        private void ClearControlsOfLastCapturing()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.ClearControlsOfLastCapturing));
            }
            else
            {
                this.textBoxScore1.Text = this.textBoxScore2.Text = this.textBoxScore3.Text = this.textBoxScore4.Text = string.Empty;
                this.textBoxScore1.Enabled = this.textBoxScore2.Enabled = this.textBoxScore3.Enabled = this.textBoxScore4.Enabled = false;
                this.flowLayoutPanelCuttedFingers.Controls.Clear();
                this.pictureBoxCurrentCapturing.Image = null;
                this.pictureBoxCurrentCapturing.BackColor = Color.White;
                imageListSeg.Images.Clear();
            }
        }
        /// <summary>
        /// Delegate for AddResultMessage Invoke.
        /// </summary>
        private delegate void AddResultMessageDelegate(string process, string duration, Color color);
        /// <summary>
        /// Adds the result message.
        /// </summary>
        /// <param name="process">The process.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="color">The color.</param>
        private void AddResultMessage(string process, string duration, Color color)
        {
            if (this.InvokeRequired)
            {
                AddResultMessageDelegate addRMDel = this.AddResultMessage;
                this.BeginInvoke(addRMDel, new object[] { process, duration, color });
            }
            else
            {
                ListViewItem listItem = new ListViewItem();
                listItem.ForeColor = color;
                listItem.Text = process;
                listItem.SubItems.Add(duration);
                listViewMessages.Items.Add(listItem);
                listViewMessages.Columns[0].Width = this.listViewMessages.Width - 10;
                listViewMessages.EnsureVisible(listViewMessages.Items.Count - 1);
                listViewMessages.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
        /// <summary>
        /// Delegate for AddStateMessage Invoke.
        /// </summary>
        private delegate void AddStateMessageDelegate(string msg, Color color);
        /// <summary>
        /// Adds the state message.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="color">The color.</param>
        private void AddStateMessage(string text, Color color)
        {
            if (this.InvokeRequired)
            {
                AddStateMessageDelegate addStMesDel = this.AddStateMessage;
                this.BeginInvoke(addStMesDel, new object[] { text, color });
            }
            else
            {
                if (text.Length > 100)
                    text = text.Substring(0, 100) + "...";
            }
        }
        /// <summary>
        /// Closes the splash screen.
        /// </summary>
        private void CloseSplashScreen()
        {
            this.splashScreen.CloseSplashScreen();
            this.splashScreen = null;
        }
        /// <summary>
        /// Shows the splash screen.
        /// </summary>
        private void ShowSplashScreen()
        {
            this.splashScreen = new SplashScreen();
            this.splashScreen.StartPosition = FormStartPosition.CenterScreen;
            this.splashScreen.ShowSplashScreen();
        }
        /// <summary>
        /// Sets the state of the sequence header.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="color">The color.</param>
        private void SetSequenceHeaderState(string msg, Color color)
        {
            this.labelHeaderState.Text = msg;
            if (color == Color.Red)
                this.labelHeaderState.Font = new Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            else
                this.labelHeaderState.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeaderState.ForeColor = color;
        }

        #region Refresh GUI by sequence step
        /// <summary>
        /// Sets the GUI four four two active.
        /// </summary>
        /// <param name="_currentStep">The _current step.</param>
        private void SetGuiFourFourTwoActive(int _currentStep)
        {
            switch (this.currentStep)
            {
                case 1: // Left 4
                    SetGuiLeftFour();
                    break;
                case 2: //Right 4
                    SetGuiRightFour();
                    break;
                case 3: //Thumbs
                    SetGuiLeftRightThumbs();
                    break;
                default:
                    this.AutoStepping = false;
                    break;
            }
        }

        /// <summary>
        /// Sets the GUI four two four active.
        /// </summary>
        /// <param name="_currentStep">The _current step.</param>
        private void SetGuiFourTwoFourActive(int _currentStep)
        {
            switch (this.currentStep)
            {
                case 1: // Left 4
                    this.SetGuiLeftFour();
                    break;
                case 2: //Thumbs
                    this.SetGuiLeftRightThumbs();
                    break;
                case 3: //Right 4
                    this.SetGuiRightFour();
                    break;
                default:
                    this.AutoStepping = false;
                    break;
            }
        }

        /// <summary>
        /// Sets the one rolled active.
        /// </summary>
        /// <param name="_currentStep">The _current step.</param>
        private void SetOneRolledActive(int _currentStep)
        {
            switch (this.currentStep)
            {
                case 1: // 10 Prints
                    this.picBoxCurLeftHand.Image = Properties.Resources.lf10Top;
                    this.picBoxCurRightHand.Image = Properties.Resources.EmptyHand;
                    this.picBoxCurRightHand.Visible = false;
                    this.tableLayoutPanelCurCapturing.SetColumnSpan(this.picBoxCurLeftHand, 2);
                    this.labelHeaderState.Text = string.Empty;// Properties.LF10Demo.TXT_RolledArea;
                    this.SetScannerLeds(SegmentType.OneFinger, LedColor.Red, true);
                    break;
                default:
                    this.AutoStepping = false;
                    break;
            }
        }

        /// <summary>
        /// Sets the GUI left right thumbs.
        /// </summary>
        private void SetGuiLeftRightThumbs()
        {
            this.picBoxCurLeftHand.Image = Properties.Resources.TP_LT;
            this.picBoxCurRightHand.Image = Properties.Resources.TP_RT;
            this.SetSequenceHeaderState(Properties.LF10Demo.TXT_LeftAndRightThumb, Color.Navy);
            this.SetScannerLeds(SegmentType.Thumbs, LedColor.Red, false);
        }
        /// <summary>
        /// Sets the GUI right four.
        /// </summary>
        private void SetGuiRightFour()
        {
            this.picBoxCurLeftHand.Image = Properties.Resources.LeftHandEmpty;
            this.picBoxCurRightHand.Image = Properties.Resources._4Right;
            this.SetSequenceHeaderState(Properties.LF10Demo.TXT_RightFourFingers, Color.Navy);
            this.SetScannerLeds(SegmentType.RightFourPrint, LedColor.Red, false);
        }
        /// <summary>
        /// Sets the GUI left four.
        /// </summary>
        private void SetGuiLeftFour()
        {
            this.picBoxCurLeftHand.Image = Properties.Resources._4Left;
            this.picBoxCurRightHand.Image = Properties.Resources.RightHandEmpty;
            this.SetSequenceHeaderState(Properties.LF10Demo.TXT_LeftFourFingers, Color.Navy);
            this.SetScannerLeds(SegmentType.LeftFourPrint, LedColor.Red, false);
        }

        #endregion

        #endregion

        #region LF10
        /// <summary>
        /// Start scan process of device.
        /// </summary>
        private void ScannerStartScan()
        {

            if (_scanner == null)
                return;

            try
            {
                this.State = ApplicationState.Scan;
                this.validSuccessful = false;
                if (!_scanner.IsCapturing)
                {
                    lock (_scanner)
                    {
                        _scanner.Start();
                    }
                }
                this.RefreshButtonState();
            }
            catch (DeviceException ex)
            {
                this.HandleException(ex);
            }
        }

        private void ScannerStopScan()
        {
            if (_scanner == null)
                return;
            try
            {
                lock (_scanner)
                {
                    _scanner.Stop();
                }
            }
            catch (DeviceException ex)
            {
                this.HandleException(ex);
            }

        }

        /// <summary>
        /// Inits the LF10/ZF10 scanner
        /// </summary>
        private void InitScanner()
        {
            try
            {
                if (_scanner != null)
                {
                    _scanner.Dispose();
                    _scanner = null;
                }

                this.State = ApplicationState.InitScanner;
                DateTime before = DateTime.Now;

                if(DeviceManager.GetAttachedDevices(DeviceIdentity.FG_LF10).Length > 0)
                {
                    _scanner = DeviceManager.GetDevice(DeviceIdentity.FG_LF10);
                }
                else
                {
                    //fall back to ZF10
                    _scanner = DeviceManager.GetDevice(DeviceIdentity.FG_ZF10);
                }
                


                _scanner.CaptureMode = CaptureMode.PREVIEW_IMAGE_AUTO_DETECT;
                this.BindScannerEvents();
                this.AddResultMessage(Properties.LF10Demo.TXT_LF10Intialization, (DateTime.Now - beforeTime).TotalMilliseconds + " ms", Color.Navy);
                this.SetScannerLeds(SegmentType.All, LedColor.Blue, false);
            }
            catch (ThreadAbortException)
            {
                Debug.WriteLine("ScanThread aborted->Ignore");

            }
            catch (Exception ex)
            {
                this.AddStateMessage(ex.Message, Color.Red);
                throw ex;
            }
        }
        /// <summary>
        /// Binds the LF10 events.
        /// </summary>
        private void BindScannerEvents()
        {
            _scanner.OnStart += new OnStart(_scanner_OnStart);
            _scanner.OnStop += new OnStop(_scanner_OnStop);
            _scanner.OnWarning += new OnWarning(_scanner_OnWarning);
            _scanner.OnImage += new OnImage(_scanner_OnImage);
            _scanner.OnDetect += new OnDetect(_scanner_OnDetect);
            _scanner.OnError += new OnError(_scanner_OnError);

        }
        /// <summary>
        /// Sets the finger print quality to led.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="quality">The quality.</param>
        private void SetFingerPrintQualityToLed(int position, int quality)
        {
            this.lf10Validator.IdentifyFingerBySequence(this.activeSequence, this.currentStep, position);
            this.SetScannerLeds(lf10Validator.CurrentFingerType, this.GetQualityLedColor(quality), false);

        }

        enum LedColor
        {
            Off,
            Red,
            Green,
            Blue,
            Yellow
        }

        private void SetScannerLedsLF10(SegmentType segmentType,Dermalog.Imaging.Capturing.Enums.LF10LedColor color, bool disableOther)
        {
            //Leds off       
            int nLed = 0;
            if (disableOther)
            {
                nLed = 0;
                for (int i = 0; i < 11; i++)
                {
                    nLed |= ((int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_LITTLE << i);
                }
                this._scanner.Property[PropertyType.FG_LEDS] = nLed;
            }

            nLed = (int)color;
            switch (segmentType)
            {
                case SegmentType.All:
                    for (int i = 0; i < 10; i++)
                    {
                        nLed |= ((int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_LITTLE << i);
                    }
                    break;

                case SegmentType.Unknown:
                    nLed = 0;
                    break;
                case SegmentType.LeftFourPrint:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_LITTLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_RING;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_MIDDLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_INDEX;
                    break;
                case SegmentType.RightFourPrint:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_LITTLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_RING;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_MIDDLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_INDEX;
                    break;
                case SegmentType.OneFinger:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.ROLL;
                    break;
                case SegmentType.Thumbs:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_THUMB;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_THUMB;
                    break;
                #region 10 Prints
                case SegmentType.LT:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_THUMB;
                    break;
                case SegmentType.LI:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_INDEX;
                    break;
                case SegmentType.LM:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_MIDDLE;
                    break;
                case SegmentType.LR:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_RING;
                    break;
                case SegmentType.LL:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.LEFT_LITTLE;
                    break;
                case SegmentType.RT:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_THUMB;
                    break;
                case SegmentType.RI:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_INDEX;
                    break;
                case SegmentType.RM:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_MIDDLE;
                    break;
                case SegmentType.RR:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_RING;
                    break;
                case SegmentType.RL:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.LF10MultiLed.RIGHT_LITTLE;
                    break;
                #endregion
                default:
                    break;
            }

            if (nLed != 0)
                this._scanner.Property[PropertyType.FG_LEDS] = nLed;
        }


        private void SetScannerLedsZF10(SegmentType segmentType, Dermalog.Imaging.Capturing.Enums.ZF10LedColor color, bool disableOther)
        {
            //Leds off       
            int nLed = 0;
            if (disableOther)
            {
                nLed = 0;
                for (int i = 0; i < 10; i++)
                {
                    nLed |= ((int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_LITTLE << i);
                }
                this._scanner.Property[PropertyType.FG_LEDS] = nLed;
            }

            nLed = (int)color;
            switch (segmentType)
            {
                case SegmentType.All:
                    for (int i = 0; i < 10; i++)
                    {
                        nLed |= ((int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_LITTLE << i);
                    }
                    break;

                case SegmentType.Unknown:
                    nLed = 0;
                    break;
                case SegmentType.LeftFourPrint:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_LITTLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_RING;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_MIDDLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_INDEX;
                    break;
                case SegmentType.RightFourPrint:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_LITTLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_RING;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_MIDDLE;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_INDEX;
                    break;

                case SegmentType.Thumbs:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_THUMB;
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_THUMB;
                    break;
                #region 10 Prints
                case SegmentType.LT:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_THUMB;
                    break;
                case SegmentType.LI:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_INDEX;
                    break;
                case SegmentType.LM:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_MIDDLE;
                    break;
                case SegmentType.LR:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_RING;
                    break;
                case SegmentType.LL:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.LEFT_LITTLE;
                    break;
                case SegmentType.RT:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_THUMB;
                    break;
                case SegmentType.RI:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_INDEX;
                    break;
                case SegmentType.RM:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_MIDDLE;
                    break;
                case SegmentType.RR:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_RING;
                    break;
                case SegmentType.RL:
                    nLed |= (int)Dermalog.Imaging.Capturing.Enums.ZF10MultiLed.RIGHT_LITTLE;
                    break;
                #endregion
                default:
                    break;
            }

            if (nLed != 0)
                this._scanner.Property[PropertyType.FG_LEDS] = nLed;
        }

     
        /// <summary>
        /// Sets the LF10 leds.
        /// </summary>
        /// <param name="segmentType">Type of the segment.</param>
        private void SetScannerLeds(SegmentType segmentType, LedColor color, bool disableOther)
        {
            try
            {
                switch(_scanner.DeviceID)
                {
                    case DeviceIdentity.FG_LF10:
                        Dermalog.Imaging.Capturing.Enums.LF10LedColor lf10color = Dermalog.Imaging.Capturing.Enums.LF10LedColor.OFF;
                        switch(color)
                        {
                            case LedColor.Red:
                                lf10color = Dermalog.Imaging.Capturing.Enums.LF10LedColor.RED;
                                break;
                            case LedColor.Green:
                                lf10color = Dermalog.Imaging.Capturing.Enums.LF10LedColor.GREEN;
                                break;
                            case LedColor.Blue:
                                lf10color = Dermalog.Imaging.Capturing.Enums.LF10LedColor.BLUE;
                                break;
                            case LedColor.Yellow:
                                lf10color = Dermalog.Imaging.Capturing.Enums.LF10LedColor.YELLOW;
                                break;
                        }
                        SetScannerLedsLF10(segmentType, lf10color, disableOther);
                        break;


                    case DeviceIdentity.FG_ZF10:
                        Dermalog.Imaging.Capturing.Enums.ZF10LedColor zf10color = Dermalog.Imaging.Capturing.Enums.ZF10LedColor.OFF;
                        switch (color)
                        {
                            case LedColor.Red:
                                zf10color = Dermalog.Imaging.Capturing.Enums.ZF10LedColor.RED;
                                break;
                            case LedColor.Green:
                                zf10color = Dermalog.Imaging.Capturing.Enums.ZF10LedColor.GREEN;
                                break;                                                        
                            case LedColor.Yellow: 
                                zf10color = Dermalog.Imaging.Capturing.Enums.ZF10LedColor.YELLOW;
                                break;

                            case LedColor.Blue:
                                break;

                        }
                        SetScannerLedsZF10(segmentType, zf10color, disableOther);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        /// <summary>
        /// Lifes the detection.
        /// </summary>
        private void FakeDetection()
        {
            //check Fake/Live detection is enabled     
            if (Properties.Settings.Default.FakeDetectionEnable && this._scanner.Property[PropertyType.FG_FAKE_DETECT] > 0)
            {
                DateTime before = DateTime.Now;
                //Get frame information to check the Liveness or Fake
                LifenessInfo_1 lfInfo = (LifenessInfo_1)this._scanner.GetCurrentFrameInfo(FrameInfoTypes.E_LIFENESS_INFO_1);
                //Possible Fake Finger
                if (lfInfo.Score < Properties.Settings.Default.FakeDetectionThreshold)
                {
                    this.SetSequenceHeaderState("Finger is possible FAKE or misplaced", Color.Red);
                    this.AddResultMessage(Properties.LF10Demo.TXT_LifenessScore + " " + lfInfo.Score.ToString(), String.Empty, Color.Red);
                    this.FakeDetected = true;
                }
                else
                {
                    this.AddResultMessage(Properties.LF10Demo.TXT_LifenessScore + " " + lfInfo.Score.ToString(), String.Empty, Color.Green);
                    this.FakeDetected = false;
                }
                this.AddResultMessage(Properties.LF10Demo.TXT_LifenessDetectionTime, (DateTime.Now - before).Milliseconds + " ms", Color.Navy);
            }
        }

        #endregion

        #region Segmentation and Validation of LF10 Results
        /// <summary>
        /// Adds the finger to tenprint collection.
        /// </summary>
        /// <param name="fpSeg">The fp seg.</param>
        /// <param name="count">The count.</param>
        private void AddFingerToCollection(SegmentedFingerprint fpSeg, uint count)
        {
            lf10Validator.IdentifyFingerBySequence(this.activeSequence, this.currentStep, (int)fpSeg.Position);
            string fingerName = this.lf10Validator.CurrentFingerName;
            LF10ResultItem lf10Result = new LF10ResultItem(this.lf10Validator.CurrentFingerType, this.lf10Validator.CurrentHand, fingerName, fpSeg.Image);

            if (this.lf10Results.ContainsKey(fingerName))
            {
                this.lf10Results.Remove(fingerName);
            }
            this.lf10Results.Add(fingerName, lf10Result);

            this.CreateFingerButton(fpSeg.Image, fingerName);
            this.RefreshButtonState();
        }

        private void AddSlapToCollection(Image slapimage)
        {
            string keyname = this.lf10Validator.CurrentHand.ToString();
            LF10ResultItem lf10Result = new LF10ResultItem(this.lf10Validator.CurrentHand, this.lf10Validator.CurrentHand, keyname, slapimage);
            if (this.lf10Results.ContainsKey(keyname))
            {
                this.lf10Results.Remove(keyname);
            }
            this.lf10Results.Add(keyname, lf10Result);
            //
            //this.CreateFingerButton(slapimage, keyname);
            this.RefreshButtonState();
        }

        /// <summary>
        /// Draws Rectangel arround segment.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="quality">The quality.</param>
        /// <returns>Image with rects.</returns>
        private Image DrawSegments(Image image, Rectangle rect, int quality)
        {
            Color color = GetQualityColor(quality);
            Bitmap bmp = new Bitmap(image);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.DrawRectangle(new Pen(color, 10), rect);
            return bmp;
        }
        /// <summary>
        /// Gets the color of the quality.
        /// </summary>
        /// <param name="quality">The quality.</param>
        /// <returns></returns>
        private LedColor GetQualityLedColor(int quality)
        {
            if (quality >= Properties.Settings.Default.NFIQ2ThresholdGood)
            {
                return LedColor.Green;
            }
            else if (quality <= Properties.Settings.Default.NFIQ2ThresholdPoor)
            {
                return LedColor.Red;
            }
            else
            {
                return LedColor.Yellow;
            }
        }

        private Color GetQualityColor(int quality)
        {
            if (quality >= Properties.Settings.Default.NFIQ2ThresholdGood)
            {
                return Color.Green;

            }
            else if (quality <= Properties.Settings.Default.NFIQ2ThresholdPoor)
            {
                return Color.Red;
            }
            else
            {
                return Color.Orange;
            }
        }


        /// <summary>
        /// Adds the finger to cutted list.
        /// </summary>
        /// <param name="fpSeg">The fp seg.</param>
        /// <param name="fingerName">Name of the finger.</param>
        private void CreateFingerButton(Image image, string fingerName)
        {
            Button fingerB = new Button();
            fingerB.Size = new Size(80, 100);
            fingerB.BackgroundImage = image;
            fingerB.Text = fingerName;
            fingerB.ForeColor = Color.Navy;
            fingerB.TextAlign = ContentAlignment.BottomCenter;
            fingerB.BackgroundImageLayout = ImageLayout.Zoom;
            fingerB.Click += new EventHandler(fingerB_Click);

            this.flowLayoutPanelCuttedFingers.Controls.Add(fingerB);
        }
        private void fingerB_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            FingerView fingerView = new FingerView(button.BackgroundImage, button.Text);
            fingerView.StartPosition = FormStartPosition.CenterParent;
            fingerView.ShowDialog(this);
        }
        /// <summary>
        /// Validations the failed.
        /// </summary>
        private void ValidationFailed()
        {
            try
            {
                if (this.State != ApplicationState.DeviceError)
                {
                    this.State = ApplicationState.ValidationFailed;
                    ScannerStopScan();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        /// <summary>
        /// Waits the of LF10 validation.
        /// </summary>
        /// <returns></returns>
        private bool WaitOfScannerValidation()
        {
            while (!waitOfValidation.WaitOne(1000, false))
            {
                Debug.WriteLine("Wait LF10/ZF10 result validation!");
                if (this.State == ApplicationState.DeviceError)
                    break;
            }

            return this.validSuccessful;
        }
        #endregion
        #endregion

        #region Event Handling
        #region LF10 Events
        /// <summary>
        /// Handles the OnDetect event of the _scanner control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Dermalog.Imaging.Capturing.DetectEventArgs"/> instance containing the event data.</param>
        private void _scanner_OnDetect(object sender, DetectEventArgs e)
        {
            try
            {
                this._scanner.Freeze(true);

                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new OnDetect(_scanner_OnDetect), new object[] { sender, e });
                }
                else
                {
                    this.AddResultMessage(Properties.LF10Demo.TXT_FingerDetection, (DateTime.Now - beforeTime).TotalMilliseconds + " ms", Color.Navy);
                    this.pictureBoxCurrentCapturing.Image = e.Image.Clone() as Image;
                    this.FakeDetection();
                    StartSegmentation(e.Image, e.ImageData);

                    this._scanner.Freeze(false);
                }
            }
            catch (DeviceException)
            {
                //Ignore DeviceException
            }
        }
        /// <summary>
        /// Handles the OnImage event of the _scanner control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Dermalog.Imaging.Capturing.ImageEventArgs"/> instance containing the event data.</param>
        private void _scanner_OnImage(object sender, ImageEventArgs e)
        {
            if ((sender as Device).IsCapturing)
            {
                if (this.InvokeRequired)
                {
                    OnImage onImage = new OnImage(_scanner_OnImage);
                    this.BeginInvoke(onImage, new object[] { sender, e });
                }
                else
                {
                    try
                    {
                        if (this.AutoStepping || this.activeSequence == ActiveSequence.OneRolled)
                            this.pictureBoxCurrentCapturing.Image = e.Image;
                    }
                    catch (System.Exception)
                    {

                    }
                    this.beforeTime = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Handles the OnWarning event of the _scanner control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Dermalog.Imaging.Capturing.WarningEventArgs"/> instance containing the event data.</param>
        private void _scanner_OnWarning(object sender, WarningEventArgs e)
        {

        }
        /// <summary>
        /// _LF10s the scanner_ on stop.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void _scanner_OnStop(object sender, DeviceEventBaseArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new OnStop(_scanner_OnStop), new object[] { sender, e });
            }
            else
            {
                this.pictureBoxCurrentCapturing.BackColor = Color.White;
            }
        }
        /// <summary>
        /// _LF10s the scanner_ on start.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void _scanner_OnStart(object sender, DeviceEventBaseArgs e)
        {
            if (this.InvokeRequired)
            {
                OnStart onStart = new OnStart(_scanner_OnStart);
                this.BeginInvoke(onStart, new object[] { sender, e });
            }
            else
            {
                System.Media.SystemSounds.Asterisk.Play();
                pictureBoxCurrentCapturing.BackColor = Color.White;
            }

        }
        /// <summary>
        /// Handles the OnError event of the _scanner control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Dermalog.Imaging.Capturing.ErrorEventArgs"/> instance containing the event data.</param>
        private void _scanner_OnError(object sender, Dermalog.Imaging.Capturing.ErrorEventArgs e)
        {

            if (this.InvokeRequired)
            {
                OnError onError = new OnError(_scanner_OnError);
                this.BeginInvoke(onError, new object[] { sender, e });
            }
            else
            {
                MessageBox.Show(this, e.Error, "Scanner OnError");
                AbortSequence();
            }
        }
        #endregion

        #region Gui

        private void StartSequence()
        {
            AbortSequence();
            this.Clear();
            //restart Sequence
            this.radioButton442.Checked = true;
            this.activeSequence = ActiveSequence.FourFourTwo;
            this.state = ApplicationState.Idle;

        }
        /// <summary>
        /// Buttons the stop click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonStopClick(object sender, EventArgs e)
        {
            AbortSequence();
        }

        /// <summary>
        /// Radioes the button sequence changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RadioButtonSequenceChanged(object sender, EventArgs e)
        {
            RadioButton radioB = sender as RadioButton;
            if (radioB.Checked)
            {
                this.AbortSequence();
                if (radioB.Equals(radioButton1Flat))
                    this._scanner.CaptureMode = CaptureMode.ROLLED_FINGER;
                else
                    this._scanner.CaptureMode = CaptureMode.PREVIEW_IMAGE_AUTO_DETECT;

                this.activeSequence = (ActiveSequence)Enum.Parse(typeof(ActiveSequence), radioB.Tag as string);

                //this.Scan();
                //this.RefreshGuiSteps();              
            }
        }

        private void ToolStripMenuItemAssemblyInfoClick(object sender, EventArgs e)
        {
            AssemblyForm frm = new AssemblyForm();
            frm.ShowDialog(this);
        }
        /// <summary>
        /// Tools the strip menu item clear tenprints click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripMenuItemClearTenprintsClick(object sender, EventArgs e)
        {
            if (this.lf10Results != null && this.lf10Results.Count > 0)
            {
                lock (lf10Results)
                {
                    lf10Results.Clear();
                }
                this.RefreshButtonState();
            }
        }
        /// <summary>
        /// Tools the strip menu item clear messages click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolStripMenuItemClearMessagesClick(object sender, EventArgs e)
        {
            this.listViewMessages.Items.Clear();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_scanner != null)
            {
                ScannerStopScan();
                _scanner.Dispose();
                _scanner = null;
            }

            if (_fpSegmentation != null)
            {
                _fpSegmentation.Dispose();
                _fpSegmentation = null;
            }
        }
        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();

                _scanner.Property[PropertyType.FG_AUTO_CAPTURE_BEEP] = Properties.Settings.Default.FG_AUTO_CAPTURE_BEEP;

                this.SetScannerLeds(SegmentType.All, LedColor.Off, true);

                this.RefreshGuiSteps();
                //default                
                this._scanner.Property[PropertyType.FG_FAKE_DETECT] = 0;
                //set the lifeness detection
                if (activeSequence != ActiveSequence.OneRolled)
                {
                    if (Properties.Settings.Default.FakeDetectionEnable)
                    {
                        this._scanner.Property[PropertyType.FG_FAKE_DETECT] = 1;
                    }
                }
                if (ScanThread == null || !ScanThread.IsAlive)
                {
                    ScanThread = new Thread(new ThreadStart(this.Scan));
                    ScanThread.IsBackground = true;
                    ScanThread.Name = "ScanThread";
                    ScanThread.Start();
                }
                else
                {
                    //ScanThread.Abort();
                    AbortSequence();
                }
            }
            catch (ThreadAbortException)
            {
                Debug.WriteLine("ScanThread Aborted");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AbortSequence();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.AbortSequence();
            this.Close();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (this.State == ApplicationState.Idle)
            {
                OptionForm optForm = new OptionForm(this);
                optForm.StartPosition = FormStartPosition.CenterParent;
                optForm.ShowDialog(this);
            }
        }

        private void buttonSuccResults_Click(object sender, EventArgs e)
        {
            ResultsView resultsView = new ResultsView();
            resultsView.StartPosition = FormStartPosition.CenterParent;
            resultsView.Lf10Results = this.lf10Results;
            resultsView.ShowDialog(this);
        }

        private void buttonSuccSave_Click(object sender, EventArgs e)
        {
            if (lf10Results == null)
                return;

            FolderBrowserDialog dia = new FolderBrowserDialog();
            dia.Description = "Save images";

            DialogResult res = dia.ShowDialog();

            if (res != DialogResult.OK)
                return;

            try
            {

                //save images
                foreach (LF10ResultItem item in lf10Results.Values)
                {
                    Encoder encoder;
                    String filename = dia.SelectedPath + "\\" + item.FingerName;

                    switch (item.FingerType)
                    {
                        case SegmentType.LeftFourPrint:
                        case SegmentType.RightFourPrint:
                        case SegmentType.Thumbs:
                        case SegmentType.Unknown:
                            //save detect images as png
                            encoder = new EncoderPng();
                            filename += ".png";
                            break;

                        default:
                            //save segmented finger prints as wsq                            
                            encoder = new EncoderWsq();
                            filename += ".wsq";
                            break;
                    }

                    using (MemoryStream stream = new MemoryStream())
                    {
                        item.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        using (Decoder decoder = new Decoder())
                        {                            
                            using (RawImage rawImg = decoder.Decode(stream.GetBuffer()) )
                            //using (RawImage rawImg = RawImageHelperForms.FromBitmap(item.Image as Bitmap))
                            {
                                //convert to output format
                                byte[] outData = encoder.Encode(rawImg);
                                encoder.Dispose();

                                //save to disk
                                File.WriteAllBytes(filename, outData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving images: " + ex.Message);
            }

        }

        private void buttonPrevCapturing_Click(object sender, EventArgs e)
        {
            if (this.AutoStepping)
                return;

            if (this.currentStep > 1)
            {
                this.currentStep--;

                LF10ResultItem resI = null;
                foreach (LF10ResultItem item in lf10Results.Values)
                {
                    resI = item;
                }
                if (resI != null)
                {
                    List<LF10ResultItem> tmpList = new List<LF10ResultItem>();
                    foreach (LF10ResultItem item in lf10Results.Values)
                    {
                        if (resI.HandType.Equals(item.HandType))
                            tmpList.Add(item);
                    }
                    foreach (LF10ResultItem item in tmpList)
                    {
                        lf10Results.Remove(item.FingerName);
                    }
                }
                RefreshGuiSteps();
            }
            this.pictureBoxCurrentCapturing.Image = null;
        }

        private void buttonNextCapturing_Click(object sender, EventArgs e)
        {
            if (this.AutoStepping)
                return;

            if (this.currentStep < this.maxSequenceSteps)
            {
                this.currentStep++;
                RefreshGuiSteps();
                this.ClearControlsOfLastCapturing();
                this.pictureBoxCurrentCapturing.BackColor = Color.White;
                if (this._scanner.IsCapturing)
                    this.State = ApplicationState.Scan;
            }
            else
            {
                this.AfterSequenceDone();
            }
        }
    }

}
