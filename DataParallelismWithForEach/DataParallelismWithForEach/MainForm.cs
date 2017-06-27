using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace DataParallelismWithForEach {
   public partial class MainForm : Form {
      private CancellationTokenSource cancelTocken = new CancellationTokenSource();

      public MainForm() {
         InitializeComponent();
      }

      private void textBox1_TextChanged(object sender, EventArgs e) {

      }

      private void btnProcessImages_Click(object sender, EventArgs e) {
         // Start a new task to process files 
         Task.Factory.StartNew(() => {
            ProcessFiles();
         });
      }

      private void ProcessFiles() {
         // Use ParalleOptions instance to store cancelTocken
         ParallelOptions parOpts = new ParallelOptions();
         parOpts.CancellationToken = cancelTocken.Token;
         parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

         // laod all *.jpg files and make a new directory 
         string[] files = Directory.GetFiles(
            @"C:\Users\Mohamed\Pictures\TestPictures",
            "*.jpg", SearchOption.AllDirectories);
         string newDir = @"C:\ModifiedPictures";
         Directory.CreateDirectory(newDir);

         try {
            //process the files 
            Parallel.ForEach(files, parOpts, currFile => {
               parOpts.CancellationToken.ThrowIfCancellationRequested();

               string filename = Path.GetFileName(currFile);
               using (Bitmap bitmap = new Bitmap(currFile)) {
                  bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                  bitmap.Save(Path.Combine(newDir, filename));
                  this.Invoke((Action)delegate {
                     this.Text = string.Format("Processing {0} on thread {1}", filename,
                        Thread.CurrentThread.ManagedThreadId);
                  });
               }
               
            });
         }
         catch (OperationCanceledException ex) {
            this.Invoke((Action)delegate {
               this.Text = ex.Message;
            });
         }


      }

      //private void ProcessFiles() {
      //   // Load up all *.jpg files, and make a new folder for the modified data 
      //   string[] files = Directory.GetFiles(
      //      @"C:\Users\Mohamed\Pictures\TestPictures", "*.jpg", SearchOption.AllDirectories
      //      );
      //   string newDir = @"C:\ModifiedPictures";
      //   Directory.CreateDirectory(newDir);
      //   /**
      //    * 
      //   // Blocking images in a blocking manner

      //   foreach (string currFile in files) {
      //      string filename = Path.GetFileName(currFile);
      //      using (Bitmap bitmap = new Bitmap(currFile)) {
      //         bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
      //         bitmap.Save(Path.Combine(newDir, filename));

      //         // Print out ID of the thread processing the current image 
      //         this.Text = string.Format("Processing {0} on thread {1}",
      //            filename, Thread.CurrentThread.ManagedThreadId);
      //      }
      //    * 
      //    * 
      //    * 
      //    * */
      //   // Processing the images in a paralelle manner 

      //   Parallel.ForEach(files, currFile => {
      //      string filename = Path.GetFileName(currFile);

      //      using (Bitmap bitmap = new Bitmap(currFile)) {
      //         bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
      //         bitmap.Save(Path.Combine(newDir, filename));

      //         // Invoke the Form object, to allow secondary threads to access 
      //         // controlls in a thread-safe manner. 
      //         this.Invoke((Action)delegate {
      //            this.Text = string.Format("Processing {0} on thread {1}",
      //               filename, Thread.CurrentThread.ManagedThreadId);
      //         }
      //         );
      //      }
      //   }
      //   );
      //}

      private void btnCancelTask_Click(object sender, EventArgs e) {
         cancelTocken.Cancel();
      }

   }
}
