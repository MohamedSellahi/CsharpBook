using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this helper class is used to sort an array of Cars by petName.
namespace ComparableCar {
  public class PetNameComparer : IComparer {

    // Test the petName for each object 
    public int Compare(object x, object y) {
      Car t1 = x as Car;
      Car t2 = y as Car;
      if (t1 != null && t2 != null)
        return String.Compare(t1.Petname, t2.Petname);
      else
        throw new ArgumentException("Parameter is not a Car!");

    }
  }
}
