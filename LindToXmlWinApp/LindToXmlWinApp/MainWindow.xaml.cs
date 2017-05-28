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

namespace LindToXmlWinApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
      
      
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      // display current XML inventory i textBox control 
      InventoryTextBlock.Text = LinqToXmlObjectModel.GetXmlInventory().ToString(); 
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e) {
      // add new item to doc 
      LinqToXmlObjectModel.InsertNewElement(txtMaker.Text, txtColor.Text, txtPetName.Text);
      // display the curren XML document 
      InventoryTextBlock.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();

    }

   

    private void SearchItembtn_Click(object sender, RoutedEventArgs e) {
      LinqToXmlObjectModel.LookUpColorsForMaker(textMakeLookup.Text);
    }
  }
}
