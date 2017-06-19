using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;

namespace MultithreadedPrinting {
   [Synchronization]
   class TSafePrinter : ContextBoundObject{
      // the synchronization attribute allows thread safe 
      // operation for all intances of this class 
      public void PrintNumbers() {
         Console.WriteLine("\n****** Thread safety using synchronization attribute ******");

         // Display Thread info 
         Console.WriteLine("-> {0} is executing PrintNumbers()",
            Thread.CurrentThread.Name);

         // Print Out numbers 
         Console.Write("Your numbers: ");
         for (int i = 0; i < 10; i++) {
            // Put the thread to sleep for random amount of time 
            Random r = new Random();
            Thread.Sleep(1000 * r.Next(3));
            Console.Write("{0}, ", i);
            Thread.Sleep(1000);
         }
         Console.WriteLine();
      }
   }
}
