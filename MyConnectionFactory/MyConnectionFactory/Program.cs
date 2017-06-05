using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration; 


namespace MyConnectionFactory {
  class Program {
    // A list of possible providers 
    public enum DataProvider {
      SqlServer, OleDb, Odbc, None
    }

    static void Main(string[] args) {
      Console.WriteLine("***** Very Simple Connection Factory *****\n");
      // Get a specific connection 
      IDbConnection mycn = GetConnection(DataProvider.Odbc);
      Console.WriteLine("Your connection is {0}", mycn.GetType().Name);

      // Read the provider key from App settings 
      string dataProviderString = ConfigurationManager.AppSettings["provider"];
      // transfomr string to enum 
      DataProvider dp = DataProvider.None;
      try {

        if (Enum.IsDefined(typeof(DataProvider), dataProviderString)) {
          dp = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
        }
        else {
          Console.WriteLine("Sorry no provider exists! ");
        }
      }
      catch (Exception e) {
        Console.WriteLine("Error parsing Config File");
        Console.WriteLine(e.Message);
        return; 
      }
     
      // Get specifc connection 
      IDbConnection cn = GetConnection(dp);
      if (cn != null) {
        Console.WriteLine("Your connection from AppSettings is a {0}", cn.GetType().Name);
      }

    }

    private static IDbConnection GetConnection(DataProvider dp) {
      IDbConnection conn = null;
      switch (dp) {
        case DataProvider.SqlServer:
          conn = new SqlConnection();
          break;
        case DataProvider.OleDb:
          conn = new OleDbConnection();
          break;
        case DataProvider.Odbc:
          conn = new OdbcConnection();
          break;
      }


      return conn;
    }



  }
}
