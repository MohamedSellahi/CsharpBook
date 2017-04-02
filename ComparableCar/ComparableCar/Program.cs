using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Object Sorting *****");
      // make an array of Car objects
      Car[] myCars = new Car[5];

      myCars[0] = new Car("Rusty", 80, 1);
      myCars[1] = new Car("Mary", 40, 234);
      myCars[2] = new Car("Viper", 40, 34);
      myCars[3] = new Car("Mel", 40, 4);
      myCars[4] = new Car("Chucky", 40, 5);
      foreach(var item in myCars) {
        Console.WriteLine(item);
      }
      try {
        Console.WriteLine("\nSorted cars ");
        Array.Sort(myCars);
        foreach(var item in myCars) {
          Console.WriteLine(item);
        }

        // sort by petName
        Console.WriteLine("\nSorting by Name");
        Array.Sort(myCars, new PetNameComparer());
        foreach (Car item in myCars) {
          Console.WriteLine(item);
        }

        Console.WriteLine("\nSorting by Name using Custom propertie");
        Array.Sort(myCars, Car.SortByName);
        foreach (var item in myCars) {
          Console.WriteLine(item);
        }

      }
      catch(Exception e) {

        Console.WriteLine(e);
      }



    }
  }
}
