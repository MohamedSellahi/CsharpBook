using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverlaoding {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("****** Method overlaoding ******");
      Console.WriteLine(Add(2,3));
      Console.WriteLine(Add(90000000000,90000000000));
      Console.WriteLine(Add(4.3, 4.4));
      
    }// end of main

    static int Add(int x, int y) {
      return x + y;
    }

    static double Add(double x, double y) {
      return x + y;
    }

    static long Add(long x, long y) {

      return x + y;
    }



  }// end of class
}
