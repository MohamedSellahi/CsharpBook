using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy {
  class BitmapImage : IAdvancedDraw {


    public void Draw() {
      Console.WriteLine("Drawing ...");
    }

    public void DrawInBoundinBox(int top, int left, int bottem, int right) {
      Console.WriteLine("Drawing in a box ...");
    }

    public void DrawUpsideDown() {
      Console.WriteLine("Draw upside down ...");
    }


  }
}
