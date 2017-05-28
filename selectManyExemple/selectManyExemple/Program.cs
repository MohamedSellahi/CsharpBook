using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selectManyExemple {
  class Program {
    static void Main(string[] args) {
      SelectManyEx1();
      SelectEx2();


    }

    public  static void SelectManyEx1() {
      PetOwner[] petOwners = {
        new PetOwner{Name="Anthony, Hopkins",
            Pets = new List<string>{"Scruffy", "Sam"}},
        new PetOwner{Name="Mell, Gibbson",
            Pets = new List<string>{"walker", "Sugar"} },
        new PetOwner{Name="Brad, Pitt",
            Pets = new List<string>{"Scratches","Diesel"}}
      };

      // query using select many 
      IEnumerable<string> query1 = petOwners.SelectMany(petOwner => petOwner.Pets);
      Console.WriteLine("Using SelectMany():");

      // Only one foereach loop is required to iterate 
      // over the results since it is a one-dimenssional 
      // array of strings 
      foreach (string pet in query1) {
        Console.WriteLine(pet);
      }
      Console.WriteLine("--------------");

    }

    public static void SelectEx2() {
      PetOwner[] petOwners = {
        new PetOwner{Name="Anthony, Hopkins",
            Pets = new List<string>{"Scruffy", "Sam"}},
        new PetOwner{Name="Mell, Gibbson",
            Pets = new List<string>{"walker", "Sugar"} },
        new PetOwner{Name="Brad, Pitt",
            Pets = new List<string>{"Scratches","Diesel"}}
      };

      IEnumerable<List<string>> query = petOwners.Select(petOwner => petOwner.Pets);
      Console.WriteLine("Using Select");
      foreach (List<string> pets in query) {
        foreach (string pet in pets) {
          Console.WriteLine(pet);
        }
        Console.WriteLine("---------");

      }

    }
  }
}
