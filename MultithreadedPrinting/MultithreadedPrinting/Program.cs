using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace MultithreadedPrinting {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Synchronising threads ******\n");
         Printer p = new Printer();
         // Make 10 threads that are all pointing to the same 
         // method on the same object 
         Thread[] threads = new Thread[10];
         for (int i = 0; i < threads.Length; i++) {
            threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
            threads[i].Name = string.Format("Worker thread #{0}", i); 
         }
        

         // now start each one 
         foreach (Thread t in threads) {
            t.Start();
            Random r = new Random(); 
            Thread.Sleep(100*r.Next(5));
         }

         // now, trying the same operation , bt using a 
         // lock for synchronization 
         Console.WriteLine("***** Synchronising threads with a Lock ******\n");
         Printer p2 = new Printer();
         Thread[] threads2 = new Thread[10];
         for (int i = 0; i < threads2.Length; i++) {
            threads2[i] =
               new Thread(new ThreadStart(p2.PrintNumberWithLock));
            threads2[i].Name = string.Format("Worker thread #{0}", i); 
         }
         // start each thread 
         foreach (Thread t in threads2) {
            t.Start();
            Random r = new Random();
            Thread.Sleep(100 * r.Next(5)); 
         }

         // using the thread safe class 
         TSafePrinter p3 = new TSafePrinter();
         Thread[] threads3 = new Thread[10];
         for (int i = 0; i < threads3.Length; i++) {
            threads3[i] =
               new Thread(new ThreadStart(p3.PrintNumbers));
            threads3[i].Name = string.Format("Worker thread #{0}", i);
         }
         // start each thread 
         foreach (Thread t in threads3) {
            t.Start();
            Random r = new Random();
            Thread.Sleep(100 * r.Next(5));
         }



      }
   }
}
