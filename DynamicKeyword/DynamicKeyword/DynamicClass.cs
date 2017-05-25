using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword {
  class DynamicClass {
    // dynamic field 
    private static dynamic myDynamicField;
    // dynamic property 
    public dynamic DynamicProperty { get; set; }
    // dynamic return type

    public dynamic DynamicMethod(dynamic dynamicParam) {
      // dynanic Local variable 
      dynamic dynamicLocalVar = "Local Variable"; 

      int myInt = 10;
      if (dynamicParam is int)
        return dynamicLocalVar;
      else
        return myInt; 
    }

  }
}
