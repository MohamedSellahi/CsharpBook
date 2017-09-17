using System;
using System.IO;

namespace BinaryWriterReaderApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with BinaryReder/ BinaryWriter");

         // Open a binary writer for a file 
         FileInfo f = new FileInfo("BinFile.dat");
         using (BinaryWriter bw = new BinaryWriter(f.OpenWrite())) {
            // Print out the base stream . System.IO.FileStream
            Console.WriteLine("BaseStream is: {0}", bw.BaseStream);

            // Create some data to save in the file 
            double aDouble = 1234.67;
            int anInt = 34567;
            string aString = "A, B, C";

            // write the data 
            bw.Write(aDouble);
            bw.Write(anInt);
            bw.Write(aString);
         }
         Console.WriteLine("Done!");
         Console.WriteLine("Try to read");
         using (BinaryReader br = new BinaryReader(f.OpenRead())) {
            Console.WriteLine(br.ReadDouble());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
         }
      }
   }
}
