using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Interfaces00 {
  abstract class MyAbstractClass {

    protected int _Member1;
    private int _ParentOnly;
    public int ParantOnly {
      get { return _ParentOnly; }
         set { _ParentOnly = value; } }

    public MyAbstractClass() {
    }

    public abstract void DisplayMessage();
    public void MessageFromParent() {
      Console.WriteLine("Message from the parent");
    }

    


  }
}