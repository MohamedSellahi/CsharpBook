using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable {
  class Program {
    static void Main(string[] args) {
      QueryStringsWthOperator();
      Console.WriteLine();
      QueryStringsWithEnumerableAndLambda1();
      Console.WriteLine();
      QueryStringsWithEnumerableAndLambda2();
      Console.WriteLine();
      QueryStringsWithAnonymousMethods();
      Console.WriteLine();
      CustomQuery.QuaryStringWithRawDelegate();


    }


    /* simple query */
    static void QueryStringsWthOperator() {
      Console.WriteLine("***** Using Query Operators *****");
      string[] games = {"Morrowind", "Uncharted 2",
        "Fallout 3", "Daxter", "System Shock 2"};
      var subset = from g in games
                   where g.Contains(" ")
                   orderby g
                   select g;
      foreach(var item in subset) {
        Console.WriteLine("Item: {0}", item);
      } 

    }

    /* query with Enumerable and lambdas */
    static void QueryStringsWithEnumerableAndLambda1() {
      Console.WriteLine("***** Using Enumerable and Lambda 1*****");
      string[] games = {"Morrowind", "Uncharted 2",
                                    "Fallout 3", "Daxter", "System Shock 2"};
      var subset = games.Where(g => g.Contains(" "))
                        .OrderBy(g => g)
                        .Select(delegate (string g) {
                          if(g.Contains("2"))
                            return g.ToUpper();
                          return g;
                        });

      foreach(var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }


    }

    /* building query using Enumerable and lambda expressions */
    static void QueryStringsWithEnumerableAndLambda2() {
      Console.WriteLine("***** Using Enumerable and Lambda 2*****");
      string[] games = {"Morrowind", "Uncharted 2",
                                    "Fallout 3", "Daxter", "System Shock 2"};
      var gamesWithSpaces = games.Where(g => g.Contains(" "));
      var orderedGames = gamesWithSpaces.OrderBy(g => g);
      var selectGames = orderedGames.Select(g => g);

      foreach(var item in selectGames) {
        Console.WriteLine("Item: {0}", item);
      }
    }

    /* building expression with anonymous methods */
    static void QueryStringsWithAnonymousMethods() {
      Console.WriteLine("***** Using Anonymous Methods *****");
      string[] games = {"Morrowind", "Uncharted 2",
        "Fallout 3", "Daxter", "System Shock 2"};

      /* build the necessary Func<> delegates using anonymous 
       methods */
      Func<string, bool> searchFilter = delegate (string s) // where clause 
                                        { return s.Contains(" "); };
      Func<string, string> ItemsToProcess = delegate (string s) // select/orderby clause 
                                            { return s; };
      var subset = games.Where(searchFilter)
                        .OrderBy(ItemsToProcess)
                        .Select(ItemsToProcess);
      foreach(var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }

    }

    



  }
}
