using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionType {
  class CarIsDeadException2: ApplicationException {
    public DateTime ErrorTimeStamp { get; set; }
    public string CauseofError { get; set; }

    // Feed message to parent constructor 
    public CarIsDeadException2(string message, string cause, DateTime time): base(message) {
      CauseofError = cause;
      ErrorTimeStamp = time;
    }

    
  }
}
