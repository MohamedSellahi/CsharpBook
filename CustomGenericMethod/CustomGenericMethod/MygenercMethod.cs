using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethod {
   public class MyGenercMethod {
    // this method can swap any two items 
     public void Swap<T>(ref T a, ref T b) {
      Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
      T temp = a;
      a = b;
      b = temp;
    }


    //
     public void DisplayBaseClass<T>() {
      Console.WriteLine("Base Class of {0} is: {1}.", typeof(T), typeof(T).BaseType);
    }
  }


}
