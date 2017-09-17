using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReaderWriterApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with StringReaderWriter *****\n");

         // Create a StringWriter and emit character data to memory 
         using (StringWriter strWriter = new StringWriter()) {
            strWriter.WriteLine("Don't forget Mother's Day this year...");
            // Get a copy of the contents (stored in a string) and dump to console 
            Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);

            // Get the internal StrinBbuilder object
            StringBuilder sb = strWriter.GetStringBuilder();
            sb.Insert(0, "Hey!! ");
            Console.WriteLine("->{0}", sb.ToString());
            sb.Remove(0, "Hey!! ".Length);
            Console.WriteLine("->{0}", sb.ToString());
            using (StringReader sreader = new StringReader(strWriter.ToString())) {
               Console.WriteLine("Contents of the string writer");
               string input = null;
               while ((input = sreader.ReadLine())!=null) {
                  Console.WriteLine(input);
               }
            }
         }
        
      }
   }
}
