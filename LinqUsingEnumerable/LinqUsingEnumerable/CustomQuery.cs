using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable {
  class CustomQuery {

    
    /* building queries using raw delegates */
    public static void QuaryStringWithRawDelegate() {
      Console.WriteLine("***** Using Raw Delegates *****");
      string[] Games = {"Morrowind", "Uncharted 2",
        "Fallout 3", "Daxter", "System Shock 2"};
      /* build the necessary delegates */
      Func<string, bool> searchFilter = new Func<string, bool>(Filter);
      Func<string, string> itemPrecessor = new Func<string, string>(ProcessItem);
      // pass the delegates to the methods of Enumerable 
      var subset = Games.Where(searchFilter)
                        .OrderBy(itemPrecessor)
                        .Select(itemPrecessor);

      foreach(var item in subset) {
        Console.WriteLine("Item: {0}", item);
      }

    }



    /*delegate targets */
    public static bool Filter(string s) { return s.Contains(" "); }
    public static string ProcessItem(string s) { return s; }
  }
}
