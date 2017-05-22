using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary {
  /* Restricting the use of attributes to some kind of codes 
  * we can use [Attributeusage] attribute and supply any 
  * combination of values from Attributetargets enum 
  * see new definition of 
  **/
  public sealed class VehicleDescriptionAttribute: Attribute {
    public string Description { get; set; }

    public VehicleDescriptionAttribute() {}
    public VehicleDescriptionAttribute(string vehicleDescription) {
      Description = vehicleDescription;
    }

  }


}
