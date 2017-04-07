using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionGame {
  class Square {

    private SquareOccupation _occupationState;
    private SquareBackGroundColor _backGroundColor;
    private SquareTextColor _textColor;



    #region Properties
    /// <summary>
    /// Sets the occupation state of sqaure
    /// </summary>
    public SquareOccupation Occupation { get { return _occupationState; } set { _occupationState = value; } }
    /// <summary>
    /// Sets the background color of a single square
    /// </summary>
    public SquareBackGroundColor BackgroundColor { get { return _backGroundColor; } set { _backGroundColor = value; } }
    public SquareTextColor TextColor { get { return _textColor; } set { _textColor = value; } }

    #endregion

    #region Copnstructors
    /// <summary>
    /// Default costructor 
    /// 
    /// </summary>
    public Square() {
      Occupation = SquareOccupation.Empty;
      BackgroundColor = SquareBackGroundColor.Black;
      TextColor = SquareTextColor.White;
    }

    public Square(SquareOccupation ocp) {
      Occupation = ocp;
      BackgroundColor = SquareBackGroundColor.Black;
      TextColor = SquareTextColor.White;
    }

    #endregion



  }


  /// <summary>
  /// Define single square occupation state
  /// </summary>

  public enum SquareOccupation {
    Empty,
    Player1,
    Plauer2
  }

  /// <summary>
  /// Available colors for a single sqaure 
  /// </summary>

  enum SquareBackGroundColor {
    Black = ConsoleColor.Black,
    White = ConsoleColor.White,
    Red = ConsoleColor.Red,
    Green = ConsoleColor.Green
  }

  enum SquareTextColor {
    Yello = ConsoleColor.Yellow,
    White = ConsoleColor.White,
    Red = ConsoleColor.Red,
    Green = ConsoleColor.Green
  }

}
