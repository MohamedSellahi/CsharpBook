using System;

namespace MorpionGame {

  abstract public class Player: IPlay {

    static protected int NbPlayers;
    public string Name { get; set; }

    private char _symbol;

    public char Symbol {
      get { return _symbol; }
      set {
        try {
          if (value != 'O' && value != 'X')
            throw new Exception("Invalid symbol. Player can be either X or O!");
          _symbol = value;
        }
        catch (Exception e) {
          Console.WriteLine(e.Message);
        }
      }
    }

    Square _sq;  // define the state if the square if 
                 // for a given player 

    private SquareOccupation _playerOccupation;

    public SquareOccupation POccupation {
      get { return _playerOccupation; }
      private set { _playerOccupation = value; }
    }

    SquareOccupation playerOccupation; 


    // TODO : to be implemented 
    public Player() { }
    /// <summary>
    /// Initiates a player 
    /// </summary>
    /// <param name="name"><value> Name of player </value></param>
    /// <param name="side"><value> 'X' or 'O' designing the side </value></param>
    public Player(string name, char side) {
      Name = name;
      Symbol = side;
      if (side == 'X')
        POccupation = SquareOccupation.Player1;
      else
        POccupation = SquareOccupation.Player2;
    }

    public abstract bool playOnMyTurn(object source, MorpionEventArgs e);
    public abstract bool Move(MorpionEventArgs baord);

    
     
  }
}