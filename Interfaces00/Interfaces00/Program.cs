using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces00 {
  class Program {
    static void Main(string[] args) {

      //MyAbstractClass c = new MyAbstractClass();
      MyClass c = new MyClass();
      c.DisplayMessage();
      c.MessageFromParent();
      
      MyAbstractClass ac = new MyClass();
      ac.DisplayMessage();

    }
  }
}