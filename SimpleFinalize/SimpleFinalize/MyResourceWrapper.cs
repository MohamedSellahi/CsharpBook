using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFinalize {
  class MyResourceWrapper {



    // C++ destructor like method: 
    // implicitly protected, 
    ~MyResourceWrapper() {
      // clean up unmannaged resources here 
      Console.Beep();
    }
  }
}
