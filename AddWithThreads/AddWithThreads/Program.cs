using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AddWithThreads {
   class Program {
      // USe AutoReset Class to synchronyse secondary thread with primary thread 
      private static AutoResetEvent waitHandle = new AutoResetEvent(false);

      static void Main(string[] args) {
         Console.WriteLine("***** Adding with Thread objects *****");
         Console.WriteLine("ID of thread in Main(): {0}",
         Thread.CurrentThread.ManagedThreadId);

         // Make an AddParams Object to pass to the secondary thread. 
         AddParams ap = new AddParams(10, 10);
         Thread t = new Thread(new ParameterizedThreadStart(Add));
         t.Start(ap);

         //// Force a wait, let other thread finish 
         //Thread.Sleep(5);
         // wait until you are notified 
         waitHandle.WaitOne();
         Console.WriteLine("Other thread is done!");
      }


      public static void Add(object data) {
         Console.WriteLine("ID of thread in Add(): {0}",
            Thread.CurrentThread.ManagedThreadId);
         AddParams ap = (AddParams)data;
         Console.WriteLine("{0} + {1} = {2}", ap.a, ap.b, ap.a + ap.b);

         // notify the main thread we are done 
         waitHandle.Set();
      }
   }
}
