using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation00 {
   class Car {
      // the state of the car 
      public string petName;
      public int currSpeed;

      
      // A custom default constructor 
      public Car() {
         petName = "Chuck";
         currSpeed = 10;
      }

      public Car(string name, int speed) {
         petName = name;
         currSpeed = speed;
      }

      // the functionality of the car
      public void PrintState() {
         Console.WriteLine("{0} is going {1} KMh.", petName, currSpeed);
      }

      public void SpeedUp(int delta) {
         currSpeed += delta;
      }

   }// end of class
}
