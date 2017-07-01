namespace WindowsFormsDataBinding {
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
         this.lbl1 = new System.Windows.Forms.Label();
         this.GridView1 = new System.Windows.Forms.DataGridView();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.txtCartoDelete = new System.Windows.Forms.TextBox();
         this.btnDelete = new System.Windows.Forms.Button();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.txtMakerAdd = new System.Windows.Forms.TextBox();
         this.btnDisplay = new System.Windows.Forms.Button();
         this.YogoGridView = new System.Windows.Forms.DataGridView();
         this.label1 = new System.Windows.Forms.Label();
         this.btnChangeBMW = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.GridView1)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.YogoGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // lbl1
         // 
         this.lbl1.AutoSize = true;
         this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lbl1.Location = new System.Drawing.Point(26, 13);
         this.lbl1.Name = "lbl1";
         this.lbl1.Size = new System.Drawing.Size(294, 24);
         this.lbl1.TabIndex = 0;
         this.lbl1.Text = "Here is what you have in stock";
         // 
         // GridView1
         // 
         this.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.GridView1.Location = new System.Drawing.Point(30, 54);
         this.GridView1.Name = "GridView1";
         this.GridView1.Size = new System.Drawing.Size(514, 193);
         this.GridView1.TabIndex = 1;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.txtCartoDelete);
         this.groupBox1.Controls.Add(this.btnDelete);
         this.groupBox1.Location = new System.Drawing.Point(30, 267);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(259, 56);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "ID of car to delete";
         // 
         // txtCartoDelete
         // 
         this.txtCartoDelete.Location = new System.Drawing.Point(6, 30);
         this.txtCartoDelete.Name = "txtCartoDelete";
         this.txtCartoDelete.Size = new System.Drawing.Size(86, 20);
         this.txtCartoDelete.TabIndex = 5;
         // 
         // btnDelete
         // 
         this.btnDelete.Location = new System.Drawing.Point(156, 27);
         this.btnDelete.Name = "btnDelete";
         this.btnDelete.Size = new System.Drawing.Size(75, 23);
         this.btnDelete.TabIndex = 4;
         this.btnDelete.Text = "Delete";
         this.btnDelete.UseVisualStyleBackColor = true;
         this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.txtMakerAdd);
         this.groupBox2.Controls.Add(this.btnDisplay);
         this.groupBox2.Location = new System.Drawing.Point(295, 267);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(249, 56);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Enter Maker to view";
         // 
         // txtMakerAdd
         // 
         this.txtMakerAdd.Location = new System.Drawing.Point(6, 29);
         this.txtMakerAdd.Name = "txtMakerAdd";
         this.txtMakerAdd.Size = new System.Drawing.Size(124, 20);
         this.txtMakerAdd.TabIndex = 1;
         // 
         // btnDisplay
         // 
         this.btnDisplay.Location = new System.Drawing.Point(153, 26);
         this.btnDisplay.Name = "btnDisplay";
         this.btnDisplay.Size = new System.Drawing.Size(75, 23);
         this.btnDisplay.TabIndex = 0;
         this.btnDisplay.Text = "View";
         this.btnDisplay.UseVisualStyleBackColor = true;
         this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
         // 
         // YogoGridView
         // 
         this.YogoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.YogoGridView.Location = new System.Drawing.Point(30, 395);
         this.YogoGridView.Name = "YogoGridView";
         this.YogoGridView.Size = new System.Drawing.Size(514, 192);
         this.YogoGridView.TabIndex = 4;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(26, 358);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(118, 24);
         this.label1.TabIndex = 5;
         this.label1.Text = "Only Yogos";
         // 
         // btnChangeBMW
         // 
         this.btnChangeBMW.Location = new System.Drawing.Point(348, 13);
         this.btnChangeBMW.Name = "btnChangeBMW";
         this.btnChangeBMW.Size = new System.Drawing.Size(175, 23);
         this.btnChangeBMW.TabIndex = 6;
         this.btnChangeBMW.Text = "ChangeBMWS to Yogo";
         this.btnChangeBMW.UseVisualStyleBackColor = true;
         this.btnChangeBMW.Click += new System.EventHandler(this.btnChangeBMW_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(591, 599);
         this.Controls.Add(this.btnChangeBMW);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.YogoGridView);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.GridView1);
         this.Controls.Add(this.lbl1);
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.GridView1)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.YogoGridView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label lbl1;
      private System.Windows.Forms.DataGridView GridView1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox txtCartoDelete;
      private System.Windows.Forms.Button btnDelete;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Button btnDisplay;
      private System.Windows.Forms.TextBox txtMakerAdd;
      private System.Windows.Forms.DataGridView YogoGridView;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnChangeBMW;
   }
}

