using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConvesion {
  partial class Program {
    static void Main(string[] args) {

      Rectangle rec1 = new Rectangle(10, 5);
      Console.WriteLine(rec1);
      rec1.Draw();

      Square sq1 = (Square)rec1;
      Console.WriteLine(sq1);
      sq1.Draw();

      Square sq2 = (Square)20;
      Console.WriteLine(sq2);
      sq2.Draw();

      // Implicit cast OK!
      Square s3 = new Square();
      s3.Side = 7;
      Rectangle rect2 = s3;
      Console.WriteLine("rect2 = {0}", rect2);


    }






  }
}
