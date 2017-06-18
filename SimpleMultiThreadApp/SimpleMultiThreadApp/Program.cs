using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace SimpleMultiThreadApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** The Amzing Thread App *****\n");
         Console.WriteLine(" Do you want [1] or [2] threads? ");
         string threadCount = Console.ReadLine();

         // Name the current thread 
         Thread primaryThread = Thread.CurrentThread;
         primaryThread.Name = "Primary";

         // Display thread Info 
         Console.WriteLine("-> {0} is executing Main()",
            Thread.CurrentThread.Name);

         // Make worker class 
         Printer p = new Printer();

         switch (threadCount) {
            case "2":
               // Now make new thread 
               Thread backgrounfThread = new Thread(new ThreadStart(p.PrintNumbers));
               backgrounfThread.Name = "Secondary";
               backgrounfThread.Start();
               break;
            case "1":
               p.PrintNumbers();
               break;
            default:
               Console.WriteLine("I don't know what you want...you get 1 thread.");
               p.PrintNumbers();
               break;
         }

         // Do somme aditional work 
         MessageBox.Show("Im busy!", "Work on main thread...");
      }
   }
}
