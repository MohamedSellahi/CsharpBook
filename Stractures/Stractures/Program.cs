using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stractures {
  class Program {
    static void Main(string[] args) {
      Point p1;
      p1.x = 3;
      p1.y = 2;

      p1.Display();
      p1.Increment();
      p1.Display();
      // not assigning field : Error
      //Point p2;
      //p2.Display();

      // using the default constructor
      Point p3 = new Point();
      p3.Display();

      // using custom contructor 
      Point p4 = new Point(10, 12);
      p4.Display();




    }// end of main 

    struct Point {
      // fields 
      public int x;
      public int y; 

      // methods
      public void Increment() {
        ++x;
        ++y;
      }

      public void Decrement() {
        --x;
        --y;
      }

      public void Display() {
        Console.WriteLine("x = {0}, y = {1}", x, y);
      }

      // constrcutor 
      public Point(int xPos, int yPos) {
        x = xPos;
        y = yPos;
      }
    }



  }
}
