using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar {
  class Car: IComparable {
    public const int MaxSpeed = 100;
    public int CurrentSpeed { get; set; }
    public string Petname { get; set; }
    private bool carIsDead;
    public int CarID { get; set; }
    public Car(string name, int cuurSp, int id) {
      CurrentSpeed = cuurSp;
      Petname = name;
      CarID = id;
    }

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

    public override string ToString() {
      return "Car Model: " + Petname;
    }


    //public int CompareTo(object obj) {

    //  if(obj is Car) {
    //    if(this.CarID > ((Car)obj).CarID)
    //      return 1;
    //    if(this.CarID < ((Car)obj).CarID)
    //      return -1;
    //    else
    //      return 0;
    //  }
    //  else {
    //    throw new ArgumentException("Parameter is not a car");
    //  }
      
    //}
    public int CompareTo(object obj) {
      if(obj is Car)
        return this.CarID.CompareTo(((Car)obj).CarID);
      else
        throw new ArgumentException("Parameter is not a car");
    }
  }
}
