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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStyles {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      // fill the list box with all the button styles 
      lstStyles.Items.Add("GrowingButtonStyle");
      lstStyles.Items.Add("TiltButton");
      lstStyles.Items.Add("BigGreenButton");
      lstStyles.Items.Add("BasicControlStyle");


    }

    private void lstStyles_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      Style currStyle = (Style)TryFindResource(lstStyles.SelectedValue);

      if (currStyle != null) {
        btnStyle.Style = currStyle; 
      }
    }
  }
}
