using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddWithThreadsAsync {
   class AddParams {
      private int _a, _b;
      public int a { get; set; }
      public int b { get; set; }

      public AddParams(int num1, int num2) {
         a = num1;
         b = num2;
      }
   }
}
