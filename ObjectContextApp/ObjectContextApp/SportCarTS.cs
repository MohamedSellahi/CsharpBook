using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting.Contexts;


namespace ObjectContextApp {
  // this context bound type will only loaded 
  // on a synchronized (tread safe) context
  [Synchronization]
  class SportCarTS : ContextBoundObject {
    public SportCarTS() {
      Context ctx = Thread.CurrentContext;
      Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
      foreach (IContextProperty itfCtxProp in ctx.ContextProperties) {
        Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
      }
    }
  }


  public class SportsCar {
    // Get context information and print out context ID. 
    public SportsCar() {
      Context ctx = Thread.CurrentContext;
      Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
      foreach (IContextProperty itfCtxProp in ctx.ContextProperties) {
        Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
      }
    }

  }
}
