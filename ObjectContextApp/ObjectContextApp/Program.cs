using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectContextApp {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Object context *****");
      // Object displays contextual infos upon creation 
      SportsCar sport = new SportsCar();
      Console.WriteLine();

      SportsCar sport1 = new SportsCar();
      Console.WriteLine();

      SportCarTS sport2 = new SportCarTS();
    }
  }
}
