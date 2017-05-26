using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CustomAppDomains {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Custom AppDomains *****\n");
      // Show all loaded Assemblies in the default AppDomain 
      AppDomain defaultAD = AppDomain.CurrentDomain;
      ListAllAssmebliesInAppDomain(defaultAD);
      // MAKE new AppDomain
      MakeNewAppDomain();

      // notify me when defaultAppDomain is unloaded 
      defaultAD.ProcessExit += (o, s) => { Console.WriteLine("Default AppDomain unloaded"); };

    }

    public static void MakeNewAppDomain() {
      // Make new app domain in the current process 
      // and list the loaded assemblies 
      AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
      try {
        // laod CarLibrar.dll into this new AppDomain
        newAD.Load("Carlibrary");
        newAD.Load("Hello");
        newAD.ExecuteAssembly("Hello.exe");
        //Assembly[] asms = newAD.GetAssemblies();
        //foreach (Assembly a in asms) {
        //  Type[] types = a.GetTypes();
        //  foreach (Type t in types) {
        //    PropertyInfo[] methods = t.GetProperties();
        //    foreach (PropertyInfo mi in methods) {
        //      Console.WriteLine(mi.Name);
        //    }
        //  }

        //}



      }
      catch (FileNotFoundException ex) {
        Console.WriteLine(ex.Message);
      }

      // register unload event 
      newAD.DomainUnload += (o, s) => { Console.WriteLine("Domain unlaoded event handler was triggered "); };
      ListAllAssmebliesInAppDomain(newAD);

      // Now unload this AppDomain
      AppDomain.Unload(newAD);


    }

    private static void ListAllAssmebliesInAppDomain(AppDomain ad) {
      // now get all assemblies in the default app domain 
      var loadedAssemblies = from a in ad.GetAssemblies()
                             orderby a.GetName().Name
                             select a;

      Console.WriteLine("***** Here are the assemblies loaded in {0}", ad.FriendlyName);
      foreach (var a in loadedAssemblies) {
        Console.WriteLine("-> Name: {0}", a.GetName().Name);
        Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
      }

    }
  }
}
