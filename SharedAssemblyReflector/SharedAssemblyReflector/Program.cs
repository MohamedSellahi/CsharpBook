using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SharedAssemblyReflector {
  class Program {

    private static void DisplayInfo(Assembly a) {
      Console.WriteLine("***** Info about Assembly *****");
      Console.WriteLine("Loaded from GAC? {0}", a.GlobalAssemblyCache);
      Console.WriteLine("Asm name: {0}", a.GetName().Name);
      Console.WriteLine("Asm version: {0}", a.GetName().Version);
      Console.WriteLine("ASM culture: {0}", a.GetName().CultureInfo.DisplayName);
      Console.WriteLine("\nHere are the public enums: ");

      // Use LINQ
      Type[] types = a.GetTypes();
      var publicEnums = from pe in types
                        where pe.IsEnum && pe.IsPublic
                        select pe;
      foreach (var pe in publicEnums) {
        Console.WriteLine(pe);
      }
    }

    static void Main(string[] args) {
      Console.WriteLine("***** the shared Asm Reflector App *****");
      // load System.Windows.Forms.dll from GAC 
      string displayName = null;
      displayName = "System.Windows.Forms," +
                    "Version=4.0.0.0," +
                    "PublicKeyToken=b77a5c561934e089," +
                    @"Culture=""";
      Assembly asm = Assembly.Load(displayName);
      DisplayInfo(asm);
      Console.WriteLine("Done!");

    }
  }
}
