using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions {
  class Car {
    public const int MaxSpeed = 100;
    public int CurrentSpeed { get; set; }
    public string Petname { get; set; }
    private bool carIsDead;

    private Radio theMusicBox = new Radio();

    public Car() { }
    public Car(string name, int speed) {
      CurrentSpeed = speed;
      Petname = name;
    }

    public void CrankTunes(bool state) {
      theMusicBox.TurnOn(state);
    }

    public void Accelerate(int delta) {
      if (carIsDead) {
        Console.WriteLine("{0} is out off order ...", Petname);
      }
      else {
        CurrentSpeed += delta;
        if (CurrentSpeed > MaxSpeed) {
          CurrentSpeed = 0;
          carIsDead = true;
          Exception ex = new Exception(string.Format("{0} has overheated", Petname));
          ex.HelpLink = "http://www.nowhere.no";

          // stuff in custom data regarding the error 
          ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
          ex.Data.Add("Cause", "You have a lead foot.");
          


          throw ex;

        }
        else {
          Console.WriteLine("==> CurrentSpeed = {0}", CurrentSpeed);
        }
      }



    }



  }
}
