using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDisconnectedLayer {
   public class InventoryDALDisplay {

      // Field data 
      private string _cnString = string.Empty;
      private SqlDataAdapter _dAdapt = null;

      public InventoryDALDisplay(string connectionString) {
         _cnString = connectionString;

         // Configure Adapter 
         ConfigureAdapter(out _dAdapt);
      }

      private void ConfigureAdapter(out SqlDataAdapter dAdapt) {
         dAdapt = new SqlDataAdapter("Select * From Inventory", _cnString);

         // Obtain the remaining command objects dynamically at run time
         SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
      }


      public DataTable GetAllInventory() {
         DataTable inv = new DataTable("Inventory");
         _dAdapt.Fill(inv);
         return inv;
      }

      // the adapter will examine the state of each row 
      // and executes the adequate command
      public void UpdateInventory(DataTable modifiedTable) {
         _dAdapt.Update(modifiedTable);
      }



   }
}
