using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSetOperations {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("\n***** Display Diff (Except) *****");
      DisplayDiff();
      Console.WriteLine("\n***** Display intersect *****");
      DisplayIntersect();
      Console.WriteLine("\n***** Display Union *****");
      DisplayUnion();
      Console.WriteLine("\n***** Display Concatenation  *****");
      DisplayConcat();
      Console.WriteLine("\n***** Display Distinct  *****");
      DisplayDistinct();

    }

    /* Excepte method */
    static void DisplayDiff() {
      List<string> mycars = new List<string> { "Yugo", "Aztec", "BMW" };
      List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

      var carDiff = (from c in mycars select c).Except(from c2 in yourCars select c2);

      Console.WriteLine("Set1");
      foreach (var item in mycars) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();

      Console.WriteLine("Set2");
      foreach (var item in yourCars) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();
      Console.WriteLine("Set1 except set2 : ");
      foreach (var item in carDiff) {
        Console.WriteLine(item);
      }
    }

    /* Intersect method */
    static void DisplayIntersect() {
      List<string> mycars = new List<string> { "Yugo", "Aztec", "BMW" };
      List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

      var carDiff = (from c in mycars select c).Intersect(from c2 in yourCars select c2);

      
      Console.WriteLine("Set1 intersect set2 : ");
      foreach (var item in carDiff) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();
    }

    /* Union method: discards repeated items  */
    static void DisplayUnion() {
      List<string> mycars = new List<string> { "Yugo", "Aztec", "BMW" };
      List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

      var carDiff = (from c in mycars select c).Union(from c2 in yourCars select c2);

      Console.WriteLine("Set1 Union set2 : ");
      foreach (var item in carDiff) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();
    }

    /* Concat method */
    static void DisplayConcat() {
      List<string> mycars = new List<string> { "Yugo", "Aztec", "BMW" };
      List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

      var carDiff = (from c in mycars select c).Concat(from c2 in yourCars select c2);

      Console.WriteLine("Set1 Concat set2 : ");
      foreach (var item in carDiff) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();
    }

    /* Distinct: removes duplicate entries */
    static void DisplayDistinct() {

      List<string> mycars = new List<string> { "Yugo", "Aztec", "BMW" };
      List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

      var carDiff = ((from c in mycars select c).Concat(from c2 in yourCars select c2)).Distinct();

      Console.WriteLine("Set1 Concat set2 : ");
      foreach (var item in carDiff) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();
    }
  }

}
