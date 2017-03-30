using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultipleException {
  class Program {
    static void Main(string[] args) {
      Car myCar = new Car("BMW", 20);

      try// car creation block
        {
        

        try {
          throw new CarIsDeadException3("The original exception");

        }
        catch (CarIsDeadException3 e) {
          // save a log file 
          try {
            // this code may raise annother exception 
            FileStream fs = File.Open(@"C:\cars.Errorlog.txt", FileMode.Open);
          }
          catch (FileNotFoundException ef) {
            // throw an exception that records the new exception 
            // as well as the message of the first exception 
            throw new CarIsDeadException3(e.Message, ef);

          }
          

        }

      }
      catch (Exception e) {

        Console.WriteLine(e.Message);
        Console.WriteLine("in: " + e.InnerException.StackTrace);
        Console.WriteLine(e.InnerException.Message);
      }
      finally {
        // this will always happen: this is the location where we release resources if any, make some cleanup ...
        myCar.CrankTunes(false);
        Console.WriteLine("Switching radio off ...");
      }



    }
  }
}
