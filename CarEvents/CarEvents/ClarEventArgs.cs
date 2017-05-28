using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents {
  class ClarEventArgs: EventArgs {
    public readonly string message;

    public ClarEventArgs(string msg) {
      message = msg;
    }


  }


}
