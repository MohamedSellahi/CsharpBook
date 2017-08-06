using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL;
using AutoLotDAL.AutoLotDataSetTableAdapters;
using System.Data;

namespace LinqToDataSetApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** LINQ over DataSet *****");

         // Get a strongly typed DataTable containing the current Inventory 
         AutoLotDataSet dal = new AutoLotDataSet();
         InventoryTableAdapter da = new InventoryTableAdapter();
         // this method creates an instance of Inventory table, 
         // fill adapter with it and returns a reference to it 
         AutoLotDataSet.InventoryDataTable data = da.GetData();

         // Invoke the methods that follow here !

         PrintAllCarIds(data);
         ShowRedCars(data);

      }

      private static void PrintAllCarIds(DataTable data) {
         // Get enumerable version of DataTable 
         EnumerableRowCollection enumData = data.AsEnumerable();

         // Print the car IDs 
         foreach (DataRow r in enumData) {
            Console.WriteLine("Car ID = {0}", r["CarID"]);
         }
      }

      private static void ShowRedCars(DataTable data) {
         // Project a new result set containing
         // the ID/color for rowsz where Color = red.
         //var cars = from c in data.AsEnumerable()
         //           where ((string)c["Color"]).Trim() == "Black"
         //           select
         //           new {
         //              ID = (int)c["CarID"],
         //              Maker = (string)c["Maker"]
         //           };

         var cars = from c in data.AsEnumerable()
                    where c.Field<string>("Color").Trim() == "Red"
                    select new {
                       ID = c.Field<int>("CarID"),
                       Maker = c.Field<string>("Maker")
                    };

         Console.WriteLine("Here are the red cars");
         foreach (var c in cars) {
            Console.WriteLine("-> CarID = {0} is {1}", c.ID, c.Maker);
         }
      }



   }
}
