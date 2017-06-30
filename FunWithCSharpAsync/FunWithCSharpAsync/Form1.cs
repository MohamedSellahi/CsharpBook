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

namespace FunWithCSharpAsync {
   public partial class Form1 : Form {
      public Form1() {
         InitializeComponent();
      }

      //private  void btnCallMethod_Click(object sender, EventArgs e) {
      //   this.Text =  DoWork();
      //}

      //private string DoWork() {
      //   Thread.Sleep(10000);
      //   return "Done with Work";
      //}


      private async void btnCallMethod_Click(object sender, EventArgs e) {
         this.Text = await DoWorkAsync();
         //this.Text = getMessage();
      }


      // async and await keyword are added as decoration conventions 

      private async Task<string> DoWorkAsync() {
         return await Task.Run((Func<string>)getMessage);
      }
      

      private string getMessage() {
         Thread.Sleep(1000);
         return "Done With Work";
      }

      // async method returning void 
      private async Task methodreturningVoidAsync() {
         await Task.Run(() => { Thread.Sleep(4000); });
      }

      private async void btnVoidMethodCall_Click(object sender, EventArgs e) {
         await methodreturningVoidAsync();
         MessageBox.Show("Done");
      }

      // async method with multiple awaits 

      private async void btnMultiAwaits_Click(object sender, EventArgs e) {
         await Task.Run(() => {Thread.Sleep(4000); });
         MessageBox.Show("Done task 1");

         await Task.Run(() => { Thread.Sleep(2000); });
         MessageBox.Show("Done Task 2");

         await Task.Run(() => { Thread.Sleep(2000); });
         MessageBox.Show("Done Task 3");

      }


   }
}
