using System;

namespace ExceptionType {
  internal class Radio {

    public bool OnOff { get; set; }
    internal void TurnOn(bool state) {
      OnOff = state;
    }





  }
}