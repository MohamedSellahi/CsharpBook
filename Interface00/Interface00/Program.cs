using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface00 {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("***** A first look at interfaces *****\n");
      // All these classes support the iclonalbe interface 
      string str = "Hello";
      OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
      System.Data.SqlClient.SqlConnection sqlCnn = new System.Data.SqlClient.SqlConnection();

      // therefor they can be passed to a method that takes an iclonable.
      CloneMe(str);
      CloneMe(unixOS);
      CloneMe(sqlCnn);     

    }

    private static void CloneMe(ICloneable c) {
      // Clone whatever we get and print out the name
      object theClone = c.Clone();
      Console.WriteLine("Your clone is a: {0}", theClone.GetType().Name);
    }



  }
}
