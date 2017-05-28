using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleDispose {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Dispose *****\n");
      // Create a disposable object and call dispose 
      // to free any internal resources 
      MyResourceWrapper rw = new MyResourceWrapper();
      rw.Dispose();
      Console.WriteLine("Myresources is a Disposable() object: {0}", rw is IDisposable);
      DisposeFileStream();

      /* the using syntax:
       * Dispose is called automatically  
       */
      Console.WriteLine("\n the \"using\" syntax");
      using (MyResourceWrapper rw0 = new MyResourceWrapper()) {
        // use rw0 here 
        // this block will be compiled to 
        // try/finally block . check using ildasm.exe
      }

      // declaring multiple IDisposable objects 
      using (MyResourceWrapper rw1 = new MyResourceWrapper(),
                               rw2 = new MyResourceWrapper()
                               ) {
        // use both rw1 and rw2
      }




    }

    /* dispose vs close for IO streams */
    static void DisposeFileStream() {
      FileStream fs = new FileStream("myfile.txt", FileMode.OpenOrCreate);
      fs.WriteByte(65);
      // these method calls do the same thing 
      fs.Close();
      fs.Dispose();
    }

  }
}
