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
using System.Windows.Media.Animation;

namespace GrowLabelFont {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    
    public MainWindow() {
      InitializeComponent();
      
    }
       

    private void lbl_Loaded(object sender, RoutedEventArgs e) {
      //
      DoubleAnimation dblAnim = new DoubleAnimation();
      dblAnim.From = 12;
      dblAnim.To = 100;
      dblAnim.AutoReverse = true;
      dblAnim.Duration = new Duration(new TimeSpan(0, 0, 4));
      dblAnim.RepeatBehavior = RepeatBehavior.Forever;
      this.lbl.BeginAnimation(Label.FontSizeProperty, dblAnim);
      
    }

    private void btnCallTestWindow_Click(object sender, RoutedEventArgs e) {
      TestWindow win = new TestWindow();
      win.Owner = this;
      win.ShowDialog();
    }


  }
}
