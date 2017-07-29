using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoLotDisconnectedLayer;

namespace InventoryDALDisLayer {
   public partial class MainForm : Form {

      InventoryDALDisplay dal = null;
      public MainForm() {
         InitializeComponent();

         string cnStr = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=AutoLot;" +
            "Integrated Security=True;Pooling=False";

         // Create data access object
         dal = new InventoryDALDisplay(cnStr);

         // 
         InventoryGrid.DataSource = dal.GetAllInventory();
      }

      private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

      }

      private void button1_Click(object sender, EventArgs e) {
         // get modified data 
         DataTable changedDT = (DataTable)InventoryGrid.DataSource;
         try {
            dal.UpdateInventory(changedDT);
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
