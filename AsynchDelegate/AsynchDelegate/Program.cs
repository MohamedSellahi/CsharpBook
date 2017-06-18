using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchDelegate {
   class Program {
      public delegate int BinaryOp(int x, int y);

      static void Main(string[] args) {
         Console.WriteLine("***** Async Delegate Invokation *****");

         // Print out the ID of the executing thread.
         Console.WriteLine("Main() invoked on thread {0}.",
         Thread.CurrentThread.ManagedThreadId);

         // Invoke Add() on secondary thread 
         BinaryOp b = new BinaryOp(Add);
         IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

         //// Do other work on primary thread...
         //Console.WriteLine("Doing more work in Main()!");
         //// Obtain the result of the Add()
         //// method when ready.
         //int answer = b.EndInvoke(iftAR);
         //Console.WriteLine("10 + 10 is {0}.", answer);

         // This message will keep printing 
         // until the Add() methos is finished 
         while (!iftAR.IsCompleted) {
            Console.WriteLine("Doing more work in Main()!");
            Thread.Sleep(1000);
         }
         // now we know the add method is complete.
         int answer = b.EndInvoke(iftAR);

         Console.WriteLine("10 + 10 is {0}.", answer);

      }

      private static int Add(int x, int y) {

         // Print out the ID of the executing thread.
         Console.WriteLine("Add() invoked on thread {0}.",
         Thread.CurrentThread.ManagedThreadId);
         // Pause to simulate a lengthy operation.
         Thread.Sleep(5000);
         return x + y;
      }
   }
}
