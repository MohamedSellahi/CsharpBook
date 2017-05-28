using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass {
  class MyResourceWrapperRebustImplementation : IDisposable {
    /* this design pattern is aimed at addressing the following 
     * issues with Finalizable and Disposable class 
     * 
     * --> Finilize() and Dispose() would share the same cleaning 
     *     code. For the sake of maintainability, we would prefer 
     *     to define a private helper method that is called by either
     *     methods to perform clean up 
     * --> Make sure that Finilize() will not dispose of any managed 
     *     objects, while the Dispose() logic should do so.
     * --> Make sure that the object user can **safely** call Dispose()
     *     method multiple times without erro.
     * 
     * */
    // user to determine if dispose has been already called 
    private bool _disposed = false; 
    

    public void Dispose() {
      Console.WriteLine(">>> Dispose() logic <<<");
      /* call helper method.
       * Specitying "true" signifies that the object 
       * user triggered the cleanup 
       */
      CleanUp(true);
      // Now suppress finalization 
      GC.SuppressFinalize(this);
    }

    private void CleanUp(bool UserDispose) {
      // Be sure we have not already been disposed 
      if(!this._disposed) {
        // if disposing equals true, dispose all 
        // managed resources 
        if (UserDispose) {
          // Dispose managed resources here. GC will skip this 
        }
        // Clean up unmanaged resources here
      }
      _disposed = true;
    }

    ~MyResourceWrapperRebustImplementation() {
      Console.WriteLine(">>> GC logic <<<");

      // Call the Helper method with "false"
      // signifies the GC triggered clean up 
      Console.Beep(); // <-- for test only 
      CleanUp(false);
    }

    /* Remark:
     * After an object has been "Disposed", it is still possible for the client to invoke members
     * on it, as it is still in memory. Therefore, a robust wrapper class would need to update
     * each member of the class with additional coding logic that tells the caller, do nothing
     * im already Disposed, and return from the member.
     */

  }
}
