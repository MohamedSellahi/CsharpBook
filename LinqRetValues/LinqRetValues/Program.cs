using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues {
  class Program {
    static void Main(string[] args) {

      string[] res1 = GetStringSubset().ToArray();
      foreach (string item in res1) {
        Console.WriteLine(item);
      }

      Console.WriteLine("-----------------");
      /* use immediate execution */
      string[] res2 = GetStringSubsetAsArray();
      foreach (var item in res2) {
        Console.WriteLine(item);
      }

    }

    static IEnumerable<string> GetStringSubset() {
      string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
      return (from c in colors
              where c.Contains("Red")
              select c);
    }

    static string[] GetStringSubsetAsArray() {
      string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
      var theRedColors = from c in colors
                         where c.Contains("Red")
                         select c;
      return theRedColors.ToArray<string>();

    }
    


  }
}
