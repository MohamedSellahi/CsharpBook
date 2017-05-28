using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionGame {
  public class MorpionEventArgs : EventArgs {

    public readonly Morpion Mboard;

    public MorpionEventArgs(Morpion mboard) {
      Mboard = mboard;
    }

  }



}
