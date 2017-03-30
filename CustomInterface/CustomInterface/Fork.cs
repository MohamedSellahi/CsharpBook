using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  class Fork:IPointy {

    public Fork() {}

    public byte Points {
      get {
        return 4;
      }
    }

    public byte GetNumberofPoints() {
      return 4;
    }
  }
}
