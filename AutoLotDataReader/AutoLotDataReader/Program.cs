using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoLotDataReader {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun With Data Readers *****\n");
         try {
            // Create and open a connection 
            using (SqlConnection cn = new SqlConnection()) {
               //cn.ConnectionString = @"Data Source = (local)\SQLEXPRESS; Integrated Security=SSPI;" +
               //   "Initial Catalog=AUtoLot; Connect Timeout=30"; // we cann add Connect Timeout=30, if need to change the timeout 
               //                                                  // using the connection string builder class 

               SqlConnectionStringBuilder cnStrBuilder = new SqlConnectionStringBuilder();
               cnStrBuilder.InitialCatalog = "AutoLot";
               cnStrBuilder.DataSource = @"(local)\SQLEXPRESS";
               cnStrBuilder.ConnectTimeout = 15;
               cnStrBuilder.IntegratedSecurity = true;

               cn.ConnectionString = cnStrBuilder.ConnectionString;
               cn.Open();
               ShowConnectionStats(cn);

               /***********************************/
               // Create SqlCommand
               string strSQL = "select * from Inventory";
               string strSQL1 = "select count(CarID) from Inventory";
               SqlCommand myCommand = new SqlCommand(strSQL, cn);

               // another command via properties 
               SqlCommand testCommand = new SqlCommand();
               testCommand.Connection = cn;
               testCommand.CommandText = strSQL1;
               //var count = testCommand.ExecuteScalar();
               //Console.WriteLine("Execute Scalar: {0}",count);

               /***********************************
                * */
               // Obtain a data reader 
               using (SqlDataReader myDataReader = myCommand.ExecuteReader()) {
                  // loop over the result 
                  while (myDataReader.Read()) {
                     Console.WriteLine("-> Make:{0}\t, PetName: {1}\t, Color: {2}\t.",
                        myDataReader[0].ToString(),
                        myDataReader[1].ToString(),
                        myDataReader[2].ToString());
                  }
               }

               using (SqlDataReader myDataReader = myCommand.ExecuteReader()) {

                  while (myDataReader.Read()) {
                     Console.WriteLine("***** Record *****");
                     for (int i = 0; i < myDataReader.FieldCount; i++) {
                        Console.WriteLine("{0} = {1}\t",
                           myDataReader.GetName(i),
                           myDataReader.GetValue(i).ToString());
                     }
                     Console.WriteLine();
                  }
               }

               // Obtaining multiple result sets using datareader 
               string strSQL2 = "select * from Inventory; select * from Custumer";
               SqlCommand cmd2 = new SqlCommand(strSQL2, cn);

               using (SqlDataReader dr = cmd2.ExecuteReader()) {
                  do {

                     while (dr.Read()) {
                        Console.WriteLine("***** Record *****");
                        for (int i = 0; i < dr.FieldCount; i++) {
                           Console.WriteLine("{0} = {1}\t",
                              dr.GetName(i),
                              dr.GetValue(i).ToString());
                        }
                        Console.WriteLine();
                     }

                  } while (dr.NextResult());

               }

            }// end using SqlConnection
         }
         catch (Exception e) {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
         }
      }

      private static void ShowConnectionStats(SqlConnection cn) {
         Console.WriteLine("Stats of the actual dbConnection ");
         Console.WriteLine("Connection time out: {0}", cn.ConnectionTimeout);
         Console.WriteLine("Database: {0}", cn.Database);
         Console.WriteLine("DataBase Source: {0}", cn.DataSource);
         Console.WriteLine("State: {0}", cn.State);
      }
   }
}
