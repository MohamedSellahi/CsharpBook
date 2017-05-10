using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConvesion {
  partial class Program {

    public struct Rectangle {
      public int Width { get; set; }
      public int Hight { get; set; }

      public Rectangle(int w, int h) : this() {
        Width = w;
        Hight = h;
      }

      public override string ToString() {
        return String.Format("[width = {0}; hight = {1}]", Width, Hight);
      }

      public void Draw() {
        for (int i = 0; i < Hight; i++) {
          for (int j = 0; j < Width; j++) {
            Console.Write("# ");
          }
          Console.WriteLine();
        }
        Console.WriteLine();
      }

      public static implicit operator Rectangle(Square s) {
        return new Rectangle(2 * s.Side, s.Side);
      }


    }

    public struct Square {
      public int Side { get; set; }
      public Square(int s) : this() {
        Side = s;
      }

      public override string ToString() {
        return String.Format("[Side = {0}]", Side);
      }

      public void Draw() {
        for (int i = 0; i < Side; i++) {
          for (int j = 0; j < Side; j++) {
            Console.Write("# ");
          }
          Console.WriteLine();
        }
        Console.WriteLine();
      }

      public static explicit operator Square(Rectangle r) {
        return new Square(r.Width);
      }

      public static explicit operator Square(int s) {
        return new Square(s);
      }


    }


  }
}
