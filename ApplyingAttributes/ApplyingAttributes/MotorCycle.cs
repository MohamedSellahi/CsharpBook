using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes {
  // This class can be saved to Disk;
  [Serializable, Obsolete("Use Another Vehicle")]
  class MotorCycle {
    // However; this field will not be persisted 
    [NonSerialized]
    float weightofCurrentPassengers;
    // this fields are still serializable ; 
    bool hasradioSystem;
    bool hasHeadSet;
    bool hasSissyBar;


  }
}
