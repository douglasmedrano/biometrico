
namespace biometrico
{
  using System.Windows.Forms;
  /// <summary>
  /// Inheritance TableLayoutPanel with enabled DoubleBuffered Property.
  /// </summary>
  public class TableLayoutPanelDoubleBuffered:TableLayoutPanel
  {
    public TableLayoutPanelDoubleBuffered()
      : base()
    {
      this.DoubleBuffered = true;
    }
  }
}
