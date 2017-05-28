using System;

namespace MorpionGame {

  internal interface IPlay {
    bool playOnMyTurn(object source, MorpionEventArgs e);
    bool Move(MorpionEventArgs baord);

  }
}