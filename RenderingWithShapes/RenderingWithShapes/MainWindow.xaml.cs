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

namespace RenderingWithShapes {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {

    private enum SelectedShape {
      Circle, Rectangle, Line
    }
    SelectedShape currShape;
    private bool isFlipped = false; 

    public MainWindow() {
      InitializeComponent();

      // i
      if (this.flipCanvas.IsChecked == true) {
        isFlipped = true;
      }
      
    }

    private void circleOption_Click(object sender, RoutedEventArgs e) {
      currShape = SelectedShape.Circle;
    }

    private void rectOption_Click(object sender, RoutedEventArgs e) {
      currShape = SelectedShape.Rectangle;
    }

    private void lineOption_Click(object sender, RoutedEventArgs e) {
      currShape = SelectedShape.Line;
    }

    private void canvasDrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
      Shape shapeToDraw = null;

      // Configure the correct shape to draw 
      switch (currShape) {
        case SelectedShape.Circle:
          // Configure a funcy color 
          shapeToDraw = new Ellipse() { Fill = Brushes.Green, Height = 35, Width = 35 };
          // MAke a Radial Gradiant brush in code 
          RadialGradientBrush brush = new RadialGradientBrush();
          brush.GradientStops.Add(new GradientStop(
                                      (Color)ColorConverter.ConvertFromString("#FF87E71B"),0.589));
          brush.GradientStops.Add(new GradientStop(
                                   (Color)ColorConverter.ConvertFromString("#FF2BA92B"), 0.013));
          brush.GradientStops.Add(new GradientStop(
                                    (Color)ColorConverter.ConvertFromString("#FF34B71B"), 1));
          shapeToDraw.Fill = brush;
          break;
        case SelectedShape.Rectangle:
          shapeToDraw = new Rectangle() { Fill = Brushes.Red, Width = 35, Height = 35, RadiusX = 10, RadiusY = 10 };
          break;
        case SelectedShape.Line:
          shapeToDraw = new Line() {
            Stroke = Brushes.Blue,
            StrokeThickness = 10,
            X1 = 0, X2 = 50, Y1 = 0, Y2 = 50,
            StrokeStartLineCap = PenLineCap.Triangle,
            StrokeEndLineCap = PenLineCap.Round
          };
          break;
        default:
          break;
      }

      // isFlipped to a private booean field. this is toggled when 
      // the buttin is clicked 
      if (isFlipped) {
        RotateTransform rt = new RotateTransform(-180);
        shapeToDraw.RenderTransform = rt;
      }
      // set to/left position to draw in the canvas 
      Canvas.SetLeft(shapeToDraw, e.GetPosition(canvasDrawingArea).X);
      Canvas.SetTop(shapeToDraw, e.GetPosition(canvasDrawingArea).Y);

      // draw the shape now
      canvasDrawingArea.Children.Add(shapeToDraw);
      

    }

    private void canvasDrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
      // First get the X,Y where the user clicked 
      Point pt = e.GetPosition((Canvas)sender);

      // USe the HitTEst() method of visualTreeHelper to see if the suer clicked 
      // on an item in the canvas 
      HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, pt);

      // if the result is not null, we did click on a shape 
      if (result!=null) {
        // get the underlying shape clicked on 
        canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
      }
    }

    private void flipCanvas_Click(object sender, RoutedEventArgs e) {
      if (flipCanvas.IsChecked == true) {
        RotateTransform rt = new RotateTransform(-180);
        canvasDrawingArea.LayoutTransform = rt;
        isFlipped = true;
      }
      else {
        canvasDrawingArea.LayoutTransform = null;
        isFlipped = false;
      }
    }

    private void btnClearCanvas_Click(object sender, RoutedEventArgs e) {
      this.canvasDrawingArea.Children.Clear();
    }
  }
}
