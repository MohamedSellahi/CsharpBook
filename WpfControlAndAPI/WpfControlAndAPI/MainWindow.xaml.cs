using System;
using coll = System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.IO;
using System.Windows.Ink;
using System.Windows.Markup;
using Microsoft.Win32;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Data;

namespace WpfControlAndAPI {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    coll.List<Car> cars = null;

    public MainWindow() {
      InitializeComponent();

      // set default values 
      this.myCanvas.EditingMode = InkCanvasEditingMode.Ink;
      this.inkRadio.IsChecked = true;
      this.comboColors.SelectedIndex = 0;
      this.mySB.Value = 40;

      // Document tab 
      Populatedocument();

      // 
      EnableAnnotations();

      // set bindings 
      SetBindings();

      // generate somme cars 
      GetSommeCars();
      // 
      ConfigureGrid();
    }

    private void ConfigureGrid() {
      this.gridInventory.ItemsSource = cars;
    }

    private void GetSommeCars() {
      this.cars = new coll.List<Car> {
        new Car{CarId=1, Color = "Red", Maker = "Ford", PetName ="Mustang"},
        new Car{CarId = 2, Color ="Blue", Maker ="BMW", PetName="Z-Series"},
        new Car{CarId =3, Color = "Black", Maker="Mercedes", PetName="S-Series"},
        new Car{CarId=1, Color = "Red", Maker = "Ford", PetName ="Mustang"},
        new Car{CarId = 2, Color ="Blue", Maker ="BMW", PetName="Z-Series"},
        new Car{CarId =3, Color = "Black", Maker="Mercedes", PetName="S-Series"},
        new Car{CarId=1, Color = "Red", Maker = "Ford", PetName ="Mustang"},
        new Car{CarId = 2, Color ="Blue", Maker ="BMW", PetName="Z-Series"},
        new Car{CarId =3, Color = "Black", Maker="Mercedes", PetName="S-Series"}
      };
    
    }

    private void SetBindings() {
      // CReate a binding object 
      Binding b = new Binding();
      // Registes the converter, the source and the path 
      b.Converter = new myDoubleConverter();
      b.Source = this.mySB;
      b.Path = new PropertyPath("Value");

      // call the set binding method on the label 
      this.btn2.SetBinding(Button.FontSizeProperty, b);
    }

    private void EnableAnnotations() {
      // Create AnnotationService object that will 
      // work with myReader 
      AnnotationService annoService = new AnnotationService(this.myReader);

      // Create a memorystream that will hold the annotations 
      MemoryStream annoStream = new MemoryStream();

      // Now, create an XML-based store on the memory stream
      // You could use this object to programatically add, delete
      // or find annotations
      AnnotationStore store = new XmlStreamStore(annoStream);

      // Enbable the annotation services 
      annoService.Enable(store);


    }

    private void inkRadio_Click(object sender, RoutedEventArgs e) {
      // based on which button sent the event, place the Inkcanvas in a 
      // unik mode 
      switch ((sender as RadioButton).Content.ToString()) {
        case "Ink Mode!":
          myCanvas.EditingMode = InkCanvasEditingMode.Ink;
          break;
        case "Erase Mode!":
          myCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
          break;
        case "Select Mode!":
          myCanvas.EditingMode = InkCanvasEditingMode.Select;
          break;

      }

    }

    private void ColorChanged(object sender, SelectionChangedEventArgs e) {
      // Get the selected value in the combo box 
      // string colorTouse = (this.comboColors.SelectedItem as ComboBoxItem).Content.ToString();

      // Get the tag of the selected panel 
      string colorToUse = (this.comboColors.SelectedItem as StackPanel).Tag.ToString();


      // Change the color used to render the strokes.
      this.myCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(colorToUse);
    }

