using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AttributedCarLibrary;

namespace VehicleDescriptionAttributeReader {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Value of Vehicule Description Attribute *****");
      ReflectionOnAttributeUsingEarlyBinding();
      ReflectionOnAttributeUsingLateBinding();

    }

    private static void ReflectionOnAttributeUsingLateBinding() {
      

    }

    private static void ReflectionOnAttributeUsingEarlyBinding() {
      // get a type representing Winnebago. 
      Type t = typeof(Winnebago);

      // Get attributes of Winnebago 
      object[] customAtts = t.GetCustomAttributes(false);
      // print descriptions 
      foreach (var item in customAtts) {
        Console.WriteLine(item);
      }
      foreach (VehicleDescriptionAttribute item in customAtts) {
        Console.WriteLine("->{0}", item.Description);
      }

    }



  }
}
