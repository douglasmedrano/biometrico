using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LF10Demo
{
  /// <summary>
  /// SplashScreen with current states of loading process.
  /// </summary>
  public partial class SplashScreen : Form
  {
    private ApplicationState state= ApplicationState.Init;

    /// <summary>
    /// Initializes a new instance of the <see cref="SplashScreen"/> class.
    /// </summary>
    public SplashScreen()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Gets or sets the state of the loading process.
    /// </summary>
    /// <value>The state.</value>
    public ApplicationState State
    {
      get { return state; }
      set
      {
        this.SetLoadingText(value);
      }
    }

    /// <summary>
    /// Shows the splash screen.
    /// </summary>
    public void ShowSplashScreen()
    {
      //Thread splashThread = new Thread(new ThreadStart(delegate
      //{
      //  Application.Run(this);
      //}));
      Thread splashThread = new Thread(new ThreadStart(this.ApplicationRunVBCompliant));
      splashThread.IsBackground = true;
      splashThread.Start();
    }
    /// <summary>
    /// Closes the splash screen.
    /// </summary>
    public void CloseSplashScreen()
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(CloseSplashScreen));
      }
      else
      {
        this.Close();
        this.Dispose();
      }
    }

    /// <summary>
    /// Delegate for SetLoadingText
    /// </summary>
    delegate void SetLoadingTextDelegate(ApplicationState state);
    /// <summary>
    /// Applications the run VB compliant.
    /// </summary>
    private void ApplicationRunVBCompliant()
    {
      Application.Run(this);
    }
    /// <summary>
    /// Sets the loading text.
    /// </summary>
    /// <param name="state">The state.</param>
    private void SetLoadingText(ApplicationState state)
    {
      if (this.InvokeRequired)
      {
        SetLoadingTextDelegate setLTD = this.SetLoadingText;
        this.BeginInvoke(setLTD, new object[]{state});
      }
      else
      {
          switch (state)
          {
              case ApplicationState.Init:
                  this.label1.Text = "State : Initialization Graphic User Interface...";
                  break;

              case ApplicationState.InitScanner:
                  this.label1.Text = "State : Initialization of LF10 / ZF10 Scanner...";
                  break;

              case ApplicationState.Init4PSegmentation:
                   this.label1.Text = "State : Initialization of FourPrintSegmentation Component...";
                  break;

          }
      }
    }  
  }
}