    private void btnSave_Click(object sender, RoutedEventArgs e) {
      // open dialog box 
      SaveFileDialog svdlg = new SaveFileDialog();
      string fileName = null;
      svdlg.Filter = "CanvasData | *.bin";
      if ((bool)svdlg.ShowDialog(this) == true) {
        // try to save the file
        fileName = svdlg.FileName;
        //Save all Data on the canvas to a local file 
        try {
          using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
            this.myCanvas.Strokes.Save(fs);
            fs.Close(); // is it realy necessary 
          }

        }
        catch (Exception ex) {
          MessageBox.Show(ex.Message, "Error saving file");
        }

      }



    }

    private void btnLoad_Click(object sender, RoutedEventArgs e) {

      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Filter = "canvas Data | *.bin";
      string fileName = null;
      if ((bool)(dlg.ShowDialog()) == true) {
        // try to open 
        fileName = dlg.FileName;
        try {

          using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
            StrokeCollection strockes = new StrokeCollection(fs);
            myCanvas.Strokes = strockes;
          }
        }
        catch (Exception ex) {
          MessageBox.Show(ex.Message, "Error opening file");
        }

      }
      // Fill StrockCollection from file 



    }

    private void btnClear_Click(object sender, RoutedEventArgs e) {
      // Clear the canvas 
      this.myCanvas.Strokes.Clear();

    }

    // 
    private void Populatedocument() {
      // Add some data to the list item
      this.listOfFuncFacts.FontSize = 14;
      this.listOfFuncFacts.MarkerStyle = TextMarkerStyle.Circle;
      this.listOfFuncFacts.ListItems.Add(new ListItem(
        new Paragraph(new Run("Fixed Document are for WYSIWYG print ready docs"))));
      this.listOfFuncFacts.ListItems.Add(new ListItem(new Paragraph(new Run("The Api supports tables and embeded figures"))));
      this.listOfFuncFacts.ListItems.Add(new ListItem(new Paragraph(new Run("flow Documents are read only"))));
      this.listOfFuncFacts.ListItems.Add(new ListItem(new Paragraph(new Run("BlockUIContainer allows you to embed WPF controls in the document"))));

      // Now add some data to the paragraph
      // First part of sentence
      Run prefix = new Run("this paragraph was generated");

      // Middle of paragraph
      Bold b = new Bold();
      Run infix = new Run("dynamicaly");
      infix.Foreground = Brushes.Red;
      infix.FontSize = 30;
      b.Inlines.Add(infix);
      // last part of the paragraph
      Run suffix = new Run("at runtime!");

      // now each pieace to the inline collection elements 
      // of the paragraph 
      this.parbodyText.Inlines.Add(prefix);
      this.parbodyText.Inlines.Add(b);
      this.parbodyText.Inlines.Add(suffix);


      // laod save document event handlers 
      btnSaveDoc.Click += (o, args) => {
        SaveFileDialog svDlg = new SaveFileDialog();
        svDlg.Filter = "XML data | *.XML";

        if ((bool)(svDlg.ShowDialog() == true)) {
          string fileName = svDlg.FileName;

          using (FileStream fs = File.Open(fileName, FileMode.Create)) {
            XamlWriter.Save(this.myReader.Document, fs);
          }
        }
      };

      btnLoadDoc.Click += (o, s) => {
        OpenFileDialog opdlg = new OpenFileDialog();
        opdlg.Filter = "XML Data | *.XML";
        if ((bool)(opdlg.ShowDialog()) == true) {
          string fileName = opdlg.FileName;
          using (FileStream fs = File.Open(fileName, FileMode.Open)) {
            try {
              FlowDocument doc = XamlReader.Load(fs) as FlowDocument;
              this.myReader.Document = doc;
            }
            catch (Exception ex) {
              MessageBox.Show(ex.Message, "Error Loading Doc!");
            }
          }
        }
      };

    }

    private void gridInventory_SelectionChanged(object sender, SelectionChangedEventArgs e) {
      var selecteRows = (sender as DataGrid).SelectedItems;
           
      string infoStr = null; 

      foreach (var item in selecteRows) {
        try {
          infoStr += ((Car)(item)).ToString() + "\n";
          MessageBox.Show(infoStr);
        }
        catch (Exception) {
          MessageBox.Show("Invalid Selection");
          
        }
     
      }
    }
  }
}
