using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionMultipleParams {
  class SimpleMath {
    public delegate void MathMessage(string mes, int result);
    private MathMessage mmDelegate;

    public delegate string VerySimpleDelegate();

    public event VerySimpleDelegate SaySomething;

    public void SetMathHandler(MathMessage target) {
      mmDelegate = target;
    }

    public void Add(int x, int y) {
      if(mmDelegate != null) {
        mmDelegate("Adding has completed!", x + y);
      }
    }

    public void RaiseSAySomethingEvent() {
      if (SaySomething != null)
        Console.WriteLine(SaySomething()); 
      
    }
  }
}
