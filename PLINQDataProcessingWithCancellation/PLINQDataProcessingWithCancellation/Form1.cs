using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLINQDataProcessingWithCancellation {
   public partial class Form1 : Form {
      private CancellationTokenSource cancelToken = new CancellationTokenSource();
      
      public Form1() {
         InitializeComponent();
      }

      private void btnExecute_Click(object sender, EventArgs e) {
         // Start a new task
         cancelToken = new CancellationTokenSource();
         Task.Factory.StartNew(() => {
            ProcessIntData();
         });
      }

      private void ProcessIntData() {
         // Get a very large array of Ints 
        int[] source = Enumerable.Range(1, 10000000).ToArray();

         // Find the numbers where num%3 = 0, returned in descending order 
         try {
            int[] multipleOfThree = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                                     where num % 3 == 0
                                     orderby num descending
                                     select num).ToArray();
            MessageBox.Show(string.Format("Found {0} numbers that match query!", multipleOfThree.Count()));
         }
         catch (OperationCanceledException e) {
            MessageBox.Show("Operation has been cancelled");
         }
      }

      private void btnCancel_Click(object sender, EventArgs e) {
         cancelToken.Cancel();
      }
   }
}
