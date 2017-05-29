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

namespace WpfAllTests {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      //LinearGradientBrush lbr = new LinearGradientBrush(Colors.DarkGreen, Colors.LightGreen, 45);
      //btn.Background = lbr;
      //btn.Foreground = new SolidColorBrush(Colors.Yellow);
      LinearGradientBrush lgr = new LinearGradientBrush();
      Canvas cnvs = new Canvas();
      Label lb; 
      
     
    }
  }
}
