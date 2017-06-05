using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectResourcesApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    private RadialGradientBrush _previousBrush = null;
    public MainWindow() {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, RoutedEventArgs e) {
      // Get the brush an dmake a change 

      //RadialGradientBrush rb = (RadialGradientBrush)(App.Current.Resources["myButtonBrush"]);
      RadialGradientBrush rb = (RadialGradientBrush)(this.Resources["myButtonBrush"]);
      rb.GradientStops[1] = new GradientStop(Colors.Black, 0.0);

      // put a totally new brush 
      //this.Resources["myButtonBrush"] = new SolidColorBrush(Colors.Red);
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      _previousBrush = (RadialGradientBrush)(this.Resources["myButtonBrush"]); ;
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e) {
      //this.Resources["myButtonBrush"] = _previousBrush;
      //RadialGradientBrush rb = (RadialGradientBrush)(this.Resources["myButtonBrush"]);
      //rb.GradientStops[1] = new GradientStop((Color)ColorConverter.ConvertFromString("#FF829CEB"), 1);
      TestWindow win = new TestWindow();
      win.Owner = this;
      win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      win.ShowDialog();


    }
  }
}
