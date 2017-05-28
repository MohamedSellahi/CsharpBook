using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceHierarchy {
  /// <summary>
  /// Exctendig the drawable interface 
  /// </summary>
  interface IAdvancedDraw: IDrawable {
    void DrawInBoundinBox(int top, int left, int bottem, int right);
    void DrawUpsideDown();
  }
}
