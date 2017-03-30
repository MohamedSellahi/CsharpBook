using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleException {
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
          CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has overheated", Petname), "You have a lead foot.", DateTime.Now);

          ex.HelpLink = "http://www.nowhere.no";


          


          throw ex;

        }
        else {
          Console.WriteLine("==> CurrentSpeed = {0}", CurrentSpeed);
        }
      }



    }



  }
}
