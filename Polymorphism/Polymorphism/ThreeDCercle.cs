using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism {
  class ThreeDCercle:Cercle {
    public ThreeDCercle() {

    }


    public new void Draw() {
      Console.WriteLine("Drawing 3D cercle");
    }


  }
}
