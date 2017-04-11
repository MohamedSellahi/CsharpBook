using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// P1 = 'X'
// P2 = 'O'
namespace MorpionGame {
  /// <summary>
  /// Class Morpion
  /// </summary>
  public class Morpion {

    #region Attributes and properties 

    /// <summary>
    /// 
    /// </summary>
    public int NRows { get; set; }  // 
    /// <summary>
    /// 
    /// </summary>
    public int NCollumns { get; set; }
    /// <summary>
    /// Character representing PC player 
    /// </summary>
    public Char Player1Char { get; set; }
    /// <summary>
    /// Character representing Human player
    /// </summary>
    public Char Player2Char { get; set; }
    /// <summary>
    /// Array of squares representing a board
    /// </summary>
    private Square[,] _board;

    private Player _player1;
    private Player _player2;
    /// <summary>
    /// Represents the number of empty places
    /// left on the board 
    /// </summary>
    private int _nbMeftmovements;

    public int LeftMovements {
      get { return _nbMeftmovements; }
      set { _nbMeftmovements = value; }
    }





    private int _squareWidth ; // TODO Add constructor that intiates this properties 
    private int _squareHight ;

    public int SqWidth { get { return _squareWidth; }}
    public int SqHight { get { return _squareHight; } }

    /// <summary>
    /// used to save the origin of the drawing of the board.
    /// </summary>
    private int _xOrig;

    public int XOrig{
      get { return _xOrig; }
      set { _xOrig = value; }
    }

    private int _yOrig;
    public int YOrig {
      get { return _yOrig; }
      set { _yOrig = value; }
    }

    /// <summary>
    /// position of the cursor on the board
    /// XCursor varies from 0 to NCollumns - 1
    /// YCursor varies from 0 to NRows - 1 
    /// </summary>
    public int XCursor{ get; set; }    // 
    public int YCursor { get; set; }


    public delegate bool PlayOnMyTurnEventHandler(object source, MorpionEventArgs args);

    public event PlayOnMyTurnEventHandler TurnForPlayer1;
    public event PlayOnMyTurnEventHandler TurnForPlayer2;

    private TurnIsFor _turnIsFor;

    public TurnIsFor WhichTurn {
      get { return _turnIsFor; }
      set { _turnIsFor = value; }
    }


    #endregion

    /// <summary>
    /// Default constructor: Creates a Morpion board with defualt size of 3x3;
    /// </summary>

    public Morpion() {
      NRows = 3;
      NCollumns = 3;
      _board = new Square[NRows, NCollumns]; // Squares will be set to there default values 
      _squareWidth = 4;
      _squareHight = 1;
      LeftMovements = NRows * NCollumns;
      WhichTurn = TurnIsFor.player1;


    }
    /// <summary>
    /// Creates a Morpion Board with custom size;
    /// </summary>
    /// <param name="nrows"><value>Number of rows in the board</value></param>
    /// <param name="ncolumns"><value>Number of collumns in the board</value></param>

