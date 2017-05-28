using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoroveloading {
  class Point: IComparable<Point> {
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int xpos, int ypos) {
      X = xpos;
      Y = ypos;
    }

    public override string ToString() {
      return String.Format("[{0},{1}]", X, Y);
    }

    // Overload operator +
    public static Point operator+ (Point p1, Point p2) {
      return new Point(p1.X + p2.X, p1.Y + p2.Y);
    }

    // Overlaod operator -
    public static Point operator - (Point p1, Point p2) {
      return new Point(p1.X - p2.X, p1.Y - p2.Y);
    }

    public static Point operator +(Point p1, int change) {
      return new Point(p1.X + change, p1.Y + change);
    }

    // Overlaod operator -
    public static Point operator -(Point p1, int change) {
      return new Point(p1.X - change, p1.Y - change);
    }


    // Overlaod ++
    public static Point operator ++(Point p) {
      return new Point(p.X + 1, p.Y + 1);
    }

    // Overlaod --
    public static Point operator --(Point p) {
      return new Point(p.X - 1, p.Y - 1);
    }

    //Overlaod == != 

    public override bool Equals(object obj) {
      return obj.ToString() == this.ToString();
    }

    public override int GetHashCode() {
      return this.ToString().GetHashCode();
    }

    public int CompareTo(Point other) {
      if (this.X > other.Y && this.Y > other.Y)
        return +1;
      if (this.X < other.X && this.Y > other.Y)
        return -1;
      else
        return 0;
    }

    public static bool operator == (Point p1, Point p2) {
      return p1.Equals(p2);
    }

    public static bool operator !=(Point p1, Point p2) {
      return !p1.Equals(p2);
    }


    public static bool operator < (Point p1, Point p2) {
      return (p1.CompareTo(p2) < 0);
    }

    public static bool operator > (Point p1, Point p2) {
      return (p1.CompareTo(p2) > 0);
    }

    public static bool operator <=(Point p1, Point p2) {
      return (p1.CompareTo(p2) <= 0);
    }
    public static bool operator >= (Point p1, Point p2) {
      return (p1.CompareTo(p2) >= 0);
    }




  }
}
