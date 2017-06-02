using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfControlAndAPI {
  [ValueConversion(typeof(double), typeof(int))]
  class myDoubleConverter : IValueConverter {
    /// <summary>
    /// converts double to int used by a data binding object  
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      // converts Double to int 
      double v = (double)value;
      return (int)v;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      // we don't worry about the other way arround (target -> source)
      return value;
    }
  }
}
