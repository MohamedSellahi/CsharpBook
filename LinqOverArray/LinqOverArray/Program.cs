using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with LINQ to Objects *****");
      QueryOverStrings();
      Console.WriteLine();
      QueryOverStringLongHand();
    }


    static void QueryOverStrings() {
      /* sample array of strings */
      string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3",
                                    "Daxter", "System Shock 2", "Uncharted 2"};
      /*obtain items that have embedded spaces */
      IEnumerable<string> subset = from g in currentVideoGames
                                   where g.Contains(" ")
                                   orderby g
                                   select g;
      // printout the result 
      foreach (var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }

    }

    static void QueryOverStringLongHand() {
      string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3",
                                    "Daxter", "System Shock 2", "Uncharted 2"};
      List<string> gamesWithSpaces = new List<string>();

      for (int i = 0; i < currentVideoGames.Length; i++) {
        if (currentVideoGames[i].Contains(" ")) {
          gamesWithSpaces.Add(currentVideoGames[i]);
        }
      }

      // now sort the result 
      gamesWithSpaces.Sort();
      foreach (var item in gamesWithSpaces) {
        if (item != null) {
          Console.WriteLine("Item: {0}",item);
        }
      }

    }



  }
}
