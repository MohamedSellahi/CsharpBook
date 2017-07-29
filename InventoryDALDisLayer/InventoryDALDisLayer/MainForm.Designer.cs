namespace InventoryDALDisLayer {
   partial class MainForm {
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
         this.InventoryGrid = new System.Windows.Forms.DataGridView();
         this.button1 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.InventoryGrid)).BeginInit();
         this.SuspendLayout();
         // 
         // InventoryGrid
         // 
         this.InventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.InventoryGrid.Location = new System.Drawing.Point(12, 75);
         this.InventoryGrid.Name = "InventoryGrid";
         this.InventoryGrid.Size = new System.Drawing.Size(399, 283);
         this.InventoryGrid.TabIndex = 0;
         this.InventoryGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(325, 32);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "btnUpdate";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(423, 370);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.InventoryGrid);
         this.Name = "MainForm";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.InventoryGrid)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView InventoryGrid;
      private System.Windows.Forms.Button button1;
   }
}

