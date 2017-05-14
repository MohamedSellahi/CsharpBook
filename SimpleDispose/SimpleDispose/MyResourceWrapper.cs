using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose {
  class MyResourceWrapper : IDisposable {


    public void Dispose() {
      // Clean up unmanaged resources ...
      // Dispose other contained disposabe objects 
      // Just for test
      Console.WriteLine("*****In Dispose *****");
      Console.Beep();
    }
  }
}
