namespace LF10Demo
{
  using System.Windows.Forms;
  /// <summary>
  /// Inheritance Picturebox with enabled DoubleBuffered Property.
  /// </summary>
  public class PictureBoxDoubleBuffered:PictureBox
  {
    public PictureBoxDoubleBuffered():base()
    {
      this.DoubleBuffered = true;
    }
  }
}
