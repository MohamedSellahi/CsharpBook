using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Delegate as event enablers *****\n");

      // first make a car object 
      Car c1 = new Car("SlugBug", 100, 10);
      Car.CarEngineHandler handler1 = new Car.CarEngineHandler(OncarEngineEventV1);
      Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OncarEngineEventV2);

      c1.RegisterWithCarEngine(handler1);
      c1.RegisterWithCarEngine(handler2);

      // using group conversion syntax 
      c1.RegisterWithCarEngine(OncarEngineEventV3);  // short cut without explicitly constructing a new Car.CarEngineHandler
     


      // speed Up to trigger the events 
      Console.WriteLine("***** Speeding up *****");
      for (int i = 0; i < 6; i++) {
        c1.Accelerate(20);
        Console.WriteLine();
      }

      // unregister V2
      c1.UnRegisterWithCarEngine(handler2);

      Console.WriteLine("***** Speeding up *****");
      for (int i = 0; i < 6; i++) {
        c1.Accelerate(20);
        Console.WriteLine();
      }


    }

    public static void OncarEngineEventV1(string msg) {
      Console.WriteLine("\n***** Message From Car Object *****\n");
      Console.WriteLine("{0}", msg);
      Console.WriteLine("***********************************");
    }

    public static void OncarEngineEventV2(string msg) {
      Console.WriteLine("\n***** Message From Car Object *****\n");
      Console.WriteLine("{0}", msg.ToUpper());
      Console.WriteLine("***********************************");
    }
    public static void OncarEngineEventV3(string msg) {
      Console.WriteLine("\n***** Message From Car Object v3*****\n");
      Console.WriteLine("{0}", msg.ToUpper());
      Console.WriteLine("***********************************");
    }

  }
}
