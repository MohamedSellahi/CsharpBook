using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialTypes {
  partial class Employee {
    //Field Data 
    private string _name;
    private int _age; 


    // constructors 

    public Employee() {
      NAME = "";
      _name = NAME;
      AGE = 0;
      _age = 0;
    }

    public Employee(string name, int age) {
      _name = NAME = name;
      _age = AGE = age; 

    }
    

  }
}
