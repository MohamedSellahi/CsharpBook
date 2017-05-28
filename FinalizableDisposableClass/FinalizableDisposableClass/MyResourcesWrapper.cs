using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass {
  class MyResourcesWrapper : IDisposable {

    /* the garbage collector will call this method
     * if the user forgets to call Dispose()
     */
    ~MyResourcesWrapper() {
      // clean up internam unmanaged resources 
      // Do **not** call Dispose() on any managed 
      // object 
    }

    // the object user will call this method 
    // to clean up resources ASAP

    public void Dispose() {
      // the object user will call this method to cleanup 
      // Call Dispose() on other disposable objects 
      // No need to finalize if user called Dispose()
      // so suppress finalization 
      GC.SuppressFinalize(this); // <--
    }
  }
}