    public Morpion(int nrows, int ncolumns) {
      NRows = nrows;
      NCollumns = ncolumns;
      _board = new Square[NRows, NCollumns]; // Squares will be set to there default values 
      InitializeBoard(_board, SquareOccupation.Empty);
      _squareWidth = 4;
      _squareHight = 1;
      LeftMovements = NRows * NCollumns;

      _player1 = new HumanPlayer("No-Name", 'X');  // default values 
      _player2 = new PCPlayer('O');

      TurnForPlayer1 += _player1.playOnMyTurn;
      TurnForPlayer2 += _player2.playOnMyTurn;

      Player1Char = _player1.Symbol;
      Player2Char = _player2.Symbol;

      WhichTurn = TurnIsFor.player1;
      XCursor = NCollumns / 2;
      YCursor = NRows / 2;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nrows"></param>
    /// <param name="ncolumns"></param>
    /// <param name="fill"></param>
    public Morpion(int nrows, int ncolumns, SquareOccupation defaultfill) {
      NRows = nrows;
      NCollumns = ncolumns;
      _board = new Square[NRows, NCollumns]; // Squares will be set to there default values 
      LeftMovements = NRows * NCollumns;

      InitializeBoard(_board, defaultfill);
      _squareWidth = 4;
      _squareHight = 1;
      _player1 = new HumanPlayer("No-Name", 'X');  // default values 
      _player2 = new PCPlayer('O');

      TurnForPlayer1 += _player1.playOnMyTurn;
      TurnForPlayer2 += _player2.playOnMyTurn;

      Player1Char = _player1.Symbol;
      Player2Char = _player2.Symbol;

      WhichTurn = TurnIsFor.player1; // we start by player 1
      XCursor = NCollumns / 2;
      YCursor = NRows / 2;
    }

    public Morpion(int nrows, int ncolumns, SquareOccupation defaultfill, Player p1, Player p2) {
      NRows = nrows;
      NCollumns = ncolumns;
      _board = new Square[NRows, NCollumns]; // Squares will be set to there default values 
      InitializeBoard(_board, defaultfill);
      LeftMovements = NRows * NCollumns;

      _squareWidth = 4;
      _squareHight = 1;
      _player1 = p1;
      _player2 = p2;

      // Attach player turn event to corrsponding playr 
      TurnForPlayer1 += _player1.playOnMyTurn;
      TurnForPlayer2 += _player2.playOnMyTurn;

      Player1Char = _player1.Symbol;
      Player2Char = _player2.Symbol;

      WhichTurn = TurnIsFor.player1;
      XCursor = NCollumns / 2;
      YCursor = NRows / 2;
    }


    /// <summary>
    /// Adds the possibility to intitially fill the board
    /// for debug purpuses only 
    /// 
    /// </summary>
    /// <param name="_board"></param>
    /// <param name="fill"></param>
    private void InitializeBoard(Square[,] _board, SquareOccupation defaultfill) {
      for (int i = 0; i < NRows; i++) {
        for (int j = 0; j < NCollumns; j++) {
          _board[i, j] = new Square(defaultfill);
        }
      }
    }



    #region Methods
    /// <summary>
    /// Draws the board: Make sure to save the origin of the actual drawing the 
    /// the properties Xorig, Yorig :   
    /// </summary>
    public void DrawMorpionBoard() {
      
      // holds a line of the board: the size is computed in 
      // accordance with the folliwing picture :
      // ---+---+---+
      //  X | X | X |
      // ---+---+---+
      //
      StringBuilder SeparationLine = new StringBuilder(NCollumns * this._squareWidth);
      StringBuilder PlayLine = new StringBuilder(NCollumns + this._squareWidth);

      //// buildin the separation lines 
      //for (int iCol = 0; iCol < NCollumns; iCol++) {
      //  SeparationLine.Append("--+");
      //}

      Console.Clear();
      Console.WriteLine("Left moves {0}", LeftMovements);
      // drawing the lines 
      for (int irow = 0; irow < NRows; ++irow) {
        for (int icol = 0; icol < NCollumns; ++icol) {
          SeparationLine.Append("---+");
          PlayLine.Append(' ').Append(SquareToCharOnBoard(_board[irow, icol])).Append(' ').Append('|');
        }
        
       
        Console.WriteLine(SeparationLine.ToString());
        Console.WriteLine(PlayLine.ToString());
        SeparationLine.Clear();
        PlayLine.Clear();
      }

      // displaying the lasr line 
      for (int iCol = 0; iCol < NCollumns; iCol++) {
        SeparationLine.Append("---+");
      }
      Console.WriteLine(SeparationLine.ToString());

      Console.WriteLine("Turn for " + _player1.Name);
      Console.WriteLine("Turn for " + _player2.Name);



    }

    /// <summary>
    /// Returns to the character representing the occupation state of 
    /// the actual square on the board 
    /// </summary>
    /// <param name="square"></param>
    /// <returns></returns>

    private char SquareToCharOnBoard(Square square) {
      switch (square.Occupation) {
        case SquareOccupation.Empty:
          return ' ';
        case SquareOccupation.Player1:
          return Player1Char;
        case SquareOccupation.Player2:
          return Player2Char;
        default:
          return ' ';  // this line should never be reached 
      }

    }

    /// <summary>
    /// handler wrapper to call each player 
    /// </summary>
    public void CallPlayer1() {
      if (TurnForPlayer1 != null)
        TurnForPlayer1(this, new MorpionEventArgs(this));
    }

    public void CallPlayer2() {
      if (TurnForPlayer2 != null)
        TurnForPlayer2(this, new MorpionEventArgs(this));
    }


    /// <summary>
    /// Tries to put player movement in the square with coordiantes 
    /// xpos, ypos
    /// </summary>
    /// <param name="xpos"></param>
    /// <param name="ypos"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public bool PlacePlayerMovement(int xpos, int ypos, Player p) {
      if (xpos < 0 || xpos > NCollumns - 1 || ypos < 0 || ypos > NRows - 1) {
        return false;
      }
      else {
        if (_board[ypos, xpos].Occupation == SquareOccupation.Empty) {
          _board[ypos, xpos].Occupation = p.POccupation;
          return true;
        }          
        else
          return false;
      }

    } 
    

    #endregion


  }

  public enum TurnIsFor {
    player1,
    player2
  }


}
