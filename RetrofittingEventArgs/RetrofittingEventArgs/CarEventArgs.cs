using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrofittingEventArgs {
  class CarEventArgs: EventArgs {
    public readonly string _message;

    public CarEventArgs(string msg) {
      _message = msg;
    }
  }

}
