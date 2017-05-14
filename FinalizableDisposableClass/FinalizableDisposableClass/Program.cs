using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Dispose()/ Destructor Combo Platter *****");
      // Call Dispose manually. This will not call the finalizer
      MyResourceWrapperRebustImplementation rw = new MyResourceWrapperRebustImplementation();
      rw.Dispose();

      // Don't call Dispose(). GC will trigger the finalizer
      MyResourceWrapperRebustImplementation rw2 = new MyResourceWrapperRebustImplementation();

    }
  }
}
