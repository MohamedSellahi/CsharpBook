using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate {
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


    // 1) Define a delegate type. Can be declared outside the class. We prefere declaring 
    //    inside the class to inforce the idea of delegate type being concerned the class 
    //    in hand 
    public delegate void CarEngineHandler(string msgForCaller);

    // 2) define a member variable for this delegate;
    private CarEngineHandler listOfhandlers = null;

    // 3) Add registration function for the caller (helper function to add method to be called );
    public void RegisterWithCarEngine(CarEngineHandler methodtoCall) {
      // Enabling Multicast:
      // Delegates have the ability to multicast: which means delegate type can hold a 
      // mist of methods to call. we use the overloaded operator += : resolves to Delegate.Combine();
      if (listOfhandlers == null)
        listOfhandlers = methodtoCall;
      else
        listOfhandlers += methodtoCall;
      // listOfhandlers = (CarEngineHandler)Delegate.Combine(listOfhandlers, methodtoCall);
    }


    // 4) Implement accelerate method to invoke the delegate's 
    // invokation list under correct circumstances 

    public void Accelerate(int delta) {
      // if car is dead send death message
      if (CarIsDead) {
        if (listOfhandlers != null)
          listOfhandlers("Sorry, this car is dead");
      }
      else {
        CurrentSpeed += delta;
        // Is this car almose dead ?
        if (MaxSpeed - CurrentSpeed == 10 && listOfhandlers != null) {
          listOfhandlers("Carefull buddy, this car is gonna blow!");
        }
        if (CurrentSpeed >= MaxSpeed)
          CarIsDead = true;
        else
          Console.WriteLine("Current Speed = {0}", CurrentSpeed);


      }
    }

    // Can Id do it via propety 
    public CarEngineHandler Handlers {
      get { return listOfhandlers; }
      set {
        if (listOfhandlers == null)
          listOfhandlers = value;
        else
          listOfhandlers += value;
      }
    }

    // Unrigistering 
    public void UnRegisterWithCarEngine(CarEngineHandler methodToCall) {
      listOfhandlers -= methodToCall;
    }


  }
}
