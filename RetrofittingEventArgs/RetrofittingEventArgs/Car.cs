using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrofittingEventArgs {
  class Car {
    // internal state data
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; }
    public string PetName { get; set; }

    // is the car alive or dead 
    private bool CarIsDead;

    // Constructors 
    public Car() {
      MaxSpeed = 100;
    }
    public Car(string name, int maxSpeed, int currSpeed) {
      PetName = name;
      MaxSpeed = maxSpeed;
      CurrentSpeed = currSpeed;
    }

    // definting the delegate 

    public delegate void CarEngineHandler(object sender, CarEventArgs e);

    public event CarEngineHandler Exploided;
    public event CarEngineHandler GonnaBlow;

    public void Accelerate(int delta) {
      if (CarIsDead)
        Exploided(this, new CarEventArgs("Sorry this car is dead!"));
      else {
        CurrentSpeed += delta;
        if (MaxSpeed - CurrentSpeed <= 10 && GonnaBlow != null) {
          GonnaBlow(this, new CarEventArgs("Carefully buddy! "));
        }
        // still ok 
        if (CurrentSpeed >= MaxSpeed)
          CarIsDead = true;
        else
          Console.WriteLine("Current speed = {0}", CurrentSpeed);





      }

    }


  }


}
