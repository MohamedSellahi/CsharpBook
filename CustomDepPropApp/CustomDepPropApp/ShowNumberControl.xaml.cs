﻿using System;
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

namespace CustomDepPropApp {
   /// <summary>
   /// Interaction logic for ShowNumberControl.xaml
   /// </summary>
   public partial class ShowNumberControl : UserControl {
      public ShowNumberControl() {
         InitializeComponent();
        
      }

      // Adding dependency property


      public int CurrentNumber {
         get { return (int)GetValue(CurrentNumberProperty); }
         set { SetValue(CurrentNumberProperty, value); }
      }

      // Using a DependencyProperty as the backing store for CurrentNumber.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty CurrentNumberProperty =
          DependencyProperty.Register("CurrentNumber",
             typeof(int), 
             typeof(ShowNumberControl),
             new PropertyMetadata(100,new PropertyChangedCallback(CurrentNumberChanged)),
             new ValidateValueCallback(ValidateCurrentNumber)
             
             );

      private static void CurrentNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
         // Cast the dependency object into ShowNumberControl
         ShowNumberControl c = (ShowNumberControl)d;
         // Get the label control in the ShowNumbercontrol
         Label theLabel = c.numberDisplay;
         // set the label with the new value
         theLabel.Content = e.NewValue.ToString();
      }

      private static bool ValidateCurrentNumber(object value) {
         // Just a simple business rule. value must be between 0 and 500.
         if (Convert.ToInt32(value) >= 0 && Convert.ToInt32(value) <= 500)
            return true;
         else 
            return false; 
      }




      // A noraml .NET property
      //private int _currNumber = 0;
      //public int CurrentNumber {
      //   get { return _currNumber; }
      //   set {
      //      _currNumber = value;
      //      numberDisplay.Content = CurrentNumber.ToString();
      //   }

      //}



   }
}
