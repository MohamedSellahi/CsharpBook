using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollection {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("**** LINQ ******");

      List<Car> myCars0 = new List<Car>{
        new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
        new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
        new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
        new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
        new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
      };


      /* accessing containded objects */
      GetFastestCars(myCars0);
      GetFastesBMW(myCars0);

      /* Applying LINQ queries to non generic collections */
      Console.WriteLine("\n***** LINQ over ArrayList *****");
      // Here is a non generic collection of cars

      ArrayList myCars1 = new ArrayList(){
        new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
        new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
        new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
        new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
        new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
      };
      LINQOverArrayList(myCars1);

      /*Filtering data using oftype() */
      Console.WriteLine("\n***** Filtering Data *****");
      ofTypeAsFilter();



    }


    static void GetFastestCars(List<Car> myCars) {
      var fastCars = from c in myCars
                        where c.Speed > 55
                        select c;
      foreach (var item in fastCars) {
        Console.WriteLine("{0} is going to fast! ", item.PetName);
      }
      //Console.WriteLine(fastCars.GetType().Name);
    }

    /* more complex query */
    static void GetFastesBMW(List<Car> myCars) {
      var fastCars = from c in myCars
                     where c.Make == "BMW" && c.Speed > 90
                     select c;
      foreach (var item in fastCars) {
        Console.WriteLine("{0} is going too fast!", item.PetName);
      }
      //Console.WriteLine(fastCars.GetType().Name);
    }

    /**/
    static void LINQOverArrayList(ArrayList myCars) {

      /* Transform ArrayList into an IEumerable<T> compatible type */
      var myCarsEnum = myCars.OfType<Car>();
      /* Query expression target a compâtible type */
      var fastCars = from c in myCarsEnum
                     where c.Speed > 55
                     select c;

      foreach (var item in fastCars) {
        Console.WriteLine("{0} is going too fast!", item.PetName);
      }
      //Console.WriteLine(myCarsEnum.GetType().Name);

    }

    /* Filtering data using oftype */

    static void ofTypeAsFilter() {
      // Extract the ints from the ArrayList

      ArrayList myStuff = new ArrayList();

      myStuff.AddRange(new object[] { 100, 400, 8, false, new Car(), "String Data" });
      /* extract a IEnumerable<int> from myStuff */
      var myInts = myStuff.OfType<int>();
      var myIntsSubset = from i in myInts
                         where i > 10
                         select i;
      foreach (var item in myInts) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();

      foreach (var item in myIntsSubset) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();


    }



  }
}
