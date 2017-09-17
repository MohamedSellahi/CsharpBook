using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDirectoryWatcher {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** The Amazing File Watcher App *****");
         //Establish the path of the directory t watch 
         FileSystemWatcher watcher = new FileSystemWatcher();
         try {
            watcher.Path = @"C:\TestFolder";
         }
         catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
            return;
         }
         catch (Exception e) {
            Console.WriteLine(e.Message);
         }
         //Set up the things to be watched for 
         watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

         // Only watch text files 
         watcher.Filter = "*.txt";

         // add event handlers
         watcher.Changed += (s, e) => {
            // Specify what is done 
            Console.WriteLine("File:{0} {1}!", e.FullPath, e.ChangeType);
         };
         watcher.Created += (s, e) => {
            Console.WriteLine("File:{0} {1}!", e.FullPath, e.ChangeType);
         };

         watcher.Deleted += (s, e) => {
            Console.WriteLine("File:{0} {1}!", e.FullPath, e.ChangeType);
         };

         watcher.Renamed += (s, e) => {
            Console.WriteLine("File: {0} renamed to {1}",e.OldFullPath, e.FullPath);
         };

         // begin watching the directory 
         watcher.EnableRaisingEvents = true;

         // wait for the user to quit 
         Console.WriteLine(@"Press 'q' to quit the app.");
         while (Console.Read()!='q') {
         }
      }
   }
}
