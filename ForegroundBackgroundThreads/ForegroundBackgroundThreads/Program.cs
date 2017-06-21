using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForegroundBackgroundThreads {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("*****  Background threads *****");
         Printer p = new Printer();

         Thread bgThread =
            new Thread(new ThreadStart(p.PrintNumbers));
         // this is a background thread 
         bgThread.IsBackground = true;
         bgThread.Start();
      }
   }
}
