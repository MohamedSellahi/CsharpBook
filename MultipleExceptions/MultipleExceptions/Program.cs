using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleExceptions {
  class Program {
    static void Main(string[] args) {

      try {

        throw new FormatException("This is the original exception");
      }
      catch (FormatException eformat) {
        Console.WriteLine("Trying to log the error to a txt file");
        try {
          // this may throw an exception
          FileStream fs = File.Open(@"c:\logFile.txt", FileMode.Open);
        }
        catch (FileNotFoundException efile) {
          // rethrow the original exception with the actual exception as 
          // as inner exception
          throw new FormatException(eformat.Message, efile);
        }

      }


    }
  }
}
