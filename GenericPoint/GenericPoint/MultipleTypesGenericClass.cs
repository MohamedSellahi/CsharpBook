using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericPoint {
  class MultipleTypesGenericClass<T,K> 
    where T: new() 
    where K: new(){

  }
}
