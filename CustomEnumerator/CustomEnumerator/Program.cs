using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Ienumerable/ IEnumerator *****");
      Garage carLot = new Garage();
      foreach (Car item in carLot) {
        Console.WriteLine("{0} is going {1} kMh", item.Petname, item.CurrentSpeed);
      }

      Console.WriteLine("\n interracting with IEnumerator type");
      IEnumerator i = carLot.GetEnumerator();
      i.MoveNext();
      Car myCar = (Car)i.Current;
      Console.WriteLine("{0} is going {1} kMh", myCar.Petname, myCar.CurrentSpeed);





    }
  }
}
