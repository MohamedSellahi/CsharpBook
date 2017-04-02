using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator {
  internal class Garage:IEnumerable {
    private Car[] _carArray = new Car[4];

    public Garage() {
      _carArray[0] = new Car("Rusty", 30);
      _carArray[1] = new Car("Clunker", 55);
      _carArray[2] = new Car("Zippy", 30);
      _carArray[3] = new Car("Fred", 30);
    }

    public IEnumerator GetEnumerator() {
      // returns the array objects IEnumerator
      return _carArray.GetEnumerator();
    }

  }
}