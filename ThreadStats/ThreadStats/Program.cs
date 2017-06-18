using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStats {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("****** Primary Thread Stats ******");

         // Obtain and name the current thread 
         Thread primaryThread = Thread.CurrentThread;
         primaryThread.Name = "ThePrimaryThread";

         // Show details of the hosting AppDomain/Context 
         Console.WriteLine("The name of the current AppDomain: {0}",
            Thread.GetDomain().FriendlyName);
         Console.WriteLine("ID of current Context: {0}",
            Thread.CurrentContext.ContextID);

         // Print some stats of the current thread
         Console.WriteLine("Thread Name: {0}", primaryThread.Name);
         Console.WriteLine("Has thread started? {0}", primaryThread.IsAlive);
         Console.WriteLine("Priority level: {0}", primaryThread.Priority);
         Console.WriteLine("Thread State: {0}", primaryThread.ThreadState);
         
      }
   }
}
