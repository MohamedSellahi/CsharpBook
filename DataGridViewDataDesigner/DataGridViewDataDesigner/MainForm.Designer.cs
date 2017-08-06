namespace DataGridViewDataDesigner {
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
         this.components = new System.ComponentModel.Container();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.carIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.makerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.petNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.inventoryDataSet = new DataGridViewDataDesigner.InventoryDataSet();
         this.inventoryTableAdapter = new DataGridViewDataDesigner.InventoryDataSetTableAdapters.InventoryTableAdapter();
         this.btnUpdateInventory = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).BeginInit();
         this.SuspendLayout();
         // 
         // dataGridView1
         // 
         this.dataGridView1.AutoGenerateColumns = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carIDDataGridViewTextBoxColumn,
            this.makerDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.petNameDataGridViewTextBoxColumn});
         this.dataGridView1.DataSource = this.inventoryBindingSource;
         this.dataGridView1.Location = new System.Drawing.Point(55, 52);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.Size = new System.Drawing.Size(445, 220);
         this.dataGridView1.TabIndex = 0;
         // 
         // carIDDataGridViewTextBoxColumn
         // 
         this.carIDDataGridViewTextBoxColumn.DataPropertyName = "CarID";
         this.carIDDataGridViewTextBoxColumn.HeaderText = "CarID";
         this.carIDDataGridViewTextBoxColumn.Name = "carIDDataGridViewTextBoxColumn";
         // 
         // makerDataGridViewTextBoxColumn
         // 
         this.makerDataGridViewTextBoxColumn.DataPropertyName = "Maker";
         this.makerDataGridViewTextBoxColumn.HeaderText = "Maker";
         this.makerDataGridViewTextBoxColumn.Name = "makerDataGridViewTextBoxColumn";
         // 
         // colorDataGridViewTextBoxColumn
         // 
         this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
         this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
         this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
         // 
         // petNameDataGridViewTextBoxColumn
         // 
         this.petNameDataGridViewTextBoxColumn.DataPropertyName = "PetName";
         this.petNameDataGridViewTextBoxColumn.HeaderText = "PetName";
         this.petNameDataGridViewTextBoxColumn.Name = "petNameDataGridViewTextBoxColumn";
         // 
         // inventoryBindingSource
         // 
         this.inventoryBindingSource.DataMember = "Inventory";
         this.inventoryBindingSource.DataSource = this.inventoryDataSet;
         // 
         // inventoryDataSet
         // 
         this.inventoryDataSet.DataSetName = "InventoryDataSet";
         this.inventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
         // 
         // inventoryTableAdapter
         // 
         this.inventoryTableAdapter.ClearBeforeFill = true;
         // 
         // btnUpdateInventory
         // 
         this.btnUpdateInventory.Location = new System.Drawing.Point(281, 304);
         this.btnUpdateInventory.Name = "btnUpdateInventory";
         this.btnUpdateInventory.Size = new System.Drawing.Size(152, 23);
         this.btnUpdateInventory.TabIndex = 1;
         this.btnUpdateInventory.Text = "Update Inventory";
         this.btnUpdateInventory.UseVisualStyleBackColor = true;
         this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(610, 351);
         this.Controls.Add(this.btnUpdateInventory);
         this.Controls.Add(this.dataGridView1);
         this.Name = "MainForm";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.MainForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridView1;
      private InventoryDataSet inventoryDataSet;
      private System.Windows.Forms.BindingSource inventoryBindingSource;
      private InventoryDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
      private System.Windows.Forms.DataGridViewTextBoxColumn carIDDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn makerDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn petNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.Button btnUpdateInventory;
   }
}

