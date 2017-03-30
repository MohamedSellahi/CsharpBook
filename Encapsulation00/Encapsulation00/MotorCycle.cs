using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation00 {
   public class MotorCycle {
      // data fields 
      public int driverIntensity;
      public string driverName; 


      // methods 
      public void SetDriveName(string name) {
         this.driverName = name;
      }
      public void PopAWheely() {
         for (int i = 0; i < driverIntensity+1; i++) {
            Console.WriteLine("Yeeeeeeeee Haaaaaaawwww!");
         }
      }

      // the default constructor 
      public MotorCycle() {
         Console.WriteLine("In default constructor");
      }

      // the master constructor: the one with greatest number of parameters 
      public MotorCycle(int intensity, string name) {
         if (intensity > 10)
            intensity = 10;
         driverIntensity = intensity;
         driverName = name;
      }

      // custom constructor
      // constructor chaining : looks like c++ list parameter initilization
      public MotorCycle(int intensity) : this(intensity, "") {
         Console.WriteLine("In ctor taking an int");
      }

      public MotorCycle(string name) : this(0, name) {
         Console.WriteLine("In ctor taking a string");
      }


   }
}