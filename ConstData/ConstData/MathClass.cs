using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData {
  class MathClass {
    public const double PI = 3.14;  // know at compile time, static implicitly
    public readonly double ROPI = 3.14; // can be assigned by constructor
    public static readonly double staticROPI; // 

    public MathClass() {
      ROPI = 3.1415;
    }

    public MathClass(double ReadOnlyPi) {
      ROPI = ReadOnlyPi;
    }


    static MathClass() { // serves to initialize static data at run time 
      staticROPI = 3.141516;
    }



  }
}
