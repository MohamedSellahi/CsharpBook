using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation00 {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("****** Fun with Class Types ******");
         // Allocate and configure a Car object.
         Car myCar = new Car();
         myCar.petName = "Henry";
         myCar.currSpeed = 10;
         for (int i = 0; i < 11; i++) {
            myCar.SpeedUp(5);
            myCar.PrintState();
         }
         // 
         Console.WriteLine("Using custom construnctor");
         Car car0 = new Car("Mohamed", 20);
         Car car1 = new Car();

         car0.PrintState();
         car1.PrintState();
         // 
         Console.WriteLine("\n The motor cycle test ");
         MotorCycle moto = new MotorCycle();
         Console.WriteLine(moto.ToString() + "0");
         moto.PopAWheely();
        // Console.WriteLine(moto.ToString() + "1");
         MotorCycle moto2 = new MotorCycle(5);
         moto2.PopAWheely();
         
         // role of this keyword

         MotorCycle moto3 = new MotorCycle(5);
         moto3.SetDriveName("Tiny");
         Console.WriteLine("Rider name is {0}", moto3.driverName);

         // 
         MotorCycle moto4 = new MotorCycle("Mohamed");


      }// end of main 
   }// end of program






}// end of namespace 
