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


    }

    private static void Car_AboutToBlow(object sender, CarEventArgs e) {
      if(sender is Car) {
        Car c = (Car)sender;
        Console.WriteLine("critical message from {0}: {1}", c.PetName, e._message);

      }


    }
  }
}
