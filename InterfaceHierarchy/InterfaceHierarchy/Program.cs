using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Simple Interface Hierarchy *****");
      // Call from object level
      BitmapImage myBitmap = new BitmapImage();
      myBitmap.Draw();
      myBitmap.DrawInBoundinBox(10,10,20,20);
      myBitmap.DrawUpsideDown();

      // Get IAdvancedDraw explicitly
      IAdvancedDraw iADraw = myBitmap as IAdvancedDraw;
      if (iADraw != null)
        iADraw.DrawUpsideDown();


    }
  }
}
