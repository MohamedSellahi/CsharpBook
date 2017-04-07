using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrofittingEventArgs {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("More about Lambdas ");
      Car c = new Car("FORD", 200, 10);

      // Hook events with lambdas 
      c.Exploided += (sender, e) => { Console.WriteLine(e._message); };
      c.GonnaBlow += (sender, e) => { Console.WriteLine(e._message); };

      Console.WriteLine("***** Speeding up");
      for (int i = 0; i < 15; i++) {
        c.Accelerate(20);
      }


    }

  }
}
