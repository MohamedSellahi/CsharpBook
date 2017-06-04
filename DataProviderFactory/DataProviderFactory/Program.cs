using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.Common;

namespace DataProviderFactory {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun With Data Providers *****");
      // Get connection string/provider from *.config
      string dp = ConfigurationManager.AppSettings["provider"];
      string cnStr = ConfigurationManager.AppSettings["cnStr"];
      //string dp = ConfigurationManager.AppSettings["oledbProvider"];
      //string cnStr = ConfigurationManager.AppSettings["cnStrOledb"];

      // get factory provider 
      DbProviderFactory df = DbProviderFactories.GetFactory(dp);

      // now get the connection object 
      using (DbConnection cn = df.CreateConnection()) {
        Console.WriteLine("Your connection object is a: {0}", cn.GetType().Name);
        Console.WriteLine("With time out {0}", cn.ConnectionTimeout);
        cn.ConnectionString = cnStr;
        cn.Open();

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
