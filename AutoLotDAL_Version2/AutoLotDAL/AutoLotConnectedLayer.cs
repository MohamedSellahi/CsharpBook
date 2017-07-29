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
      public string State { get { return sqlCn.State.ToString(); } }

      public void OpenConnection(string connectionString) {
         sqlCn = new SqlConnection();
         sqlCn.ConnectionString = connectionString;
         sqlCn.Open();
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

      public void InsertAutoParam(int id, string color, string maker, string petName) {
         //Note placeholder in SQL query 
         string sql = string.Format("Insert Into Inventory" +
            "(CarID, Maker, Color, PetName) Values " +
            "(@CarID, @Maker, @Color, @PetName)");

         // this command will have internal parameters 
         using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn)) {
            // Fill Params Collection 
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CarID";
            param.Value = id;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Maker";
            param.Value = maker;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 10;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Color";
            param.Value = color;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 10;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@PetName";
            param.Value = petName;
            param.SqlDbType = SqlDbType.Char;
            param.Size = 10;
            cmd.Parameters.Add(param);
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

      #region Call Stored Procedures 

      public string LookUpPetName(int carID) {
         string carPetName = string.Empty;
         //Establish Name of stored procedure
         using (SqlCommand cmd = new SqlCommand("GetPetName", this.sqlCn)) {
            cmd.CommandType = CommandType.StoredProcedure;

            // Input Params 
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@carID";
            param.SqlDbType = SqlDbType.Int;
            param.Value = carID;

            // the default direction is input, but let be exlicit 
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            // output params
            param = new SqlParameter();
            param.ParameterName = "@petName";
            param.SqlDbType = SqlDbType.Char;
            param.Size = 10;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            // Execute stored proc
            cmd.ExecuteNonQuery();

            // return output param
            carPetName = (string)cmd.Parameters["@petName"].Value;
         }

         return carPetName;
      }
      #endregion

      #region Transaction logic

      public void ProcessCreditRisk(bool throwEx, int custID) {
         // First Look up current name based on customer ID 
         string fName = string.Empty;
         string lName = string.Empty;

         SqlCommand cmdSelect = new SqlCommand(
            string.Format("Select * from [Custumer] where CustID = {0}", custID),
            this.sqlCn);
         using (SqlDataReader dr = cmdSelect.ExecuteReader()) {
            if (dr.HasRows) {
               dr.Read();
               fName = (string)dr["FirstName"];
               lName = (string)dr["LastName"];
            }
            else {
               return;
            }
         }

         // Create command objects that represents each step of the operation 
         SqlCommand cmdRemove = new SqlCommand(
            string.Format("Delete from Custumer where CustID = {0}", custID), this.sqlCn);
         SqlCommand cmdInsert = new SqlCommand(
            string.Format("Insert Into CreditRisks" +
                          "(CustID, FirstName, LastName) Values" +
                          "({0}, '{1}', '{2}')", custID, fName, lName), this.sqlCn);

         // you will get from the connection object 
         SqlTransaction tx = null;
         try {
            tx = this.sqlCn.BeginTransaction();

            // Enlist the commands into the transaction 
            cmdInsert.Transaction = tx;
            cmdRemove.Transaction = tx;

            // Execute the commands 
            cmdInsert.ExecuteNonQuery();
            cmdRemove.ExecuteNonQuery();

            // simulate error ; 
            if (throwEx) {
               throw new Exception("Sorry! Data base error! Tx failed...");
            }

            tx.Commit();
         }
         catch (Exception ex) {
            Console.WriteLine(ex.Message);
            tx.Rollback();
         }


      }

      #endregion

      #region Close Connection and resources cleaup 

      public void CloseConnection() {
         sqlCn.Close();
      }

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
               GC.SuppressFinalize(this);
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
