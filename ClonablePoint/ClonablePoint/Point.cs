using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClonablePoint {
  class Point : ICloneable { // The point now supports clonability 

    public int X { get; set; }
    public int Y { get; set; }

    public PointDescription desc = new PointDescription();

    public Point(int x0, int y0) {
      X = x0;
      Y = y0;
    }
    public Point() { }

    public Point(int x0, int y0, string petName) {
      X = x0;
      Y = y0;
      desc.PetName = petName; 
    }

    public override string ToString() {
      return String.Format("X = {0}; Y = {1}; Name = {2}\n"+
                           "ID = {3}", X, Y, desc.PetName, desc.PointID);
    }

    //public object Clone() {

    //  return new Point(this.X, this.Y);
    //}

   // we can use MemberWiseCopy if the object does not contain
  //   members of reference type
    //public object Clone() {
    //  return this.MemberwiseClone();
    //}

    public object Clone() {
      // first get a shallow copy
      Point newPoint = (Point)this.MemberwiseClone();

      // fill in the gaps 
      PointDescription currentDesc = new PointDescription();
      currentDesc.PetName = this.desc.PetName; // 
      newPoint.desc = currentDesc;
      return newPoint;
    }




  }
}
