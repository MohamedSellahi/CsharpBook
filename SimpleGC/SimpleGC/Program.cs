using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with System.GC *****");
      
      /* Print out estimated number of byte on the heap */
      Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));

      /* MaxGeneration is zero based, so add 1 for display purposes */
      Console.WriteLine("This OS has {0} object generations. \n", GC.MaxGeneration + 1);

      /* */
      Car MyCar = new Car("Zippy", 100);
      Console.WriteLine(MyCar);

      // printout generation of mycar 
      Console.WriteLine("genration of myCar is: {0}", GC.GetGeneration(MyCar));

      /* make some objects */
      object[] tonOfObjects = new object[50000];
      for (int i = 0; i < tonOfObjects.Length; i++) {
        tonOfObjects[i] = new object();
      }

      // collect only gen0 objects 
      GC.Collect(0, GCCollectionMode.Forced);
      GC.WaitForPendingFinalizers();
      Console.WriteLine("genration of myCar is: {0}", GC.GetGeneration(MyCar));

      // check if tonsOfObjects[9000] is still alive 
      if (tonOfObjects[9000] != null) {
        Console.WriteLine("Generation of tonsOfObject[9000] is :{0}",
          GC.GetGeneration(tonOfObjects[9000])
          );
      }
      else {
        Console.WriteLine("tonsOfObject[9000] is no longer alive.");
      }

      // printout how many times a genreation has been swept 
      Console.WriteLine("\nGen 0 has been swept {0} times", GC.CollectionCount(0));
      Console.WriteLine("\nGen 1 has been swept {0} times", GC.CollectionCount(1));
      Console.WriteLine("\nGen 2 has been swept {0} times", GC.CollectionCount(2));


      /* manually trigger a garbage collection */
      GC.Collect(); // GC.collect(int generation)
      GC.WaitForPendingFinalizers();
      Console.WriteLine("Estimated bytes on heap: {0}", GC.GetTotalMemory(false));
    }
    
  }
}
