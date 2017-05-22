using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary {
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited =false)]
  class VehicleResrtictedAttribute: Attribute {

  }
}
