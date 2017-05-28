using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Extension Methods *****\n");
      
      // test with int 
      int myInt = 1234567;
      myInt.DisplayDefiningAssembly();

      // test with DataSet
      System.Data.DataSet d = new System.Data.DataSet();
      d.DisplayDefiningAssembly();

      //and the SoundPlayer
      System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
      sp.DisplayDefiningAssembly();

      // reverse digits of int 
      Console.WriteLine("Value of myInt: {0}", myInt);
      Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigits());

    }


  }
}
