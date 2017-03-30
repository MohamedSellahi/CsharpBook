using System;

namespace CustomInterface {
   class Triangle : Shape, IPointy {

    public Triangle(string name = "NoName") : base(name) {

    }

    public override void Draw() {
      Console.WriteLine("Drawing triangle {0}", PetName); ;
    }

    public byte Points {
      get {
        return 3;
      }
    }

    public byte GetNumberofPoints() {
      return 3;
    }
  }
}