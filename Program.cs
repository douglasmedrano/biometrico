using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace LF10Demo
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      try
      {
        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.ToString());     
      }
    }
    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      Debug.WriteLine("Unrecovered Application Error: " + e.Exception + "\n;" + e.Exception.StackTrace);
      Trace.WriteLine("Unrecovered Application Error: " + e.Exception);     
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      Exception exp = e.ExceptionObject as Exception;
      if (exp == null)
        exp = new ApplicationException("CurrentDomain_UnhandledException");
      Debug.WriteLine("CurrentDomain_UnhandledException Application Error: " + exp + "\n;" + exp.StackTrace);
      Trace.WriteLine("Unrecovered Application Error: " + exp);      
    }
  }
}
