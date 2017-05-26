using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAppDomainApp {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with the default App domain *****");
      InitDAD();
      DisplayDADStats();
      ListAllLoadedAssembliesInAppDomain();


    }



    private static void DisplayDADStats() {
      // Get access for the app domain of the current thread 
      AppDomain defaultAD = AppDomain.CurrentDomain;

      // print out various stats of this domain 
      Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
      Console.WriteLine("Id of domain in this process: {0}",defaultAD.Id);
      Console.WriteLine("Is this the default domain: {0}", defaultAD.IsDefaultAppDomain());
      Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);

    }

    private static void ListAllLoadedAssembliesInAppDomain() {
      // Get access to the AppDomain for the current thread 
      AppDomain defaultAD = AppDomain.CurrentDomain;

      // Get All assemblies in the default AppDomain
      Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
      Console.WriteLine("\n***** Here are the assemblies laoded in {0} *****\n", defaultAD.FriendlyName);
      foreach (Assembly asm in loadedAssemblies) {
        Console.WriteLine("-> Name: {0}, ",asm.GetName().Name);
        Console.WriteLine("-> Version: {0} ", asm.GetName().Version);
      }
      Console.WriteLine("-------");

      // using link query to view new laoded lib
      var laodedAssm = from ls in defaultAD.GetAssemblies()
                       orderby ls.GetName().Name
                       select ls;
      foreach (var asm in laodedAssm) {
        Console.WriteLine("-> Name: {0}, ", asm.GetName().Name);
        Console.WriteLine("-> Version: {0} ", asm.GetName().Version);
        Console.WriteLine();
      }

    }

    private static void InitDAD() {
      // this logic will print out name of any assembly 
      // loaded into the application domain, afte it has been created
      AppDomain defaultAD = AppDomain.CurrentDomain;
      defaultAD.AssemblyLoad += (o, s) => {
        Console.WriteLine("{0} has been laoded!", s.LoadedAssembly.GetName().Name);
      };
     

    }
  }
}
