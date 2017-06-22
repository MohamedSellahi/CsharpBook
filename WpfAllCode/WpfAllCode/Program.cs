// simple wpf application written without xaml 
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAllCode {
  // we need to define a single class the application istelf and
  // the main window 

  class Program : Application {
    [STAThread]
    static void Main(string[] args) {
      Program app = new Program();
         app.Startup += App_Startup;
         app.Exit += App_Exit;
         var wnds = app.Windows;
         app.Run();         
    }

    /* Remarks: On closing the main window: by calling Close() method
     * this chain of eents with be triggered in this order:
     *  Closing --> Exit --> Closed
     */

    private static void App_Exit(object sender, ExitEventArgs e) {
      MessageBox.Show("App has exited ");
    }


    // Application startUp code 
    private static void App_Startup(object sender, StartupEventArgs e) {
      // Check the incoming command-line argumetns and see if ther 
      // specidied a flag for /GODMODE
      // add an entry to Properties property of the current app 
      Application.Current.Properties["GodMode"] = false;

      foreach (string arg in e.Args) {
        if (arg.ToLower() == "/godmode") {
          Application.Current.Properties["GodMode"] = true;
          break;
        }
      }


      MainWindow wnd = new MainWindow("My Better WPF App", 200, 300);
      wnd.Show();

      ////Create a window and set somme basic properties 
      //Window mainWindow = new Window() {
      //  Title = "My first WPF App",
      //  Height = 200,
      //  Width = 300,
      //  WindowStartupLocation = WindowStartupLocation.CenterScreen
      //};
      //mainWindow.Show();

    }

  }
}
