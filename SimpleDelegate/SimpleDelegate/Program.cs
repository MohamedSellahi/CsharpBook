using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleDelegate {
  class Program {

    // this delegate can point to any
    // method taking two ints and returning an int 

    public delegate int BinaryOp(int x, int y);

    // this class contains methods Binary delegate 
    // will point to 
    public class SimpleMath {
      public int Add(int x, int y) {
        return x + y;
      }

      public int Substract(int x, int y) {
        return x - y;
      }

      public int SquareNumber(int x) {
        return x * x;
      }

      public SimpleMath() {
        NB = 2;
      }
      public int NB { get; set; }

    }

    class ComplexMath {
      public int Substract(int x, int y) {
        return x - y;
      }
    }

    static void Main(string[] args) {
      Console.WriteLine("***** Simple Delegate Example *****");
      // create binary delegate object
      SimpleMath m = new SimpleMath();
      ComplexMath m2 = new ComplexMath();

      BinaryOp b = new BinaryOp(m2.Substract);
       b += new BinaryOp(m.Add);

      // invoking method directly using delegate object 
     
      Console.WriteLine("10 + 10 = {0}",b(10,10));
      

      // getting the object holding the method pointed to by delegate 
      Console.WriteLine(b.Method);
      DisplayDelegateInfo(b);
      



    }

    public static void DisplayDelegateInfo(Delegate del) {
      // print names of each member in the invocation list 
      // of maintained by the delegate
      foreach (Delegate item in del.GetInvocationList()) {
        Console.WriteLine("Method name: {0}", del.Method);
        Console.WriteLine("Type name: {0}", del.Target);
        Console.WriteLine();
      }
    }


  }
}
