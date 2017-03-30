using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash {
  class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter, ISave {

    // this will give the same implementation for all the interfaces 
    // which is not what we want 

    //public void Draw() {
    //  // Shared drawing Logic
    //  Console.WriteLine("Drawing the octagon ...");
    //}

    void IDrawToForm.Draw() {
      Console.WriteLine("Drawing to Form ...");
    }

    void IDrawToMemory.Draw() {
      Console.WriteLine("Drawing to Memory ...");
    }

    void IDrawToPrinter.Draw() {
      Console.WriteLine("drawing to Printer ...");
    }

    public void Draw() {
      Console.WriteLine("Drawing from object directly");
    }

    public void Save() {
      Console.WriteLine("Saving File ...");
    }


  }
}
