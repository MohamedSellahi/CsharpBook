using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClonablePoint {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with cloning objects *****\n");
      Point p1 = new Point(50, 50);
      Point p2 = p1;

      p2.X = 0;
      Console.WriteLine(p1);
      Console.WriteLine(p2);

      // using the Clone method
      Point p3 = (Point)p1.Clone();
      p3.X = 20;
      Console.WriteLine(p1);
      Console.WriteLine(p3);
      Console.WriteLine();

      Console.WriteLine("Cloned P4 and stored new Point in p5");
      Point p4 = new Point(100, 100, "Jane");
      Point p5 = (Point)p4.Clone();

      Console.WriteLine("Before Modification");
      Console.WriteLine("P4: {0}", p4);
      Console.WriteLine("P5: {0}", p5);
      p5.desc.PetName = "My new Point";
      p5.X = 9;
      Console.WriteLine("\n Changed p4.desc.PetName and p4.X;");
      Console.WriteLine("P4: {0}", p4);
      Console.WriteLine("P5: {0}", p5);

     

      
      


    }

    private static string getString(string orig) {
      return orig;
    }



  }
}
