using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace TreesAndTemplates {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {

      private Control ctrtoExamine = null;
      string _dataToShow = string.Empty;
      public MainWindow() {
         InitializeComponent();
      }

      private void btnShowLogicalTree_Click(object sender, RoutedEventArgs e) {
         _dataToShow = string.Empty;
         BuildLogicalTree(0, this);
         this.txtDisplayArea.Text = _dataToShow;
         
      }

      private void BuildLogicalTree(int dept, object obj) {
         // add the type name to the data to show string 
         _dataToShow += new string(' ', dept) + obj.GetType().Name + "\n";

         // if item is not dependency object skip it 
         if (!(obj is DependencyObject)) {
            return;
         }

         foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject)) {
            BuildLogicalTree(dept + 5, child);
         }


      }

      private void btnShowVisualTree_Click(object sender, RoutedEventArgs e) {
         _dataToShow = "";
         BuildVisualTree(0, this);
         this.txtDisplayArea.Text = _dataToShow;
      }

      private void BuildVisualTree(int depth, DependencyObject obj) {
         _dataToShow += new string(' ', depth) + obj.GetType().Name + "\n";
         for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) {
            BuildVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
            
         }
      }

      private void btnTemplate_Click(object sender, RoutedEventArgs e) {
         _dataToShow = "";
         ShowTemplate();
         this.txtDisplayArea.Text = _dataToShow;
      }

      private void ShowTemplate() {
         // remove the control that is previously in the area 
         if (ctrtoExamine != null)
            stackTemplatePanel.Children.Remove(ctrtoExamine);
         try {
            // laod pesentation frame work and create an instance of 
            // the specified control. Give it size for display purpuses 

            Assembly asm = Assembly.Load("PresentationFramework, Version=4.0.0.0," +
               "Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            ctrtoExamine = (Control)asm.CreateInstance(txtFullName.Text);
            ctrtoExamine.Height = 200;
            ctrtoExamine.Width = 200;
            ctrtoExamine.Margin = new Thickness(5);
            stackTemplatePanel.Children.Add(ctrtoExamine);

            // Define some XAML setting to preserve indentation. 
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            // Create a StringBuilder to hold the xml 
            StringBuilder strBuilder = new StringBuilder();

            // Create an XmlWriter based on our settings
            XmlWriter xWriter = XmlWriter.Create(strBuilder, xmlSettings);

            // now save the xml into the xmlWriter object 
            XamlWriter.Save(ctrtoExamine.Template, xWriter);

            // display the XAML in the text box 
            _dataToShow = strBuilder.ToString();

         }
         catch (Exception ex ) {
            _dataToShow = ex.Message;
         }
      }
   }
}
