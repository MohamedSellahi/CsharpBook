using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces00 {

  internal class MyClass:MyAbstractClass {
    public MyClass(){
    }

    public override void DisplayMessage() {
      Console.WriteLine("Message from Derived class "); ;
    }


  }
}