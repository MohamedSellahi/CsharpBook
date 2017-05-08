using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQchapter0 {
  class Rectangle {
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle() {

    }
    
  }



  class Point {
    public int X { get; set; }
    public int Y { get; set; }

    public Point() {
    }
  }
}
