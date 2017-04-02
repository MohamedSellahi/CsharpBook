using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar {
  class CarIDComparer : IComparer {
    public int Compare(object x, object y) {
      Car c1 = x as Car;
      Car c2 = y as Car;
      if (c1 != null && c2 != null) {
        if (c1.CarID > c2.CarID)
          return 1;
        else if (c1.CarID < c2.CarID)
          return -1;
        else
          return 0;
      }
      else {
        throw new ArgumentException("Parameter is not a of Car type");
      }

    }
  }
}
