using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  interface IPointy {

    // A read write in an interface would look like 
    // retType PropName{get; set;}
    // 
    //
    // while a write-only property in an interface would look like 
    // retType porpname{get;}

    byte Points { get; }
    byte GetNumberofPoints();


  }
}
