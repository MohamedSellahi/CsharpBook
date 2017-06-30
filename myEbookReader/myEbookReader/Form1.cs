using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myEbookReader {
   public partial class Form1 : Form {
      static public string theEbook = string.Empty;
      public Form1() {
         InitializeComponent();
      }

      private void Form1_Load(object sender, EventArgs e) {

      }

      private void btnDownload_Click(object sender, EventArgs e) {
         WebClient wc = new WebClient();
         wc.DownloadStringCompleted += (s, eArgs) => {
            theEbook = eArgs.Result;
            TxtBook.Text = theEbook;
         };

         // the project Gutenberg Ebook
         wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/55000/55000-0.txt"));
      }

      private void BtnGetStat_Click(object sender, EventArgs e) {
         // get the words from the ebook ; 
         string[] words = theEbook.Split(new char[] 
         { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
         StringSplitOptions.RemoveEmptyEntries);

         // Now find the ten most commen word 
         string[] tenMostWord = null;
         string longuestWord = string.Empty;


         Parallel.Invoke(() => {
            // Now find the ten most wommen words 
            tenMostWord = FindMostCommonWord(words);
         },
         () => {

            longuestWord = FindLongestWord(words);
         }
         );

           

         // Now that all tasks are complete, build a string show all
         // stats message
         StringBuilder bookStats = new StringBuilder("The ten most " +
            "common words are: ");
         foreach (string s in tenMostWord) {
            bookStats.AppendLine(s);
         }

         bookStats.AppendFormat("Longuest word is: {0}", longuestWord);
         bookStats.AppendLine();
         MessageBox.Show(bookStats.ToString(), "Book Info");
      }




      private string FindLongestWord(string[] words) {
         return (from w in words orderby w.Length descending select w).FirstOrDefault();
      }

      private string[] FindMostCommonWord(string[] words) {
         var frequencyOrder = from word in words
                              where word.Length > 6
                              group word by word into g
                              orderby g.Count() descending
                              select g.Key;
         return (frequencyOrder.Take(10)).ToArray();
      }
   }
}
