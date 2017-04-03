using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethod {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with generic method *****");
      MyGenercMethod m = new MyGenercMethod();
      // swap 2 int 
      int a = 10, b = 30;
      Console.WriteLine("Before swap {0} {1}", a, b);
      m.Swap<int>(ref a, ref b);
      Console.WriteLine("After swap {0} {1}", a, b);
      Console.WriteLine();

      // Swap 2 strings 
      string s1 = "Hello", s2 = "There";
      Console.WriteLine("Before swap {0} {1}", s1, s2);
      m.Swap<string>(ref s1, ref s2); // Although compiler can infer type: better put Swap<Type>
      Console.WriteLine("After swap {0} {1}", s1, s2);
      Console.WriteLine();

      m.DisplayBaseClass<int>();
      m.DisplayBaseClass<string>();
      m.DisplayBaseClass<StreamReader>();
      

      
    }

   

  }
}
