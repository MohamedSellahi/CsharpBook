using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;


namespace LinqOverArray {
  class Program {
    static void Main(string[] args) {
      QueryOverstrings();
      /* */
      Console.WriteLine();
      QueryOverStringLongHand();

      /* */
      Console.WriteLine();
      QueryOverInts();

      /* Linq and Extension methods 
       * Extends the functionnality of container like the Array class 
       * via the IEnumerable<T> interface used in the evaluation of 
       * many Linq centric operations (like queries ) 
       */

      /* Deferred Execution 
       * the fact that linq querries are not evaluated 
       * until we iterate over the result of the querrie
       * to insure that the result is uptodate 
       */

      Console.WriteLine();
      Console.WriteLine("Exemple of deferred execution ");
      QueryDeferredExecution();
      Console.WriteLine();

      /* Immediate Execusion
       * this enable to execute the querrie immidiately 
       * outside any foreach logic , for exemple to retreive 
       * the contents to an array
       */

      ImmediateExecution();

      
      
      
    }

    static void QueryOverstrings() {
      string[] games = {"Morrowind", "Uncharted 2","Fallout 3", "Daxter", "System Shock 2"};
      // build query 
      IEnumerable<string> subset = from g in games
                                   where g.Contains(" ")
                                   orderby g
                                   select g;
      foreach (string item in subset) {
        Console.WriteLine("Item: {0}", item);
      }

      REflectOverQueryResult(subset);


    }

    static void QueryOverStringLongHand() {
      string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
      //
      List<string> subset = new List<string>();
      for (int i = 0; i < games.Length; i++) {
        if (games[i].Contains(" ")) {
          subset.Add(games[i]);
        }
      }

      if (subset.Count != 0) {
        subset.Sort();
        foreach (string item in subset) {
          Console.WriteLine("Item: {0}", item);
        }
      }

    }

    static void REflectOverQueryResult(object resultSet) {
      Console.WriteLine("***** Info about the query *****");
      Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
      Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
    }

    static void QueryOverInts() {
      int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
      /* print only items less than 10 */
      IEnumerable<int> subset = from i in numbers
                                where i < 10
                                orderby i 
                                select i;
      foreach (int i in subset) {
        Console.WriteLine("Item:{0}", i);
      }
      REflectOverQueryResult(subset);

      /* Using IEnumerable collection */
      IEnumerable subset1 = from i in numbers
                            where i > 10
                            select i;
      foreach (int  i in subset1) {
        Console.WriteLine("Item: {0}", i);
      }
      REflectOverQueryResult(subset1);

      /* use of implicite typing */
      var subset2 = from i in numbers
                            where i > 10
                            select i;
      foreach (int i in subset2) {
        Console.WriteLine("Item: {0}", i);
      }
      REflectOverQueryResult(subset1);




    }

    static void QueryDeferredExecution() {
      int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
      /* print only items less than 10 */
      IEnumerable<int> subset = from i in numbers
                                where i < 10
                                orderby i
                                select i;
      /* Linq statment evaluated here */
      foreach (int i in subset) {
        Console.WriteLine("Item:{0} < 10 ?", i);
      }
      Console.WriteLine();

      /* make some changes to the array */
      numbers[0] = 4;
      foreach (int i in subset) {
        Console.WriteLine("Item:{0} < 10 ?", i);
      }

    }

    static void ImmediateExecution() {
      int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
      // get data right on as int array 
      int[] subsetArray = (from i in numbers
                      where i < 10
                      select i).ToArray<int>();
      List<int> subsetList = (from i in numbers
                          where i < 10
                          select i).ToList<int>();

      foreach (int i in subsetArray) {
        Console.WriteLine("Item:{0} > 10 ?", i);
      }


    }

  }
}
