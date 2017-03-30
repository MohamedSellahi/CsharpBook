using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExceptionType {
  class Program {
    static void Main(string[] args) {

      #region Custom Exception: take one

      // System Level Exceptions 
      NullReferenceException nullRefEx = new NullReferenceException();
      Console.WriteLine("NullReference exception is a SystemException?: {0}", nullRefEx is SystemException);
      Car myCar = new Car("Rusty", 90);
      // application level exception
      try {
        myCar.Accelerate(50);
      }
      catch (CarIsDeadException e) {
        Console.WriteLine("-------------------------");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.ErrorTimeStamp);
        Console.WriteLine(e.CauseError);
      }

      #endregion

      #region Exception: take two


      #endregion




    }



  }
}
