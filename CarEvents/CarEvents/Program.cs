using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Initial Test of events *****\n");

      #region Subscribing/Unsubscribing to Events
      // Listening to an event !
      // subscribing a method to the event : we say a method is listening to 
      // an event if it is subscribed to it 
      //
      // Use the following Pattern : 
      // NameOfObject.NameOfEvent += new NemeOfDelegate(NameoffunctiontoCall);
      //
      // to unsubscribe : 
      // NameOfObject.NameOfEvent -= handler;

      Car c1 = new Car("LaggyCar", 100, 10);
      
      Car.CarEngineHandler h1 = new Car.CarEngineHandler(DisplayMessage);
      Car.CarEngineHandler h2 = new Car.CarEngineHandler(DisplayMessageUpperCase);

      c1.AboutToBlow += h1;
      c1.Exploded += h2;

      for (int i = 0; i < 6; i++) {
        c1.Accelerate(20);
      }

      
      #endregion

      #region Subscribing using group conversion syntax

      Console.WriteLine("\n****** trying the BMW *****\n");
      // Registration to events can be done using method goup conversion syntax
      Car c2 = new Car("BMW", 200, 10);
      c2.AboutToBlow += (DisplayMessage);
      c2.Exploded += (DisplayMessageUpperCase);

      for (int i = 0; i < 10; i++) {
        c2.Accelerate(20);
      }

      #endregion

      #region Symplifying Registration using Visual Studio 
      Car c3 = new Car("Ford", 200, 10);
      c3.AboutToBlow += C3_AboutToBlow;
      #endregion
      

      






    }

    private static void C3_AboutToBlow(string msg) {
      Console.WriteLine("C3_AboutToBlow" + msg);
    }

    public static void DisplayMessage(string str) {
      Console.WriteLine(str);
    }

    public static void DisplayMessageUpperCase(string str) {
      Console.WriteLine(str.ToUpper());
    }



  }
}
