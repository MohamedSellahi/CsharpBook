using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism {
  public class NestedOuter {

    /// <summary>
    /// Inner class for the sake of example: a nested class can be declared private
    /// </summary>
    private class PrivateInnerClass {
      private int _innerInt;

      public PrivateInnerClass() { }
    };

    public class PublicInnerClass {
      public enum innerEnum {
        Item1,
        Item2,
        Item3
      }



      private int _innerInt;
      public PublicInnerClass(int val) {
        _innerInt = val;
      }
    }



  }
}