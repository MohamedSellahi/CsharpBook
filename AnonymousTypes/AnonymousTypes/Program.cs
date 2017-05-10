using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Fun with anonymous types\n");

      var myCar = new { Color = "Bright Pink", Make = "BMW", Speed = 55 };
      Console.WriteLine("myCar is {0} {1}", myCar.Color, myCar.Make);

      // call the helper method
      BuildOnType("Ford", "Black", 100);
      Console.WriteLine();

      // the internal representaion of annonymous types 
      ReflectOnAnonymous(myCar);
      Console.WriteLine();

      // equality test 
      EqualityTest();
      Console.WriteLine();

      // making anonymous types that are composed of other anonymous types 

      var purcheasedItem = new {
        TimeBought = DateTime.Now,
        ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = 55 },
        Price = 34000
      };

      ReflectOnAnonymous(purcheasedItem);


    }

    

    static void BuildOnType(string make, string color, int currSp) {
      // build on type using incoming args; 
      var car = new { Make = make, Color = color, Speed = currSp };

      // using this type to get property data
      Console.WriteLine("You have a {0} {1} going {2} kmH", 
                        car.Color, car.Make, car.Speed);

      // Annon types have custom implementation of virtual 
      // methods of the System.Object class 
      Console.WriteLine("ToString() == {0}", car.ToString());
    }

    static void ReflectOnAnonymous(object obj) {
      Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
      Console.WriteLine("Base class of {0} is {1}", 
                        obj.GetType().Name, obj.GetType().BaseType);
      Console.WriteLine("obj.ToString() = {0}", obj.ToString());
      Console.WriteLine("obj.GetHashCode() = {0}", obj.GetHashCode());

    }

    static void EqualityTest() {
      var firstCar = new { Make = "FORD", Color = "Black", Speed = 55 };
      var secondCar = new { Make = "FORD", Color = "Black", Speed = 55 };
      
      // are they considered equal when using Equals()
      if(firstCar.Equals(secondCar))
        Console.WriteLine("Same anonyous object, using Equals()");
      else
        Console.WriteLine("not the same anonymous type");

      // are they equals using == ?
      if(firstCar == secondCar)
        Console.WriteLine("Same anonymous object, using ==");
      else
        Console.WriteLine("Not the same anonymous object using ==!");

      // are the objects the same underlying type 
      if(firstCar.GetType().Name == secondCar.GetType().Name)
        Console.WriteLine("We are both the same type!");
      else
        Console.WriteLine("We are differnet types !");

      


    }


  }
}
