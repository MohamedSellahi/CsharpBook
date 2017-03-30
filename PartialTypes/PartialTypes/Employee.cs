using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialTypes {
  partial class Employee {
    // Methods and properties 
    public string NAME { get; set; }
    public int AGE { get; set; }


    public override string ToString() {
      return String.Format("Name: {0}, Age: {1}", NAME, AGE);
    }


    
  }




}
