using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nullable {
  class Program {
    static void Main(string[] args) {
      // compiler error 
      // bool myBool = null;
      // int myInt = null;

      // ok strings are reference types

      string myString = null;




    }// end of main 

    static void LocalNullableVariable() {
      // Define some local nullable variable 
      int? nullableInt = 10;
      double? nullableDouble = 3.14;
      bool? nullableBool = null;
      char? arrayofNullableints = new int?[10];

      // Error
      string? s = "OOps";


    }





  }
}
