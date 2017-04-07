using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionGame {
  class Program {
    static void Main(string[] args) {

      Morpion m = new Morpion(10, 10, SquareOccupation.Player1);
      m.DrawMorpionBoard();

    }
  }
}
