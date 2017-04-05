using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCustomEventArguments {
  class Program {
    static void Main(string[] args) {
      Car c1 = new Car("FORD", 200, 10);

      // Subscribing to the event 
      c1.AboutToBlow += Car_AboutToBlow;

      // Using the event generic declared event handler 
      c1.AboutToBlow2 += C1_AboutToBlow2;
      // or 
      EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(C1_Exploded2);
      c1.Exploded2 += d;

      for (int i = 0; i < 10; i++) {
        c1.Accelerate(20);
      }



    }

    private static void C1_Exploded2(object sender, CarEventArgs e) {
      if(sender is Car) {
        Car c = (Car)sender;
        Console.WriteLine("CRITICAL MESSAGE FROM {0}: {1}", c.PetName,e._message);
      }
    }

    private static void C1_AboutToBlow2(object sender, CarEventArgs e) {
      if(sender is Car) {
        Car c = (Car)sender;
        Console.WriteLine("CRITICAL MESSAGE FROM {0}: {1}", c.PetName,e._message);
      }

    }

    private static void Car_AboutToBlow(object sender, CarEventArgs e) {
      if(sender is Car) {
        Car c = (Car)sender;
        Console.WriteLine("critical message from {0}: {1}", c.PetName, e._message);

      }


    }
  }
}
