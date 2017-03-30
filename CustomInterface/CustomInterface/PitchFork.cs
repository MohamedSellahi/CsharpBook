using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  class PitchFork: IPointy {
    public PitchFork() {}

    public byte Points {
      get {
        return 3;
      }
    }

    public byte GetNumberofPoints() {
      return 3;
    }
  }

}
