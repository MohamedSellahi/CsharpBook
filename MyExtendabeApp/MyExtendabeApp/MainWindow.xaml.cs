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
using Microsoft.Win32;
using System.Reflection;
using CommenSnapableTypes;

namespace MyExtendabeApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public MainWindow() {
      InitializeComponent();
    }

    private void LoadButton_Click(object sender, RoutedEventArgs e) {
      OpenFileDialog dlg = new OpenFileDialog();
      
      if (dlg.ShowDialog() == true) {
        if (dlg.FileName.Contains("CommenSnapableTypes")) {

        }
        else if (!LoadExternalModule(dlg.FileName)) {
          this.LoadStatustextBlock.Text = "fails to load dll";
          LoadStatustextBlock.Foreground = Brushes.Red;
          MessageBox.Show("Nothing implements IAppfunctionnality");
        }
      }
      




    }

    private bool LoadExternalModule(string fileName) {
      // Dynamically Load selected assembly in memory 
      // Determine whether the assembly contains any types implementing 
      // IAppFunctionnality 
      // Create the type using late bunding 
      bool foundSnapin = false;
      Assembly theSnapinAsm = null;
      try {
        // Dynamically load the library 
        //AssemblyName assName = new AssemblyName()
        // get the name without extension 
        string assName = getFriendlyName(fileName); 
        theSnapinAsm = Assembly.Load(assName);
      }
      catch (Exception e) {
        MessageBox.Show(e.Message);
        return foundSnapin; // here it must be false 
      }

      // get classes that implement IAppfunctionaity 
      var theClassTypes = from t in theSnapinAsm.GetTypes()
                          where t.IsClass &&
                          (t.GetInterface("IAppFunctionality") != null) // exists 
                          select t;
      // Now create the object and call DoIt()
      foreach (Type item in theClassTypes) {
        object obj = Activator.CreateInstance(item);
        IAppFunctionality itfApp = (IAppFunctionality)obj;
        //IAppFunctionality itfApp = (IAppFunctionality)(theSnapinAsm.CreateInstance(item.FullName, true)); // get the interface 
        itfApp.Doit();

        // Display Company Data 
        DisplayCompanydata(item); 
      }
      foundSnapin = true;
      LoadStatustextBlock.Text = "Load Successful";
      LoadStatustextBlock.Foreground = Brushes.Green;
      return foundSnapin;
    }

    private void DisplayCompanydata(Type item) {
      // get [CompanyInfo] Data
      var compInfo = from ci in item.GetCustomAttributes(false)
                     where ci.GetType() == typeof(CompanyInfoAttribute)
                     select ci;
      foreach (CompanyInfoAttribute info in compInfo) {
        MessageBox.Show(info.CompanyUrl, info.CompanyName);
      }


    }

    private string getFriendlyName(string fileName) {
      if (string.IsNullOrEmpty(fileName))
        return null;
      // \directory \ filename.extension ;
      string str; 
      int idx = fileName.LastIndexOf('\\');
      if (idx <= 0)// this may be a file 
        return getFileWithoutExtension(fileName);
      str = getFileWithoutExtension(fileName.Substring(idx + 1));

      return str;
    }

    private string getFileWithoutExtension(string fileName) {
      if (string.IsNullOrEmpty(fileName))
        return null;
      int idx = fileName.LastIndexOf('.');
      return fileName.Substring(0, idx);
    }
  }
}
