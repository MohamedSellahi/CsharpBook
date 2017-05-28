using System;
using System.Windows;
using System.Windows.Controls; 


namespace WpfAllCode {
  class MainWindow: Window {
    // Add a UI Element 
    private Button btnExitApp = new Button();

    public MainWindow(string windowTitle, int height, int width) {
      // Set the content of this class to a single button 
      this.Content = btnExitApp;
      // Configure the button 
      btnExitApp.Click += BtnExitApp_Click;
      btnExitApp.Content = "Exit Application";
      btnExitApp.Height = 25;
      btnExitApp.Width = 100;
      

      this.Title = windowTitle;
      this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      this.Height = height;
      this.Width = width;

      // handeling closing 
      this.Closing += MainWindow_Closing;
      this.Closed += MainWindow_Closed;

      // Capturing mouse mouvements 
      this.MouseMove += MainWindow_MouseMove;

      // Intercepting keyboard events 
      this.KeyDown += MainWindow_KeyDown;
      //this.KeyUp += MainWindow_KeyUp;

      
    }

    private void MainWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e) {
      this.btnExitApp.Content = "Released";
    }

    private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
      btnExitApp.Content = e.Key.ToString();
    }

    private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e) {
      // get the mouse position relative to an UI Element
      this.Title = e.GetPosition(this.btnExitApp).ToString();
    }

    private void MainWindow_Closed(object sender, EventArgs e) {
      MessageBox.Show("See ya!");
    }

    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
      // see if the user really wants to shut down this window
      string msg = "Do you want to close without saving ?";
      MessageBoxResult result = MessageBox.Show(msg, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
      if (result == MessageBoxResult.No) {
        // if user does not want to clase 
        e.Cancel = true;
      }

    }

    private void BtnExitApp_Click(object sender, RoutedEventArgs e) {
      // Close the current window
      // test if the user has acctivated "godmod"
      if ((bool)Application.Current.Properties["GodMode"]) {
        MessageBox.Show("Cheater! ");
      }
      this.Close();
    }
  }
}
