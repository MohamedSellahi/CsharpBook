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
using Coll = System.Collections.Generic;

namespace BinaryResourcesApp {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    // list of BitmapImage files. 
    Coll.List<BitmapImage> _images = new List<BitmapImage>();

    // Current position in the list 
    private int currImage = 0;
    private const int _MAX_IMAGES = 2;

    public MainWindow() {
      InitializeComponent();
    }

    private void btnPreviousImage_Click(object sender, RoutedEventArgs e) {
      if (--currImage < 0)
        currImage = _MAX_IMAGES;
      imageHolder.Source = _images[currImage];
    }

    private void btnNextImage_Click(object sender, RoutedEventArgs e) {
      if (++currImage > _MAX_IMAGES)
        currImage = 0;
      this.imageHolder.Source = _images[currImage];
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) {
      try {
        string path = Environment.CurrentDirectory;

        // load images when window loades 
        // this is hard coded, and will try to load images from
        // the actual directory ...\Images\...
        //_images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\Deer.jpg", path))));
        //_images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\Dogs.jpg", path))));
        //_images.Add(new BitmapImage(new Uri(string.Format(@"{0}\Images\Welcome.jpg", path))));

        // this will load images from the embeded compiled resources 
        //
        _images.Add(new BitmapImage(new Uri(@"/Images/Deer.jpg", UriKind.Relative)));
        _images.Add(new BitmapImage(new Uri(@"/Images/Dogs.jpg", UriKind.Relative)));
        _images.Add(new BitmapImage(new Uri(@"/images/Welcome.jpg", UriKind.Relative))); 

        // show the first image of the list 
        this.imageHolder.Source = _images[currImage];
      }
      catch (Exception ex) {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
