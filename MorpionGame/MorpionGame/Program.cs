using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Player one 

namespace MorpionGame {
  class Program {
    static void Main(string[] args) {

      //Morpion m = new Morpion(15, 10, SquareOccupation.Player1);
      //m.XOrig = Console.CursorLeft;
      //m.YOrig = Console.CursorTop;
      //m.DrawMorpionBoard();
      //m.CallPlayer1();
      //m.CallPlayer2();

       

      Morpion m2 = new Morpion(6, 6, SquareOccupation.Empty, new HumanPlayer("Mohamed", 'X'),
                                                             new HumanPlayer("Luc",'O'));
      m2.XOrig = Console.CursorLeft;
      m2.YOrig = Console.CursorTop;
      m2.DrawMorpionBoard();

      while (m2.LeftMovements > 0) {
        m2.CallPlayer1();
        m2.CallPlayer2();
      }

      Console.WriteLine("game over ");

      //m2.Xorig = Console.CursorLeft;
      //m2.YOrig = Console.CursorTop;
      //m2.DrawMorpionBoard();
      //m2.CallPlayer1();
      //m2.CallPlayer2();



     // int bottomX = Console.CursorLeft;
     // int bottomY = Console.CursorTop;
     // //Console.SetCursorPosition(m2.Xorig + 1, m2.YOrig + 1);
     // //Console.WriteLine("O");


     //// Console.SetCursorPosition(m.XOrig + 1, m.YOrig + 1);
     // Console.ReadLine();
     // Console.WriteLine("O");
     // Console.SetCursorPosition(bottomX, bottomY);

    }



    public static T[] Populate<T>(T[] array, Func<T> provider) {
      for (int i = 0; i < array.Length; i++) {
        array[i] = provider();

      }

      return array;
    }



  }

}

