using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoroveloading {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Overloaded Operator\n");
      // 
      Point p1 = new Point(100, 100);
      Point p2 = new Point(40, 40);
      Console.WriteLine("p1 = {0}", p1);
      Console.WriteLine("p2 = {0}", p2);

      // 
      Console.WriteLine("p1 + p2 = {0}", p1 + p2);
      Console.WriteLine("p2 - p2 = {0}", p1 - p2);

      Console.WriteLine("p1 + 10 = {0}", p1 + 10);
      Console.WriteLine("p2 - 10 = {0}", p1 - 10);

      Console.WriteLine("p1 += p1 {0}", p1 += p1);
      Console.WriteLine("p1 -= p1 {0}", p1 -= p1);

      // Overlaoding unary operators
      Console.WriteLine("p1 ++ = {0}", p1++);
      Console.WriteLine("p1 -- = {0}", p1--);

      // 



    }





  }
}
