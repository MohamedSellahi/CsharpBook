using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionMultipleParams {
  class Program {
    static void Main(string[] args) {

      // Register with delegate as lambda expression 
      SimpleMath m = new SimpleMath();
      m.SetMathHandler(( msg, result)
        => {
          Console.WriteLine("Message : {0}, Result: {1}", msg, result);
        });

      // this will execute the delegate as lambda expression 
      m.Add(10, 13);

      // regi
      m.SaySomething += (() => { return "Hello World"; });
      //m.SaySomething += delegate () { return "World"; };

      m.RaiseSAySomethingEvent();

      SimpleMath.MathMessage msgDelegate = new SimpleMath.MathMessage(Method1);
      msgDelegate += Method2;
      //Delegate.Combine(msgDelegate, new SimpleMath.MathMessage(Method2));

      foreach (Delegate item in msgDelegate.GetInvocationList()) {
        Console.WriteLine(item.Method);
        ((SimpleMath.MathMessage)item).Invoke("f", 21);
        //item.Invoke("f", 21);
       
      }
      

    }

    private static void Method2(string mes, int result) {
      Console.WriteLine("Method one called: {0} {1}", mes, result);

    }

    private static void Method1(string mes, int result) {
      Console.WriteLine("Method two called: {0} {1}", mes, result);
    }
  }
}
