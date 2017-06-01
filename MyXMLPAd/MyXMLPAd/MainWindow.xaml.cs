using System;
using System.IO;
using System.Windows.Markup;
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

namespace MyXMLPAd {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }
    private string _filePath = "MyXAML.xaml";



    // 
    private void Window_Loaded(object sender, RoutedEventArgs e) {
      // Check if there is an XAML file in the working directory 
      // if so laod it, otherwise fill in the textBox area with
      // default template 
      
      if (File.Exists(_filePath)) {
        txtXamlData.Text = File.ReadAllText(_filePath);
      }
      else {
        txtXamlData.Text =
        "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n"
        + "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n"
        + "Height =\"400\" Width =\"500\" WindowStartupLocation=\"CenterScreen\">\n"
        + "<StackPanel>\n"
        + "</StackPanel>\n"
        + "</Window>";
      }

    }



    private void Window_Closed(object sender, EventArgs e) {
      // Write out the data in the text block to a local *.xmal file. 
      File.WriteAllText(_filePath, txtXamlData.Text);
      Application.Current.Shutdown();
    }

   

    private void btnViewXaml_Click(object sender, RoutedEventArgs e) {
      // Write out the data in the text block to a local *.xaml file 
      File.WriteAllText(_filePath, txtXamlData.Text);

      // this is the window that will be constructed 
      Window win = new Window();
      try {
        using (Stream sr = File.Open(_filePath,FileMode.Open)) {
          // Connect the XAML to the window 
          win = (Window)XamlReader.Load(sr);
          win.ShowDialog();
          win.Close();
          win = null; 
        }

      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }

    }



  }
}
