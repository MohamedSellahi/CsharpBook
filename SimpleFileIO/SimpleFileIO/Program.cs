using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileIO {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Simple IO with file type *****");
         string[] myTasks = {
            "Fix Bathroom sink",
            "Call Dave",
            "AsyncCall Mome and Dad",
            "Play Xbox 360"
         };

         // Write all data to file 
         File.WriteAllLines(@"C:\Users\Mohamed\Source\Repos\CsharpBook\IO_Tests\myTasks.txt", myTasks);

         // read it back and prit it out 
         foreach (string tsk in File.ReadAllLines(@"C:\Users\Mohamed\Source\Repos\CsharpBook\IO_Tests\myTasks.txt")) {
            Console.WriteLine("TODO: {0}",tsk);
         }
      }
   }
}
