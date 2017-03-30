using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nullable {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("****** Fun with Nullable Dayta ******");
      DatabaseReader dr = new DatabaseReader();

      int? i = dr.GetIntFromDatabase();
      if(i.HasValue) {
        Console.WriteLine("Value of 'i' is: {0}", i.Value);
      }
      else {
        Console.WriteLine("Value of 'i' is undefined");
      }

      // Get bool from "database"
      bool? b = dr.GetBoolFromDatabase();

      if(b.HasValue) {
        Console.WriteLine("Value of 'b' is: {0}", b.Value);
      }
      else {
        Console.WriteLine("Value of 'b' is undefined");
      }

      // if value from getIntFrom is undefined 
      // assign local variable to default value 100;
      int myData = dr.GetIntFromDatabase() ?? 100;
      Console.WriteLine("Value of myData:{0}", myData);
      Console.WriteLine();





    }// end of main 

    static void LocalNullableVariable() {
      // Define some local nullable variable 
      int? nullableInt = 10;
      double? nullableDouble = 3.14;
      bool? nullableBool = null;
      int?[] arrayofNullableints = new int?[10];

      // Error
      //string? s = "OOps";
    }

    static void LocalNullableVariablesUsingNullable() {

      Nullable<int> nullableInt = 10;
      Nullable<double> nullabDouble = 3.14;
      Nullable<bool> nullablebool = null;
      Nullable<char> nullableChar = 'a';
      Nullable<int>[] arrayOfNullableInts = new int?[10];

    }

    // example of acceding a database
    class DatabaseReader {
      // Nullable data field 
      public int? numericValue = null;
      public bool? boolValue = true;


      public int? GetIntFromDatabase() {
        return numericValue;
      }

      public bool? GetBoolFromDatabase() {
        return boolValue;
      }
    }


  }
}
