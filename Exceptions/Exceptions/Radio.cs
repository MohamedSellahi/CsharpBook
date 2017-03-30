using System;

namespace Exceptions {
  internal class Radio {

    public bool OnOff { get; set; }
    internal void TurnOn(bool state) {
      OnOff = state;
    }





  }
}