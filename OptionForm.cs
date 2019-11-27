using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace biometrico
{
    /// <summary>
    /// Simple options form.
    /// </summary>
    public partial class OptionForm : Form
    {
        /// <summary>
        /// Main form reference.
        /// </summary>
        private MainForm mainForm;
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionForm"/> class.
        /// </summary>
        /// <param name="mainForm">The main form.</param>
        public OptionForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.LoadSettings();
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            this.numericUpDownNQGood.Value = Properties.Settings.Default.NFIQ2ThresholdGood;
            this.numericUpDownNQPoor.Value = Properties.Settings.Default.NFIQ2ThresholdPoor;            
            this.checkBoxAutoStepping.Checked = Properties.Settings.Default.AutoStepping;
            this.checkBoxShowQuality.Checked = Properties.Settings.Default.ShowQuality;
            this.checkBoxFakeDetection.Checked = Properties.Settings.Default.FakeDetectionEnable;
            this.numericUpDownFakeThreshold.Value = Properties.Settings.Default.FakeDetectionThreshold;
            this.checkBoxAutoCaptureBeep.Checked = Properties.Settings.Default.FG_AUTO_CAPTURE_BEEP != 0;
        }
        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings.Default.NFIQ2ThresholdGood = (int)this.numericUpDownNQGood.Value;
            Properties.Settings.Default.NFIQ2ThresholdPoor = (int)this.numericUpDownNQPoor.Value;
            Properties.Settings.Default.FakeDetectionEnable = this.checkBoxFakeDetection.Checked;
            Properties.Settings.Default.FakeDetectionThreshold = (int)this.numericUpDownFakeThreshold.Value;
            Properties.Settings.Default.ShowQuality = this.checkBoxShowQuality.Checked;
            Properties.Settings.Default.AutoStepping = this.checkBoxAutoStepping.Checked;
            Properties.Settings.Default.FG_AUTO_CAPTURE_BEEP = this.checkBoxAutoCaptureBeep.Checked ? 1 : 0;
            this.mainForm.AutoStepping = this.checkBoxAutoStepping.Checked;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// Handles the Click event of the buttonOptionCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonOptionCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handles the Click event of the buttonOptionOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonOptionOk_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
            this.Close();
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
