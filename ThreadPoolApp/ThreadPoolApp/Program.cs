using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPoolApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with the CLR Thread Pool *****");
         Console.WriteLine("Main Thread started. Thread ID = {0}",Thread.CurrentThread.ManagedThreadId);

         Printer p = new Printer();
         WaitCallback workItem = new WaitCallback(PrintNumbers);

         // QUeue the method 10 times 
         for (int i = 0; i < 10; i++) {
            ThreadPool.QueueUserWorkItem(workItem, p);
         }
         Console.WriteLine("All Tasks queued");
         Console.ReadLine();
      }

      private static void PrintNumbers(object state) {
         Printer task = (Printer)state;
         task.PrintNumbers();
      }
   }
}
