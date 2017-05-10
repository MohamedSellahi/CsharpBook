using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator {
  class Program {
    static void Main(string[] args) {

      CityInfo NYC = new CityInfo("New York City", "United States of America", 8175133);
      CityInfo Det = new CityInfo("Detroit", "United States of America", 713777);
      CityInfo Paris = new CityInfo("Paris", "France", 2193031);
      CityInfo[] cities = { NYC, Det, Paris };
      // Display ordered array.
      DisplayArray(cities);

      // sort by name 
      Console.WriteLine("\n----- Sorting bu Name -----\n");
      Array.Sort(cities, CityInfo.CompareByName);
      DisplayArray(cities);

      // sort by population 
      Console.WriteLine("\n----- Sorting bu Population -----\n");
      Array.Sort(cities, CityInfo.CompareByName);
      DisplayArray(cities);

      // sort by country + name
      Console.WriteLine("\n----- Sorting bu Names -----\n");
      Array.Sort(cities, CityInfo.CompareByNames);


    }



    private static void DisplayArray(CityInfo[] cities) {
      Console.WriteLine("{0,-20} {1,-25} {2,10}", "City", "Country", "Population");
      foreach (var city in cities)
        Console.WriteLine("{0,-20} {1,-25} {2,10:N0}", city.City,
                          city.Country, city.Population);
    }


  }
}
