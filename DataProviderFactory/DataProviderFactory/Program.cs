using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataProviderFactory {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun With Data Providers *****");

         // Get connection string/provider from *.config
         string dp = ConfigurationManager.AppSettings["provider"];
         //string cnStr = ConfigurationManager.AppSettings["cnStr"];
         string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

         // get factory provider 
         DbProviderFactory df = DbProviderFactories.GetFactory(dp);
         
        
         // now get the connection object 
         using (DbConnection cn = df.CreateConnection()) {
            Console.WriteLine("Your connection object is a: {0}", cn.GetType().Name);
            Console.WriteLine("With time out {0}", cn.ConnectionTimeout);
            cn.ConnectionString = cnStr;
            cn.Open();
            if (cn is SqlConnection) {
               // Print out the version of the server 
               // we need a cast to access such functionnlity 
               Console.WriteLine("Version of your sql server is {0}",((SqlConnection)cn).ServerVersion);
            }
             
            // Make a command object
            DbCommand cmd = df.CreateCommand();
            Console.WriteLine("Your command object is a: {0}", cmd.GetType().Name);
            cmd.Connection = cn;
            cmd.CommandText = "Select * from Custumer";

            // Print out with data reader 
            using (DbDataReader dr = cmd.ExecuteReader()) {
               Console.WriteLine("\n***** Current Inventory *****");
               while (dr.Read()) {
                  //Console.WriteLine("-> Car #{0} is a {1}",dr["CarID"], dr["Maker"] );
                  Console.WriteLine("-> Customer #{0} is: {1} {2}", dr[0], dr[1], dr[2]);
               }
            }


         }
      }
   }
}
