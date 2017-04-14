using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomConversion {
  class Program {
    static void Main(string[] args) {

      Rectangle rec = new Rectangle();
      Console.WriteLine(rec);
      rec.Width = 20;
      rec.Hight = 10;
      rec.Draw();

      Console.WriteLine();
      Square sq = new Square(5);
      Console.WriteLine(sq);
      sq.Draw();
      Console.WriteLine();

      Square sq2 = (Square)rec;
      Console.WriteLine(sq2);
      sq2.Draw();

      Square sq3 = (Square)15;
      Console.WriteLine(sq3);
      sq3.Draw();


    }


    public struct Rectangle {
      public int Width { get; set; }
      public int Hight { get; set; }

      public Rectangle(int w, int h):this() {
        Width = w;
        Hight = h;
      }

      public void Draw() {
        for (int i = 0; i < Hight; i++) {
          for (int j = 0; j < Width; j++) {
            Console.Write('*');
          }
          Console.WriteLine();
        }
      }

      public override string ToString() {
        return String.Format("[Width = {0}; Hight = {1}]", Width, Hight);
      }

    }

    public struct Square {
      public int Side { get; set; }

      public Square(int s):this() {  // calling default constructor
        Side = s; 
      }

      public void Draw() {
        for (int i = 0; i < Side; i++) {
          for (int j = 0; j < Side; j++) {
            Console.Write('*');
          }
          Console.WriteLine();
        }
      }

      public override string ToString() {
        return String.Format("[Side = {0}]", Side);
      }
      // Rectangles cas be explicitly converted to squares 
      public static explicit operator Square(Rectangle r) {
        return new Square(r.Hight);
      }

      public static explicit operator Square(int side) {
        return new Square(side);
      }

    }




  }
}