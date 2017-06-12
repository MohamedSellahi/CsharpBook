using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with FileStreams *****");
         using (FileStream fStream = File.Open(@"C:\Users\Mohamed\Source\Repos\CsharpBook\IO_Tests\myMessage.dat",
            FileMode.Create)) {
            string msg = "Hello!";
            byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
            // Write bytes to the file 
            fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

            // reset internal position of the stream 
            fStream.Position = 0;

            // Read the types from the file and display to the console 
            Console.WriteLine("Your message as an array of bytes: ");
            byte[] bytesFromFile = new byte[msgAsByteArray.Length];
            for (int i = 0; i < msgAsByteArray.Length; i++) {
               bytesFromFile[i] = (byte)fStream.ReadByte();
               Console.WriteLine(bytesFromFile[i]);
            }

            // Display decoded bytes 
            Console.Write("\nDecoded message: ");
            Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
         }

      }


   }
}
