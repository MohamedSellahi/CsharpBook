using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  class Hexagone: Shape, IPointy, IDraw3D {

    
    public Hexagone() {
    }

    public Hexagone(string name):base(name) {

    }



    public byte Points {
      get {
        return 6;
      }
    }

    public override void Draw() {
      Console.WriteLine("Drawing Hexagone {0}: ", PetName);
    }

    public void Draw3D() {
      Console.WriteLine("Drawing hexagon in 3D!");
    }

    public byte GetNumberofPoints() {
      return 6;
    }




  }
}
