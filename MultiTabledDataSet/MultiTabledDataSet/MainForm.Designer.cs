namespace MultiTabledDataSet {
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
         this.dataGridInventory = new System.Windows.Forms.DataGridView();
         this.dataGridCustomers = new System.Windows.Forms.DataGridView();
         this.dataGridOrders = new System.Windows.Forms.DataGridView();
         this.btnUpdate = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnOrderDetails = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.txtCustID = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // dataGridInventory
         // 
         this.dataGridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridInventory.Location = new System.Drawing.Point(49, 29);
         this.dataGridInventory.Name = "dataGridInventory";
         this.dataGridInventory.Size = new System.Drawing.Size(457, 104);
         this.dataGridInventory.TabIndex = 0;
         // 
         // dataGridCustomers
         // 
         this.dataGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridCustomers.Location = new System.Drawing.Point(49, 153);
         this.dataGridCustomers.Name = "dataGridCustomers";
         this.dataGridCustomers.Size = new System.Drawing.Size(457, 97);
         this.dataGridCustomers.TabIndex = 1;
         // 
         // dataGridOrders
         // 
         this.dataGridOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridOrders.Location = new System.Drawing.Point(49, 278);
         this.dataGridOrders.Name = "dataGridOrders";
         this.dataGridOrders.Size = new System.Drawing.Size(457, 96);
         this.dataGridOrders.TabIndex = 2;
         // 
         // btnUpdate
         // 
         this.btnUpdate.Location = new System.Drawing.Point(431, 399);
         this.btnUpdate.Name = "btnUpdate";
         this.btnUpdate.Size = new System.Drawing.Size(75, 23);
         this.btnUpdate.TabIndex = 3;
         this.btnUpdate.Text = "UpdateDatabase";
         this.btnUpdate.UseVisualStyleBackColor = true;
         this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.txtCustID);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.btnOrderDetails);
         this.groupBox1.Location = new System.Drawing.Point(49, 399);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(235, 129);
         this.groupBox1.TabIndex = 4;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Look Up Customer Order";
         // 
         // btnOrderDetails
         // 
         this.btnOrderDetails.Location = new System.Drawing.Point(97, 86);
         this.btnOrderDetails.Name = "btnOrderDetails";
         this.btnOrderDetails.Size = new System.Drawing.Size(116, 23);
         this.btnOrderDetails.TabIndex = 0;
         this.btnOrderDetails.Text = "Order Details";
         this.btnOrderDetails.UseVisualStyleBackColor = true;
         this.btnOrderDetails.Click += new System.EventHandler(this.btnOrderDetails_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 43);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(65, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Customer ID";
         // 
         // txtCustID
         // 
         this.txtCustID.Location = new System.Drawing.Point(97, 40);
         this.txtCustID.Name = "txtCustID";
         this.txtCustID.Size = new System.Drawing.Size(100, 20);
         this.txtCustID.TabIndex = 2;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(546, 540);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnUpdate);
         this.Controls.Add(this.dataGridOrders);
         this.Controls.Add(this.dataGridCustomers);
         this.Controls.Add(this.dataGridInventory);
         this.Name = "MainForm";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridOrders)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridInventory;
      private System.Windows.Forms.DataGridView dataGridCustomers;
      private System.Windows.Forms.DataGridView dataGridOrders;
      private System.Windows.Forms.Button btnUpdate;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox txtCustID;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button btnOrderDetails;
   }
}

