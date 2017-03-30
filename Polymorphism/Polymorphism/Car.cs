using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism {
  public class Car {
    private int currSpeed;
    public int maxSpeed;
    private Radio _radio = new Radio(false);

    public Car() {
      maxSpeed = 55;
    }

    public Car(int max) {
      maxSpeed = max;
    }

    public int Speed {
      get {
        return currSpeed;
      }

      set {
        if (value > maxSpeed) {
          currSpeed = maxSpeed;
        }
      }
    }
    
    private bool RadioStatus {
      get {
        return _radio.RadioStatus;
      }

      set {
        _radio.RadioStatus = value;
      }
    }


    public virtual void DisplayStats() {
      Console.WriteLine("The current speed: {0}", Speed);
    } // Car

  }


}