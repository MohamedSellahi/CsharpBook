using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolApp {
   class Printer {
      // this momber is use as a lock for multithreaded operation 
      private object threadLock = new object();

      public void PrintNumbers() {
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

      public void PrintNumberWithLock() {

         // use the lock tocken 
         lock (threadLock) {
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
         // the above code is identical to 
         //try {
         //   Monitor.Enter(threadLock);
         //   // Display Thread info 
         //   Console.WriteLine("-> {0} is executing PrintNumbers()",
         //      Thread.CurrentThread.Name);

         //   // Print Out numbers 
         //   Console.Write("Your numbers: ");
         //   for (int i = 0; i < 10; i++) {
         //      // Put the thread to sleep for random amount of time 
         //      Random r = new Random();
         //      Thread.Sleep(1000 * r.Next(3));
         //      Console.Write("{0}, ", i);
         //      Thread.Sleep(1000);
         //   }
         //   Console.WriteLine();


         //}
         //catch (Exception) {
            
         //}
         //finally {
         //   Monitor.Exit(threadLock);
         //}



      }

   }
}
