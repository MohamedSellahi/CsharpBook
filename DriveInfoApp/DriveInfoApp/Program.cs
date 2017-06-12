using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfoApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with DriveInfo *****");
         
         // Get info regarding all drives 
         DriveInfo[] myDrives = DriveInfo.GetDrives();
         // Now print drive stats 
         foreach (DriveInfo dinfo in myDrives) {
            Console.WriteLine("Name: {0}", dinfo.Name);
            Console.WriteLine("Type: {0}", dinfo.DriveType);

            // check whether each drive is mounted 
            if (dinfo.IsReady) {
               Console.WriteLine("FreeSpace: {0}",dinfo.TotalFreeSpace);
               Console.WriteLine("Type: {0}", dinfo.DriveFormat);
               Console.WriteLine("Label: {0}", dinfo.VolumeLabel);
            }
            Console.WriteLine();
         }
      }



   }
}
