using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword {
  class Program {
    static void Main(string[] args) {
    }

    static public void ImplicitlyTypedVariable() {
      var a = new List<int>();
      a.Add(90);

      // this would be a compile time error 
      //a = "hello";
    }


  }

}
