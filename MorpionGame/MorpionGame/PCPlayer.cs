using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionGame {
  class PCPlayer:Player {
    

    public PCPlayer() {}
    public PCPlayer(char side):base("PC", side) {

    }




    public override bool Move(MorpionEventArgs baord) {

      return false; 
    }

    public override bool playOnMyTurn(object source, MorpionEventArgs e) {

      return false;
    }


  }
}
