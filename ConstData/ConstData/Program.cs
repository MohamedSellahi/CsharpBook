using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData {
  class Program {
    
    static void Main(string[] args) {
      Console.WriteLine("****** Constant Data ******");
      // const data are implicitly static 
      Console.WriteLine("The value of PI is {0}", MathClass.PI);

      // Read Only fields 
      Console.WriteLine("Value of static Pi before any instance of Mathclass {0}", MathClass.staticROPI);

      MathClass m = new MathClass(3.1415);
      MathClass m2 = new MathClass();
      Console.WriteLine(m.ROPI);
      Console.WriteLine(m2.ROPI);

      Console.WriteLine(MathClass.staticROPI);


    }// main 

    static void LocalconstStringVariable() {
      const string str = "Fixed string data";
      Console.WriteLine(str);

      //str = "This wil not work";
    }


  }
}
