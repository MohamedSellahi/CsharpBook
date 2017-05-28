using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// template class
// where keyword can add contraints on the type supported by the template class
//
// class Point<T> where T: class, IDrawable, new()
namespace GenericPoint {

  class Point<T> where T: struct {
    private T Xpos;
    private T Ypos;

    // generic constructor 
    public Point(T xVal, T yVal) {
      Xpos = xVal;
      Ypos = yVal;
    }

    public T XPOS { get { return Xpos; } set { Xpos = value; } }
    public T YPOS { get { return Ypos; } set { Ypos = value; } }

    public override string ToString() {
      return string.Format("[{0} {1}]", Xpos, Ypos);
    }

    public void ResetPoint() {
      Xpos = default(T);
      Ypos = default(T);
    }


  }
}
