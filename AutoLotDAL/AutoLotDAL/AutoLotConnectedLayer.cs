using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace AutoLotConnectedLayer {

   public class InventoryDAL : IDisposable {
      // this member will be used by all methods 
      // the actual implementation lacks all the exception handeling 
      // logic. this is for test only 
      private bool disposed = false;
      #region Connection logic
      private SqlConnection sqlCn = null;

      public void OpenConnection(string connectionString) {
         sqlCn = new SqlConnection();
         sqlCn.ConnectionString = connectionString;
         sqlCn.Open();
      }

      public void CloseConnection() {
         sqlCn.Close();
      }

      #endregion

      #region Insertion Logic
      public void InsertAuto(int id, string color, string maker, string petName) {
         string sqlCmd = string.Format("Insert Into Inventory" +
            "([CarID],[Maker],[Color],[PetName]) Values" +
            "({0}, '{1}', '{2}', '{3}')", id, maker, color, petName);

         // Execute using our connection 
         using (SqlCommand cmd = new SqlCommand(sqlCmd, this.sqlCn)) {
            cmd.ExecuteNonQuery();
         }
      }

      public void InsertAuto(Car newCar) {
         // Format and execute sql command
         string sqlCmd = string.Format("Insert Into Inventory" +
            "([CarID],[Maker],[Color],[PetName]) Values" +
            "({0}, '{1}', '{2}', '{3}')", newCar.CarID, newCar.Maker, newCar.Color, newCar.PetName);
         using (SqlCommand cmd = new SqlCommand(sqlCmd, sqlCn)) {
            cmd.ExecuteNonQuery();
         }
      }
      #endregion

      #region Deletion logic 
      public void DeleteCar(int id) {
         string sql = string.Format("Delete from Inventory where CarID = {0}", id);
         using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
            try {
               cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) {
               throw new Exception("Sorry! that car is on order!", ex);
            }
         }
      }
      #endregion

      #region UpdateLogic 
      public void UpdateCarPetName(int id, string newPetName) {
         // get ID of the new car and new petname 
         string sql = string.Format("Update Inventory " +
                                    "Set PetName = '{0}' " +
                                    "Where CarID = {1}", newPetName, id);
         using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
            cmd.ExecuteNonQuery();
         }
      }
      #endregion

      #region Selection Logic 
      public List<Car> GetAllInventoryAsList() {
         List<Car> inv = new List<Car>();
         // prep Comman d object 
         string sql = "select * from Inventory";
         using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
               inv.Add(new Car {
                  CarID = (int)dr["CarID"],
                  Color = (string)dr["Color"],
                  Maker = (string)dr["Maker"],
                  PetName = (string)dr["PetName"]
               });
            }
            dr.Close();
         }
         
         return inv;
      }


      public DataTable GetAllInventoryAsDataTable() {
         DataTable inv = new DataTable();
         // prep Comman d object 
         string sql = "select * from Inventory";
         using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
            SqlDataReader dr = cmd.ExecuteReader();
            // Fill the table with data from the reader 
            inv.Load(dr);
            dr.Close(); 
         }
         return inv; 
      }
      #endregion




      #region Close Connection and resources cleaup 
      public void Dispose() {
         // Call our helper method.
         // Specifying "true" signifies that
         // the object user triggered the cleanup.
         CleanUp(true);

         // Now suppress finalization 
         GC.SuppressFinalize(this);
      }

      private void CleanUp(bool disposing) {
         // be sure we havenot already been disposed 
         if (!this.disposed) {
            // if disposing equals true, dipose all 
            // managed resources 
            if (disposing) {
               // Dispose managed resources here 
            }
            // Clean up unmanaged resources 
            sqlCn.Close();
         }
         disposed = true;
      }

      ~InventoryDAL() {
         // Call our helper method.
         // Specifying "false" signifies that
         // the GC triggered the cleanup.
         CleanUp(false);
      }


      #endregion



   }
}
