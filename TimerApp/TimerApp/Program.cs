using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Working with Timer Type *****");
         // Create a Tymer callBack 
         TimerCallback timeCB = new TimerCallback(PrintTime);

         // Establish Timer setting 
         Timer t = new Timer(timeCB, null, 0, 1000);
         //
         Console.WriteLine("Hit any Key to terminate ");
         Console.ReadLine();
      }

      public static void PrintTime(object state) {
         Console.WriteLine("Time is: {0}", DateTime.Now.ToLongTimeString());
      }
   }
}
