using System;
using System.Reflection;
using System.Linq;
using System.Text;
using System.IO;


namespace ExternalAssemblyReflector {
  class Program {

    static void DisplayTypesInAsm(Assembly asm) {
      Console.WriteLine("\n***** Types in Assembly *****");
      Console.WriteLine("->{0}", asm.FullName);
      Type[] types = asm.GetTypes();
      foreach (Type item in types) {
        Console.WriteLine("Type: {0}", item);
        Console.WriteLine("");
      }

    }


    static void Main(string[] args) {
      Console.WriteLine("***** External Assembly Viewer *****");
      string asmName = "";
      Assembly asm = null;

      do {
        Console.WriteLine("\nEnter an Assembly to evaluate");
        Console.Write("or Q to quit: ");
        // get the name of assembly
        asmName = Console.ReadLine();
        if (asmName.ToUpper() == "Q") {
          break; 
        }

        // try to laod assembly 
        try {
          asm = Assembly.Load(asmName);
          DisplayTypesInAsm(asm);
        }
        catch (Exception e) {
          Console.WriteLine("Sorry, can't find assembly");
        }


      } while (true);

    }
  }
}
