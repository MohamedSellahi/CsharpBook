using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with directory(Info) *****\n");
         ShowWindowDirectoryInfo();
         DisplayImageFiles(@"C:\Users\Public\Pictures\Sample Pictures");
         ModifyAppDirectory();
         FunWithDirectoryType();

      }

      private static void FunWithDirectoryType() {
         // List All drives 
         string[] drives = Directory.GetLogicalDrives();
         Console.WriteLine("Here are you drives:");
         foreach (string d in drives) {
            Console.WriteLine("--> {0}",d);
         }
      }

      private static void ModifyAppDirectory() {
         DirectoryInfo dir = new DirectoryInfo(".");
         // Create \Myfolder 
         dir.CreateSubdirectory("MyFolder");

         // Create a subdirecvtory 
         DirectoryInfo dataFolder =  dir.CreateSubdirectory(@"MyFolder\Data");
         Console.WriteLine("New Folder is {0}", dataFolder);

      }

      private static void DisplayImageFiles(string path) {
         DirectoryInfo dir = new DirectoryInfo(path);
         // Get all files with jpg extension
         FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.TopDirectoryOnly);

         // how many we have found 
         Console.WriteLine("Found {0} *.jpg files \n", imageFiles.Length);
         // Now print out info for each file 
         foreach (FileInfo fi in imageFiles) {
            Console.WriteLine("**************************");
            Console.WriteLine("FileName: {0}", fi.Name);
            Console.WriteLine("FileSize: {0}",fi.Length);
            Console.WriteLine("Creation: {0}", fi.CreationTime);
            Console.WriteLine("Attributes: {0}",fi.Attributes);
            Console.WriteLine("**************************");
         }


      }

      private static void ShowWindowDirectoryInfo() {
         // Dump Directory information
         DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
         Console.WriteLine("***** Directory Info *****");
         Console.WriteLine("FullName: {0}", dir.FullName);
         Console.WriteLine("Name: {0}", dir.Name);
         Console.WriteLine("Parent: {0}", dir.Parent);
         Console.WriteLine("Creation: {0}", dir.CreationTime);
         Console.WriteLine("Attributes: {0}", dir.Attributes);
         Console.WriteLine("Root: {0}", dir.Root);
         Console.WriteLine("******************************\n");
      }


   }
}
