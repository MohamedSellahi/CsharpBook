using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  class Knife:IPointy {

    public Knife() {}

    public byte Points {
      get {
        return 1;
      }
    }

    public byte GetNumberofPoints() {
      return 1;
    }

    

  }
}
