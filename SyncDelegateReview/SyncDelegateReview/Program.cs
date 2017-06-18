using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDelegateReview {
   class Program {

      public delegate int BinaryOp(int x, int y); 

      static void Main(string[] args) {
         Console.WriteLine("***** Synch Delegate review *****");

         // Print out the ID of the executing thread.
         Console.WriteLine("Main() inveked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

         // Invoke Ad() in a synchronous manner 
         BinaryOp b = new BinaryOp(Add);

         // Could also write B;Invoke(10,10)
         int answer = b(10, 10);

         // This lines will not execute until the add method 
         // has completed 
         Console.WriteLine("Doing more work in Main()!");
         Console.WriteLine("10 + 10 = {0}", answer);
      }

      private static int Add(int x, int y) {
         // Printout the ID of the executing thread 
         Console.WriteLine("Add() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

         // Pause to simulate lengthy operation 
         Thread.Sleep(5000);
         return x + y; 
      }
   }
}
