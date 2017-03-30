using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("**** Fun With Interface Name Clashes *****");
      Octagon oct = new Octagon();

      IDrawToForm itfForm = (IDrawToForm)oct;
      IDrawToMemory itfMemory = (IDrawToMemory)oct;
      IDrawToPrinter itfPrinter = (IDrawToPrinter)oct;
      ISave itfSave = (ISave)oct;

      oct.Draw();
      itfForm.Draw();
      itfMemory.Draw();
      itfPrinter.Draw();
      itfSave.Save();

      // we can use shorthand cast to access explicitly implemented interfaces
      ((IDrawToForm)oct).Draw();
      

      


    }
  }
}
