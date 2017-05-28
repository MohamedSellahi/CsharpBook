using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtension {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun Interface Compatible Types\n");
      // System.Array implements IEnumerable!
      string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun!" };
      data.PrintDataAndBeep();
      Console.WriteLine();

      // List<T> implements IEnumerable
      List<int> myInt = new List<int>() { 10, 15, 20 };
      myInt.PrintDataAndBeep();

    }

  }
}
