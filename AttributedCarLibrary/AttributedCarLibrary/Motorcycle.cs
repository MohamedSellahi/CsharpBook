using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributedCarLibrary {
  // assign description using a named property
  [Serializable]
  [VehicleDescription(Description ="My rocking Harley")]
  public class Motorcycle {

  }


  //
  [SerializableAttribute]
  [Obsolete("Use another vehicle!")]
  [VehicleDescription("The old gray mare, she ain't what shed she used to be ...")]
  public class HorsAndBuggy {

  }

  [VehicleDescription("a Very long, slow, but feature rich auto")]
  public class Winnebago {


    // attibutes can be applied to any aspect of the code : classes, properties ...
    [VehicleDescription("My rocking CD player")]
    public void PlayMusic(bool on) { }

  }


  /* Restricting the use of attributes to some kind of codes 
   * we can use [Attributeusage] attribute and supply any 
   * combination of values from Attributetargets enum 
   * see new definition of 
   **/


}
