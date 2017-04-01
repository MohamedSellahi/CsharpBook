using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield {
  public class Garage : IEnumerable {
    private Car[] _carArray = new Car[4];

    public Garage() {
      _carArray[0] = new Car("Rusty", 30);
      _carArray[1] = new Car("Clunker", 55);
      _carArray[2] = new Car("Zippy", 30);
      _carArray[3] = new Car("Fred", 30);
    }

    //iTeraror method
    public IEnumerator GetEnumerator() {
      foreach(Car c in _carArray) {
        yield return c;
      }
    }

    //// annother possibility 
    //public IEnumerator GetEnumerator() {
    //  for(int i = 0; i < _carArray.Length; i++) {
    //    yield return _carArray[i];
    //  }
    //}

    // building a named Iterator 
    // use of 'yield' is possible in any method to 
    // i think this is possible since Array implements IEnumerable

    public IEnumerable GetTheCars(bool ReturnReverse) {
      if(ReturnReverse) {
        for(int i = _carArray.Length; i != 0; i--) {
          yield return _carArray[i - 1];
        }
      }
      else {
        for(int i = 0; i < _carArray.Length; ++i) {
          yield return _carArray[i];
        }
      }
    }



  }
}