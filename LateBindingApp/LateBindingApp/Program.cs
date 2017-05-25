using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LateBindingApp {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with late binding *****");
      Assembly a = null;
      try {
        string displayName = null;
        displayName = "CarLibrary, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = 3bd5efdad304f14b";
        a = Assembly.Load(displayName);
        
      }
      catch (FileNotFoundException e) {
        Console.WriteLine(e.Message);
      }

      if (a != null) {
        CreateUsingLateBinding(a);
        InvokeMethodWithArgsUsingLatebinding(a);
      }
       

    }

    private static void CreateUsingLateBinding(Assembly a) {

      try {
        
        Type miniVan = a.GetType("CarLibrary.MiniVan");

        // Create a minvan on the fly 
        object obj = Activator.CreateInstance(miniVan);
        Console.WriteLine("Created a {0} using late binding!", obj);
        // How to invoke method in a dynamically created object using activator
        foreach (var item in miniVan.GetMethods()) {
          Console.WriteLine(item);
        }

        // invoking TurboBoost();
        MethodInfo mi = miniVan.GetMethod("TurboBoost");
        // pass null for void parameters 
        mi.Invoke(obj, null);

      }
      catch (Exception e) {
        Console.WriteLine(e.Message);
      }

    }

    static void InvokeMethodWithArgsUsingLatebinding(Assembly asm) {
      try {
        // get a metadata desciption of sports car.
        Type sCar = asm.GetType("CarLibrary.SportsCar");
        // create a sports car object 
        object sCarhandle = Activator.CreateInstance(sCar);

        // Invoke turOnradio
        MethodInfo mi = sCar.GetMethod("TurnOnRadio");
        mi.Invoke(sCarhandle, new object[] { true, 2 });
       

      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }
    }

  }
}
