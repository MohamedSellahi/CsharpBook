using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFinalize {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Finalizers *****\n");
      Console.WriteLine("Hit Enter key to shut down this app ");
      Console.WriteLine("and force the GC to invoke Finalize()");
      Console.WriteLine("for object created in this AppDomain.");
      Console.ReadLine();
      MyResourceWrapper rw = new MyResourceWrapper();

    }
    
  }
}
