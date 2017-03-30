using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionType {
  class CarIsDeadException: ApplicationException {

    private string _messageDetails = string.Empty;
    public DateTime ErrorTimeStamp { get; set; }
    public string CauseError { get; set; }

    public CarIsDeadException() {}
    public CarIsDeadException(string message, string cause, DateTime time) {
      _messageDetails = message;
      CauseError = cause;
      ErrorTimeStamp = time; 
    }


    // overiding the exception Message property
    public override string Message {
      get {
        return string.Format("Car Error Message: {0}", _messageDetails);
      }
    }





  }
}
