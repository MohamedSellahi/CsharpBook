using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint {
  class Program {
    static void Main(string[] args) {

      // point using int
      Point<int> pint = new Point<int>(10, 10);

      // point using double
      Point<double> pd = new Point<double>(5.3, 3.3);
      Console.WriteLine(pint);
      Console.WriteLine(pd);
      pint.ResetPoint();
      pd.ResetPoint();
      Console.WriteLine(pint);
      Console.WriteLine(pd);
      
    }

   
  }
}
