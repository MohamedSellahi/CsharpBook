using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable {
  class Program {
    public delegate string strSelector(string str);
    static void Main(string[] args) {
      QueryStringsWithOperators();
      QueryStringsWithEnumerableAndLambdas();
      QueryStringWithEnumerableAndLambda2();

    }


    static void QueryStringsWithOperators() {
      Console.WriteLine("***** Using Query Operators *****");
      string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

      var subset = from g in games
                   where g.Contains(" ")
                   select g;
      foreach (var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }


    }

    /*Builing query Expressions using IEnumerable type and 
      lambda expressions */

    static void QueryStringsWithEnumerableAndLambdas() {

      Console.WriteLine("***** Using Enumerable/lambda expressions *****");
      string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

      /* building a query expression using extension methods 
       * granted to the array via Enumerable type */


      var subset = games.Where(g => g.Contains(" "))
                        .OrderBy(g => g)
                        .Select(delegate (string g) {
                          if (g.Contains("2"))
                            return g;
                          else
                            return g.ToUpper();
                        });
      //.Select(g => g);
      
      foreach (var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }

    }

    static void QueryStringWithEnumerableAndLambda2() {
      Console.WriteLine("***** Using Enumerable/lambda expressions 2 *****");
      string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
      // Break it down 
      var gamesWithSpace = games.Where(g => g.Contains(" "));
      var orderedGames = gamesWithSpace.OrderBy(g => g);
      var subset = orderedGames.Select(g => g);

      foreach (var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }
    }

  }
}
