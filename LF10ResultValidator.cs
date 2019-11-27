using Dermalog.AFIS.FourprintSegmentation;

namespace biometrico
{
    /// <summary>
    /// Class for indefication and validation of lf10 results.
    /// </summary>
    public class LF10ResultValidator
    {
        #region Fields
        private string validError = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the current finger.
        /// </summary>
        /// <value>The name of the current finger.</value>
        public string CurrentFingerName { get; set; }
        /// <summary>
        /// Gets or sets the type of the current finger.
        /// </summary>
        /// <value>The type of the current finger.</value>
        public SegmentType CurrentFingerType { get; set; }
        /// <summary>
        /// Gets or sets the current hand.
        /// </summary>
        /// <value>The current hand.</value>
        public SegmentType CurrentHand { get; set; }
        /// <summary>
        /// Gets or sets the current sequence.
        /// </summary>
        /// <value>The current sequence.</value>
        private ActiveSequence CurrentSequence { get; set; }
        /// <summary>
        /// Gets the valid error.
        /// </summary>
        /// <value>The valid error.</value>
        public string ValidError
        {
            get { return validError; }
        }
        #endregion

        #region Public Methodes
        /// <summary>
        /// Validates the capturing sequence.
        /// </summary>
        /// <param name="finger">The finger.</param>
        /// <param name="activeSequence">The active sequence.</param>
        /// <param name="currentStep">The current step.</param>
        /// <returns></returns>
        public bool ValidateCapturingSequence(MainForm.SegmentedFingerprintImage[] segments, ActiveSequence activeSequence, int currentStep, bool fakeDetected = false)
        {
            bool valid = false;
            this.validError = string.Empty;


            if (fakeDetected)
            {
                valid = false;
                this.validError = "Finger is possible FAKE or misplaced";
                return valid;
            }

            HandPositions hand = segments[0].fpSeg.Hand;


            switch (activeSequence)
            {
                case ActiveSequence.OneRolled:
                    valid = true;
                    break;

                case ActiveSequence.FourTwoFour:
                    #region Check FourTwoFour sequence
                    if (currentStep == 1)
                    {
                        if (hand == HandPositions.Left)
                        {
                            if (segments.Length == 4)
                            {
                                valid = true;
                            }else
                            {
                                this.validError = "Four finger expected!";
                            }                            
                        }
                        else
                        {
                            this.validError = "Left Hand expected for this Sequence!";                           
                        }
                    }
                    else if (currentStep == 2)
                    {
                        if (hand == HandPositions.Thumbs)
                        {
                            valid = true;
                        }
                        else
                        {
                            this.validError = "Thumbs expected for this Sequence!";                           
                        }
                    }
                    else if (currentStep == 3)
                    {
                        if (hand == HandPositions.Right)
                        {
                            if (segments.Length == 4)
                            {
                                valid = true;
                            }
                            else
                            {
                                this.validError = "Four finger expected!";
                            }
                        }
                        else
                        {
                            this.validError = "Right Hand expected for this Sequence!";
                        }
                    }
                    #endregion
                    break;
                case ActiveSequence.FourFourTwo:
                    #region Check FourFourTwo sequence
                    if (currentStep == 1)
                    {
                        if (hand == HandPositions.Left)
                        {
                            if (segments.Length == 4)
                            {
                                valid = true;
                            }
                            else
                            {
                                this.validError = "Four finger expected!";
                            }
                        }
                        else
                        {
                            this.validError = "Left Hand expected for this Sequence!";
                        }
                    }
                    else if (currentStep == 2)
                    {
                        if (hand == HandPositions.Right)
                        {
                            if (segments.Length == 4)
                            {
                                valid = true;
                            }
                            else
                            {
                                this.validError = "Four finger expected!";
                            }
                        }
                        else
                        {
                            this.validError = "Right Hand expected for this Sequence!";
                        }
                    }
                    else if (currentStep == 3)
                    {
                        if (hand == HandPositions.Thumbs)
                        {
                            valid = true;
                        }
                        else
                        {
                            this.validError = "Thumbs expected for this Sequence!";
                        }
                    }
                    #endregion
                    break;
                default:
                    this.validError = "Capturing failed, please try it again.";
                    break;
            }
            if (/*string.IsNullOrEmpty(this.validError)*/valid)
                this.validError = "Validation Error!";
            return valid;
        }
        /// <summary>
        /// Identifies the finger by Fourprintsegmentation data.
        /// </summary>
        /// <param name="handPositions">The hand positions.</param>
        /// <param name="fingerPosition">The finger position.</param>
        public void IdentifyFinger(HandPositions handPositions, uint fingerPosition)
        {
            this.CurrentFingerName = string.Empty;
            this.CurrentFingerType = SegmentType.Unknown;
            switch (handPositions)
            {
                case HandPositions.Left:
                    this.CurrentHand = SegmentType.LeftFourPrint;
                    switch (fingerPosition)
                    {
                        case 1:
                            this.CurrentFingerName = handPositions.ToString() + " Little";
                            this.CurrentFingerType = SegmentType.LL;
                            break;
                        case 2:
                            this.CurrentFingerName = handPositions.ToString() + " Ring";
                            this.CurrentFingerType = SegmentType.LR;
                            break;
                        case 3:
                            this.CurrentFingerName = handPositions.ToString() + " Middle";
                            this.CurrentFingerType = SegmentType.LM;
                            break;
                        case 4:
                            this.CurrentFingerName = handPositions.ToString() + " Index";
                            this.CurrentFingerType = SegmentType.LI;
                            break;
                        default:
                            break;
                    }
                    break;
                case HandPositions.Right:
                    this.CurrentHand = SegmentType.RightFourPrint;
                    switch (fingerPosition)
                    {
                        case 1:
                            this.CurrentFingerName = handPositions.ToString() + " Index";
                            this.CurrentFingerType = SegmentType.RI;
                            break;
                        case 2:
                            this.CurrentFingerName = handPositions.ToString() + " Middle";
                            this.CurrentFingerType = SegmentType.RM;
                            break;
                        case 3:
                            this.CurrentFingerName = handPositions.ToString() + " Ring";
                            this.CurrentFingerType = SegmentType.RR;
                            break;
                        case 4:
                            this.CurrentFingerName = handPositions.ToString() + " Little";
                            this.CurrentFingerType = SegmentType.RL;
                            break;
                        default:
                            break;
                    }
                    break;
                case HandPositions.Thumbs:
                    this.CurrentHand = SegmentType.Thumbs;
                    switch (fingerPosition)
                    {
                        case 1:
                            this.CurrentFingerName = "Left Thumb";
                            this.CurrentFingerType = SegmentType.LT;
                            break;
                        case 2:
                            this.CurrentFingerName = "Right Thumb";
                            this.CurrentFingerType = SegmentType.RT;
                            break;
                        default:
                            break;
                    }
                    break;
                case HandPositions.Unknown:

                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Identifies the finger by sequence.
        /// </summary>
        /// <param name="activeSequence">The active sequence.</param>
        /// <param name="sequenceStep">The sequence step.</param>
        /// <param name="fingerPosition">The finger position.</param>
        public void IdentifyFingerBySequence(ActiveSequence activeSequence, int sequenceStep, int fingerPosition)
        {
            this.CurrentFingerName = string.Empty;
            this.CurrentFingerType = SegmentType.Unknown;
            uint fingerPos = (uint)fingerPosition;

            switch (activeSequence)
            {
                case ActiveSequence.OneRolled:
                    break;
                case ActiveSequence.FourTwoFour:
                    if (sequenceStep == 1)
                        this.IdentifyFinger(HandPositions.Left, fingerPos);
                    else if (sequenceStep == 2)
                        this.IdentifyFinger(HandPositions.Thumbs, fingerPos);
                    else if (sequenceStep == 3)
                        this.IdentifyFinger(HandPositions.Right, fingerPos);
                    break;
                case ActiveSequence.FourFourTwo:
                    if (sequenceStep == 1)
                        this.IdentifyFinger(HandPositions.Left, fingerPos);
                    else if (sequenceStep == 2)
                        this.IdentifyFinger(HandPositions.Right, fingerPos);
                    else if (sequenceStep == 3)
                        this.IdentifyFinger(HandPositions.Thumbs, fingerPos);
                    break;
            }
        }

        #endregion
    }
}
