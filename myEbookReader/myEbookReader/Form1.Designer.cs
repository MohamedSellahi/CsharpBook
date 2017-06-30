namespace myEbookReader {
   partial class Form1 {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.btnDownload = new System.Windows.Forms.Button();
         this.BtnGetStat = new System.Windows.Forms.Button();
         this.TxtBook = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // btnDownload
         // 
         this.btnDownload.Location = new System.Drawing.Point(105, 301);
         this.btnDownload.Name = "btnDownload";
         this.btnDownload.Size = new System.Drawing.Size(75, 23);
         this.btnDownload.TabIndex = 0;
         this.btnDownload.Text = "Download";
         this.btnDownload.UseVisualStyleBackColor = true;
         this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
         // 
         // BtnGetStat
         // 
         this.BtnGetStat.Location = new System.Drawing.Point(245, 301);
         this.BtnGetStat.Name = "BtnGetStat";
         this.BtnGetStat.Size = new System.Drawing.Size(75, 23);
         this.BtnGetStat.TabIndex = 1;
         this.BtnGetStat.Text = "GetStats";
         this.BtnGetStat.UseVisualStyleBackColor = true;
         this.BtnGetStat.Click += new System.EventHandler(this.BtnGetStat_Click);
         // 
         // TxtBook
         // 
         this.TxtBook.Location = new System.Drawing.Point(29, 25);
         this.TxtBook.Multiline = true;
         this.TxtBook.Name = "TxtBook";
         this.TxtBook.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.TxtBook.Size = new System.Drawing.Size(572, 270);
         this.TxtBook.TabIndex = 2;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(633, 337);
         this.Controls.Add(this.TxtBook);
         this.Controls.Add(this.BtnGetStat);
         this.Controls.Add(this.btnDownload);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnDownload;
      private System.Windows.Forms.Button BtnGetStat;
      private System.Windows.Forms.TextBox TxtBook;
   }
}

