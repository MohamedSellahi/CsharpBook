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

namespace WpfControlsAndAPI {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();

      // default value 
      this.myCanvas.EditingMode = InkCanvasEditingMode.Ink;
      this.inkRadio.IsChecked = true;
      this.comboColors.SelectedIndex = 0;
      
    }

    private void inkRadio_Click(object sender, RoutedEventArgs e) {
      // Based on which radio button, place canvas in unique mode of operation 
      switch ((sender as RadioButton).Content.ToString()) {
        case "Ink Mode!":
          this.myCanvas.EditingMode = InkCanvasEditingMode.Ink;
          break;
        case "Erase Mode!":
          this.myCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
          break;
        case "Select Mode!":
          this.myCanvas.EditingMode = InkCanvasEditingMode.Select;
          break;
      }

    }

    private void ColorChanged(object sender, SelectionChangedEventArgs e) {
      // Get the selectted value in the combo box 
      string colorInUse = (this.comboColors.SelectedItem as ComboBoxItem).Content.ToString();
      this.myCanvas.DefaultDrawingAttributes.Color = (Color)(ColorConverter.ConvertFromString(colorInUse));
    }
  }
}
