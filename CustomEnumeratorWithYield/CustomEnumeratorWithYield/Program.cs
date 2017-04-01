using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield {
  class Program {
    static void Main(string[] args) {

      Garage carLot = new Garage();

      // this will uses the GetEnumerator construct 
      foreach(Car item in carLot) {
        Console.WriteLine(item.Petname);
      }

      // Get Items in reverse named iterator 
      Console.WriteLine("Getting Items in reverse order");
      foreach(Car item in carLot.GetTheCars(true)) {
        Console.WriteLine("{0} is going {1} kMh", item.Petname, item.CurrentSpeed);
      }

      Console.WriteLine("Getting Items in seauential order");
      // IEnumerable can be used like this 
      IEnumerator i = carLot.GetEnumerator();
      while(i.MoveNext()) {
        Console.WriteLine(((Car)i.Current).Petname);
      }





    }
  }
}
