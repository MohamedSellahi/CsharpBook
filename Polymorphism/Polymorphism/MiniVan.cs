using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism {
  public class MiniVan : Car {
    private string _name;

    public MiniVan(int max, string name):base(max) {
      _name = name;
    }
    public MiniVan():base() {

    }

    public override sealed void DisplayStats() {
      Console.WriteLine("{0}, max speed: {1}", _name, maxSpeed);
    }

    


  }
}