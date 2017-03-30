using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism {
  public class Radio {

    private bool _isOn;

    public Radio() {
      _isOn = false ;
    }

    public Radio(bool status) {
      _isOn = status;
    }

    public bool RadioStatus { get { return _isOn; } set { _isOn = value; } }


    public bool ONOFF { get { return _isOn; } set { _isOn = value; } }
  }
}