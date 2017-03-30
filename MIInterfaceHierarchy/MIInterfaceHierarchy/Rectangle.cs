using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIInterfaceHierarchy {
  class Rectangle : IShape {

    void IPrintable.Draw() {
      // Draw to printer
    }

    void IDrawable.Draw() {
      // Draw to screen
    }

    public int GetNumberOfSides() {
      return 4;
    }

    public void Print() {
      //Print
    }



  }
}
