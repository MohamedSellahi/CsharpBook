using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleException {
  [Serializable]
  class CarIsDeadException3 : ApplicationException {
    /**
    Best practices for Exception in .NET:
    - Derives from Exception/ApplicationException
    - Is marked with the [System.Serializable] attribute
    - Defines a default constructor
    - Defines a constructor that sets the inherited Message property
    - Defines a constructor to handle “inner exceptions”
    - Defines a constructor to handle the serialization of your type
    */
    public CarIsDeadException3() { }
    public CarIsDeadException3(string message) : base(message) { }
    public CarIsDeadException3(string message, System.Exception inner) : base(message, inner) { }
    protected CarIsDeadException3(
                                  System.Runtime.Serialization.SerializationInfo info,
                                  System.Runtime.Serialization.StreamingContext context)
                                  :base(info, context) {}

    
  }
}
