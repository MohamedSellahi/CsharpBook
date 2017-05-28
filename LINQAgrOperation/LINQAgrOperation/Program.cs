using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAgrOperation {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Aggregation functions *****");
      AggregateOps();
    }

    /**/
    static void AggregateOps() {
      double[] Temps = { 2.0, -21.3, 8, -4, 0, 8.2 };

      Console.WriteLine("Temps: ");
      foreach (var item in Temps) {
        Console.WriteLine("{0} ", item);
      }
      Console.WriteLine();
      Console.WriteLine("Max temp: {0}",
        (from t in Temps select t).Max()
        );
      Console.WriteLine("Min temp: {0}",
        (from t in Temps select t).Min()
        );

      Console.WriteLine("Average temps: {0:N2}",
        (from t in Temps select t).Average()
        );

      Console.WriteLine("Sum of All temps: {0}",
        (from t in Temps select t).Sum()
        );

    }
  }
}
