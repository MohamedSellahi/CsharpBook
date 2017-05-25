using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDescriptionAttributeLateBinding {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Value of VehicleDescriptionAttribute *****");
      ReflectionAttributeUsingLateBinding();


    }

    private static void ReflectionAttributeUsingLateBinding() {
      try {
        Assembly asm = Assembly.Load("AttributedCarLibrary");

        // Get type info of VehicleDescriptionAttribute 
        Type vDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
        // Get type info of description property 
        PropertyInfo propDesc = vDesc.GetProperty("Description");
        // Get all types in the assembly 
        Type[] types = asm.GetTypes();
        // Iterate over each type andobtain any VehicleDescriptionAttribute
        foreach (Type t in types) {

          object[] objs = t.GetCustomAttributes(vDesc, false);
          // Iterate over each VehicleDescriptionAttribute and print 
          // the description using late binding 
          foreach (object obj in objs) {
            Console.WriteLine("-> {0}: {1}\n",t.Name, propDesc.GetValue(obj,null));
          }

        }

        foreach (Type item in types) {
          Console.WriteLine("{0} has:", item.Name);
          object[] atrs = item.GetCustomAttributes(false);
          foreach (Attribute ats in atrs) {
            Console.WriteLine(ats);
          }
          Console.WriteLine("----------------------");


        }
      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
      }
    }
  }
}
