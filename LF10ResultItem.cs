using System.Drawing;

namespace LF10Demo
{
  /// <summary>
  /// Segment type like finger or type of cupturing like right four prints...
  /// </summary>
  public enum SegmentType
  {
    All,
    /// <summary>
    /// Unknown
    /// </summary>
    Unknown,
    /// <summary>
    /// LeftFourPrint
    /// </summary>
    LeftFourPrint,
    /// <summary>
    /// RightFourPrint
    /// </summary>
    RightFourPrint,
    /// <summary>
    /// OneFinger
    /// </summary>
    OneFinger,
    /// <summary>
    /// Thumbs
    /// </summary>
    Thumbs,
    LL, LR, LM, LI, LT,
    RL, RR, RM, RI, RT
  }
  /// <summary>
  /// Simple Class for finger segments.
  /// </summary>
  public class LF10ResultItem
  {
    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="LF10ResultItem"/> class.
    /// </summary>
    public LF10ResultItem()
    {
      this.FingerType = SegmentType.Unknown;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="LF10ResultItem"/> class.
    /// </summary>
    /// <param name="fingerType">Type of the finger.</param>
    /// <param name="hand">The hand.</param>
    /// <param name="name">The name.</param>
    /// <param name="image">The image.</param>
    public LF10ResultItem(SegmentType fingerType, SegmentType hand,string name, Image image)
    {
      this.FingerType = fingerType;
      this.HandType = hand;
      this.FingerName = name;
      this.Image = image;
    } 
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the type of the finger.
    /// </summary>
    /// <value>The figner type.</value>
    public SegmentType FingerType { get; set; }
    /// <summary>
    /// Gets or sets the type of the hand.
    /// </summary>
    /// <value>The type of the hand.</value>
    public SegmentType HandType { get; set; }
    /// <summary>
    /// Gets or sets the name of the finger.
    /// </summary>
    /// <value>The name of the finger.</value>
    public string FingerName { get; set; }
    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    /// <value>The image.</value>
    public Image Image { get; set; } 
    #endregion
 }
}
