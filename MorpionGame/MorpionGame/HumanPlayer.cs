using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionGame {
  class HumanPlayer: Player {

    static private int NbPlayers;

    private int _upKey;
    private int _downKey;
    private int _leftKey;
    private int _rightKey;
    private int _enterKey;

    public int EnterKey {
      get { return _enterKey; }
    }
    public int RightKey {
      get { return _rightKey; }
    }
    public int LeftKey {
      get { return _leftKey; }
    }
    public int DownKey {
      get { return _downKey; }
    }
    public int UpKey {
      get { return _upKey; }
    }

    private int PrevXpos { get; set; }
    private int PrevYpos { get; set; }






    public HumanPlayer() { }

    public HumanPlayer(string name, char side):base(name, side) {
      // set default keys for the current player 
      if(NbPlayers == 0) {
        _rightKey = (int)ConsoleKey.RightArrow;
        _leftKey = (int)ConsoleKey.LeftArrow;
        _upKey = (int)ConsoleKey.UpArrow;
        _downKey = (int)ConsoleKey.DownArrow;
        _enterKey = (int)ConsoleKey.Enter;
        ++NbPlayers;
      }
      else {
        _rightKey = (int)ConsoleKey.F;
        _leftKey = (int)ConsoleKey.S;
        _upKey = (int)ConsoleKey.E;
        _downKey = (int)ConsoleKey.D;
        _enterKey = (int)ConsoleKey.G;
      }

    }

    static HumanPlayer() { NbPlayers = 0; }
    /// <summary>
    /// tries to move on the board. return true or false uppon success or not 
    /// </summary>
    /// <returns></returns>

    public override bool Move(MorpionEventArgs boardevents) {

      // try to read keys from the key baord and move the curser 
      // on the drawing (the board ) of the morpion
      // return true if movement is secceded 
      // and false if movement fails: for the follwing reason 
      // place is alreadey occupied, 

      try {
        do {

          int userInput = (int)Console.ReadKey().Key;

          if (userInput == DownKey) {
            // try move down
            MoveUp(boardevents.Mboard);
          }
          else if (userInput == UpKey) {
            // try move up
            MoveDown(boardevents.Mboard);
          }
          else if (userInput == RightKey) {
            // try move up 
          }
          else if (userInput == LeftKey) {
            // try mode left 
          }
          else if (userInput == EnterKey) {
            // try place sumbole in the corresponding sqaure
          }
          else {
            // play error message 
          }
        } while (true);
        
        
      }
      catch (InvalidOperationException ve) {
        // write error message at the bottom of the board 
        // display. then reposition the cursor of the console 
        // in the current position of the play

      }




      return false;
    }

    private void MoveDown(Morpion mboard) {
      // save previous pos of the current player
      PrevXpos = mboard.XCursor;
      PrevYpos = mboard.YCursor;

      if (--mboard.YCursor < 0) { // wrap arround
        mboard.YCursor = mboard.NRows - 1;
      }
      Console.SetCursorPosition(mboard.XCursor, mboard.YCursor * 2 + 1);
    }

    private void MoveUp(Morpion mboard) {
      // save previous pos of the current player
      PrevXpos = mboard.XCursor;
      PrevYpos = mboard.YCursor;

      if (++mboard.YCursor > mboard.NRows - 1) { // wrap arround
        mboard.YCursor = 0;
      }
      Console.SetCursorPosition(mboard.XCursor, mboard.YCursor *2 + 1);

    }

    public override bool playOnMyTurn(object source, MorpionEventArgs board) {
      // to be cleaned out 
      // add 
      int xPos = board.Mboard.XCursor;  // [0 --> Ncollumns - 1 ]
      int yPos = board.Mboard.YCursor;  // [0 --> NRows - 1 ]

      int xStep = board.Mboard.SqWidth;
      int yStep = board.Mboard.SqHight;

      return Move(board);
    }


  }



  struct HumanKeys {
    public int Up;
    public int Down;
    public int Left;
    public int Right;
    public int Enter;
  }


  
  
}
