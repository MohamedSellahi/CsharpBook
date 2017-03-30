using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueReference {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("Assigning value types\n");

      Point p1 = new Point(10, 10);
      Point p2 = p1;

      // 
      p1.Display();
      p2.Display();

      // change p1 is independant of p2

      p1.x = 100;
      p1.Display();
      p2.Display();

      // Change p1.x and point refs
      Console.WriteLine("----------------------");
      PointRef pref1 = new PointRef(10, 20), pref2 = pref1;
      pref1.Display();
      pref2.x = 1000;
      pref1.Display();

      // Value types containing reference types
      ValueTypeContainingRefType();






    }// end of main 

    public class Directeur {
      private float revenu;
      public float getRevenu() {
        return revenu;
      }
      public void setRevenu(float rev) {
        revenu = rev;
      }
    }
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
    // class is always reference type
    class PointRef {
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

      public PointRef(int xPos, int yPos) {
        x = xPos;
        y = yPos;
      }
    }
    class ShapeInfo {
      public string infoString;

      public ShapeInfo(string info) {
        infoString = info;
      }
    }
    struct Rectangle {
      // contains a reference type member
      public ShapeInfo rectInfo;
      public int rectTop, rectLeft, rectBottom, rectRight;

      public Rectangle(string info, int top, int left, int bottom, int right) {
        rectInfo = new ShapeInfo(info);
        rectTop = top;
        rectBottom = bottom;
        rectLeft = left;
        rectRight = right;
      }

      public void Display() {
        Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " + "Left = {3}, Right = {4}",
                          rectInfo.infoString, rectTop, rectBottom, rectLeft, rectRight);
      }

    }
    static void ValueTypeContainingRefType() {
      // create the first rectangle
      Console.WriteLine("--> creating r1\n");
      Rectangle r1 = new Rectangle("First rect", 10, 10, 50, 50);
      r1.Display();
      Rectangle r2 = r1;

      // Change some values of r2
      Console.WriteLine("--> changing values of r2\n");
      r2.rectInfo.infoString = "this is new info!";
      r2.rectBottom = 4444;

      // Print values of both rectangles 
      r1.Display();
      r2.Display();

    }




  }
}
