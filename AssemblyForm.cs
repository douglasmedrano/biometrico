using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace LF10Demo
{
  /// <summary>
  /// This Form show loaded assemblys of this application.
  /// </summary>
	public partial class AssemblyForm : Form
	{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssemblyForm"/> class.
    /// </summary>
		public AssemblyForm()
		{
			InitializeComponent();
		}

    /// <summary>
    /// Handles the Load event of the AssemblyForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void AssemblyForm_Load(object sender, EventArgs e)
		{
			try
			{
				Process current = Process.GetCurrentProcess();
				DataTable dt = new DataTable("LoadedAssembly");
				dt.Columns.Add("Assembly");
				dt.Columns.Add("version");
				foreach (ProcessModule module in current.Modules)
				{
					if (module.ModuleName.ToLower().Contains("dermalog") || module.ModuleName.ToLower().Contains("LF10"))
					{
						DataRow dr = dt.NewRow();
						dr["Assembly"] = module.ModuleName;
						dr["version"] = module.FileVersionInfo.FileVersion;
						dt.Rows.Add(dr);
					}
				}
				dt.AcceptChanges();
				assemblyGridView.DataSource = dt;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
