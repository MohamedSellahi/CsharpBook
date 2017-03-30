using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  class ThreeDCircle:Circle, IDraw3D {

    public ThreeDCircle() {}
    public ThreeDCircle(string name):base(name) {

    }

    public void Draw3D() {
      Console.WriteLine("Drawing Circle in 3D!");
    } 
  }
  
}
