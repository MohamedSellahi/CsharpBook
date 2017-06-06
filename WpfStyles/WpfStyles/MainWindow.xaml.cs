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
      setBtnStyle();

    }

    private void setBtnStyle() {


      //Setter setter = new Setter();
      //setter.Property = Button.FontSizeProperty;
      //setter.Value = 30d;

      //Trigger trigger = new Trigger();
      //trigger.Property = UIElement.IsMouseOverProperty;
      //trigger.Value = true;
      //trigger.Setters.Add(setter);

      //Style s = new Style();
      //s.Triggers.Add(trigger);

      //btnStyleFromcode.Style = s;

      Setter s1 = new Setter();
      Setter s2 = new Setter();

      s1.Property = Button.ForegroundProperty;
      s1.Value = new SolidColorBrush(Colors.Red);

      s2.Property = Button.FontSizeProperty;
      s2.Value = 30.0;

      MultiTrigger mt = new MultiTrigger();
      mt.Conditions.Add(new Condition(Button.IsMouseOverProperty, true));
      mt.Conditions.Add(new Condition(Button.IsPressedProperty, true));
      mt.Setters.Add(s1);
      mt.Setters.Add(s2);


      Style st = new Style();
      st.Triggers.Add(mt);

      btnStyleFromcode.Style = st;


    }


  }
}
