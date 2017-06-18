using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchCallbackDeligate {
   class Program {
      public delegate int BinaryOp(int x, int y);

      private static bool IsDone = false;
      static void Main(string[] args) {
         Console.WriteLine("***** AsyncCallbackDelegate Example *****");
         Console.WriteLine("Main() invoked on thread {0}.",
         Thread.CurrentThread.ManagedThreadId);

         BinaryOp b = new BinaryOp(Add);
         IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete),
            "Main() thanks you for adding these numbers");

         //Assume other work is performed here 
         while (!IsDone) {
            Thread.Sleep(1000);
            Console.WriteLine("Working ...");
         }

         //int answer = b.EndInvoke(iftAR);
         //Console.WriteLine("10 + 10 = {0}", answer);
      }

      private static void AddComplete(IAsyncResult itfAR) {
         Console.WriteLine("AddCompelte() inveked on {0}.", Thread.CurrentThread.ManagedThreadId);
         Console.WriteLine("Your addition is complete");

         // now get the result 
         AsyncResult ar = (AsyncResult)itfAR;
         // get the reference to the delegate that was called (in the other thread )
         BinaryOp b = (BinaryOp)ar.AsyncDelegate;
         Console.WriteLine("the result from the AddComplete callback: ");
         Console.WriteLine("10 + 10 = {0}", b.EndInvoke(itfAR));

         // retrieve the information object and cast it to string 
         string mmsg = (string)itfAR.AsyncState;
         Console.WriteLine(mmsg);
         IsDone = true;
      }

      private static int Add(int x, int y) {
         Console.WriteLine("Add() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
         Thread.Sleep(5000);
         return x + y;
      }
   }
}
