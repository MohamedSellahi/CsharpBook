using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtension {
  static class MyExtensions { // this class exctends any class that implements the IEnumerable interface

    public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator) {
      foreach (var item in iterator) {
        Console.WriteLine(item);
        Console.Beep();
      }
    }


  }


}
