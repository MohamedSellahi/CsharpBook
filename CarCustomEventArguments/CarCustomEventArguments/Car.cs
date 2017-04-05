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
    public delegate void MyHandler(int x);


    


    // this car can send this events 
    public event CarEngineHandler Exploaded;
    public event CarEngineHandler AboutToBlow;



    // Using th egneric event handler 
    public event EventHandler<CarEventArgs> Exploaded2;
    public event EventHandler<CarEventArgs> AboutToBlow2;

    public void Accelerate(int delta) {
      // if car is dead, fire exploided event ; 
      if (CarIsDead) {
        if (Exploaded != null) {
          Exploaded(this, new CarEventArgs("Sorry this car is dead..."));
          Exploaded2(this, new CarEventArgs("SORRY THIS CAR IS DEAD..."));
        }
      }
      else {
        CurrentSpeed += delta;
        // Almost dead ?
        if (MaxSpeed - CurrentSpeed <= 10 && AboutToBlow != null) {
          AboutToBlow(this, new CarEventArgs("Carefully buddy! Gonna blow!"));
          AboutToBlow2(this, new CarEventArgs("CAREFULLY BUDDY! GONNA BLOW"));
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
