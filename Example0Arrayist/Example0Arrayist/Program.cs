using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example0Arrayist {
  class Program {
    static void Main(string[] args) {
      ArrayList strArray = new ArrayList();
      strArray.AddRange(new string[] { "First", "Second", "third" });

      // Show nuber of items array list
      Console.WriteLine("the collestion has {0} items",strArray.Count);
      Console.WriteLine();

      // 
      strArray.Add("Fourth!");
      Console.WriteLine("the collestion has {0} items", strArray.Count);

      // can we mix data types 
      strArray.Add(5);
      IEnumerator i = strArray.GetEnumerator();
      while (i.MoveNext()) {
        Console.WriteLine(i.Current);
      }

      // yes !
      // display contents
      foreach (var item in strArray) {
        Console.WriteLine("Entry: {0}", item);
      }




    }
  }
}
