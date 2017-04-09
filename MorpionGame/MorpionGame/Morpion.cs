using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public Char PCChar { get; set; }
    /// <summary>
    /// Character representing Human player
    /// </summary>
    public Char USerChar { get; set; }
    /// <summary>
    /// Array of squares representing a board
    /// </summary>
    private Square[,] _board;

    private char Player1Char = 'X';
    private char Player2Char = 'O';

    private int _squareWidth ; // TODO Add constructor that intiates this properties 
    private int _squareHight ;

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
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nrows"></param>
    /// <param name="ncolumns"></param>
    /// <param name="fill"></param>
    public Morpion(int nrows, int ncolumns, SquareOccupation fill) {
      NRows = nrows;
      NCollumns = ncolumns;
      _board = new Square[NRows, NCollumns]; // Squares will be set to there default values 
      InitializeBoard(_board, fill);
    }


    /// <summary>
    /// Adds the possibility to intitially fill the board
    /// for debug purpuses only 
    /// 
    /// </summary>
    /// <param name="_board"></param>
    /// <param name="fill"></param>
    private void InitializeBoard(Square[,] _board, SquareOccupation fill) {
      for (int i = 0; i < NRows; i++) {
        for (int j = 0; j < NCollumns; j++) {
          _board[i, j] = new Square(fill);
        }
      }
    }



    #region Methods
    /// <summary>
    /// Draws the board 
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
        case SquareOccupation.Plauer2:
          return Player2Char;
        default:
          return ' ';  // this line should never be reached 
      }

    }







    #endregion






  }
}
