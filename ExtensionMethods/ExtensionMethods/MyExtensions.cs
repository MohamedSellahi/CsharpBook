using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ExtensionMethods {
  static class MyExtensions {

    // this method allows any object to display the name
    // of the assembly it is defined in
    public static void DisplayDefiningAssembly(this object obj) {  // remark "this" keyword 
      Console.WriteLine("{0} lives in here :=> {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
    }

    // this method allows an integer to reverse its digits
    // exemple: 1234 ---> 4321
    public static int ReverseDigits(this int i) {
      char[] digits = i.ToString().ToCharArray();
      // reverse the digits 
      Array.Reverse(digits);
      // putback into string 
      string newDigit = new String(digits);

      return int.Parse(newDigit);  // may be a try catsh 
    }





  }



}
