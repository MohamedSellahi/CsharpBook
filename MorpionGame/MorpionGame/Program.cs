using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionGame {
  class Program {
    static void Main(string[] args) {

      Morpion m = new Morpion(5, 5, SquareOccupation.Player1);
      m.DrawMorpionBoard();
      int bottomX = Console.CursorLeft;
      int bottomY = Console.CursorTop;
      Console.SetCursorPosition(1, 1);
      Console.WriteLine("O");
      Console.SetCursorPosition(bottomX, bottomY);

    }



    public static T[] Populate<T>(T[] array, Func<T> provider) {
      for (int i = 0; i < array.Length; i++) {
        array[i] = provider();

      }

      return array;
    }



  }

}

