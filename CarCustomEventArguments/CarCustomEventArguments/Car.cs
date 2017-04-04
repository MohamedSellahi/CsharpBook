using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCustomEventArguments {
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

    // defining the delegate that holds methods to be called 
    // in relation with the engine health
    // this delegate works in conjunction with the Cars events 
    public delegate void CarEngineHandler(object sender, CarEventArgs e);

    // this car can send this events 
    public event CarEngineHandler Exploded;
    public event CarEngineHandler AboutToBlow;

    public void Accelerate(int delta) {
      // if car is dead, fire exploided event ; 
      if (CarIsDead) {
        if (Exploded != null) {
          Exploded(this, new CarEventArgs("Sorry this car is dead..."));
        }
      }
      else {
        CurrentSpeed += delta;
        // Almost dead ?
        if (MaxSpeed - CurrentSpeed <= 10 && AboutToBlow != null)
          AboutToBlow(this, new CarEventArgs("Carefully buddy! Gonna blow!"));

        // still ok 
        if (CurrentSpeed >= MaxSpeed)
          CarIsDead = true;
        else
          Console.WriteLine("Current speed = {0}", CurrentSpeed);

      }
    }

  }
}
