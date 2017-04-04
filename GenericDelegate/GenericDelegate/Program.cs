using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate {
  class Program {
    // This generic delegate can call any method 
    // taking one parameter and returning a void
    public delegate void MyGenericDelegate<T>(T arg);
    public delegate void MyGenericSwapDelegate<T>(ref T arg1, ref T arg2);

    static void Main(string[] args) {
      Console.WriteLine("***** Generic Delegates ******\n");
      // Register targets
      MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
      MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);

      MyGenericSwapDelegate<int> intSwap = new MyGenericSwapDelegate<int>(Swap<int>);
      MyGenericSwapDelegate<string> strSwap = new MyGenericSwapDelegate<string>(Swap<string>);     

      strTarget("Some string data.");
      intTarget(9);
      int x = 10, y = 20;
      Console.WriteLine("Before swap ");
      Console.WriteLine("x = {0}, y = {1}", x, y);
      intSwap(ref x, ref y);
      Console.WriteLine("After swap ");
      Console.WriteLine("x = {0}, y = {1}", x, y);

      string s1 = "World", s2 = "Hello";
      Console.WriteLine("Before swap ");
      Console.WriteLine("{0} {1}", s1, s2);
      strSwap(ref s1, ref s2);
      Console.WriteLine("After swap ");
      Console.WriteLine("{0} {1}", s1, s2);


    }

    public static void IntTarget(int arg) {
      Console.WriteLine("++g = {0}", ++arg);
    }

    public static void StringTarget(string s) {
      Console.WriteLine("arg in uppercase: {0}", s.ToUpper());
    }

    public static void Swap<T>(ref T arg1, ref T arg2) {
      T temp = arg1;
      arg1 = arg2;
      arg2 = temp; 
    }

  }
}
