using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.AutoLotDataSetTableAdapters;
using AutoLotDAL;

namespace StronglyTypedDataSetConsoleClient {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("Fun with Strongly Typed Datasets *****");

         AutoLotDataSet.InventoryDataTable table =
            new AutoLotDataSet.InventoryDataTable();

         InventoryTableAdapter dAdapt = new InventoryTableAdapter();

         dAdapt.Fill(table);
         PrintInventory(table);
         AddRecords(table,dAdapt);
         Console.WriteLine("Somme rows have been added");
         PrintInventory(table);
         Console.WriteLine("After removing");
         RemoveRecord(table, dAdapt);
         PrintInventory(table);
         CallStoredProc();
         PrintInventory(table);
      }


      static void PrintInventory(AutoLotDataSet.InventoryDataTable dt) {
         // PRint out the column names 
         for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
            Console.Write(dt.Columns[curCol].ColumnName + "\t");
         }
         Console.WriteLine();

         // Print the data 
         for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
               Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
            }
            Console.WriteLine();
         }

      }

      public static void AddRecords(AutoLotDataSet.InventoryDataTable dt,
         InventoryTableAdapter dAdapt) {
         try {
            //Get strongly datarow
            AutoLotDataSet.InventoryRow newRow = dt.NewInventoryRow();
            // Fill
            newRow.CarID = 999;
            newRow.Color = "Purple";
            newRow.Maker = "BMW";
            newRow.PetName = "Saku";

            // Insert the new row 
            dt.AddInventoryRow(newRow);

            // add one more row, using the overloaded add method 
            dt.AddInventoryRow(8888, "Yugo", "Green", "Zippy");

            // update database
            dAdapt.Update(dt);

         }
         catch (Exception ex) {
            Console.WriteLine(ex.Message);
         }
      }

      public static void RemoveRecord(AutoLotDataSet.InventoryDataTable dt,
         InventoryTableAdapter dAdapt) {
         try {
            AutoLotDataSet.InventoryRow rowToDelete = dt.FindByCarID(999);
            dAdapt.Delete(rowToDelete.CarID, rowToDelete.Maker,
               rowToDelete.Color, rowToDelete.PetName);
            rowToDelete = dt.FindByCarID(888);
            dAdapt.Delete(rowToDelete.CarID, rowToDelete.Maker,
               rowToDelete.Color, rowToDelete.PetName);

         }
         catch (Exception ex) {
            Console.WriteLine(ex.Message);
         }
      }

      // Invocking stored procedures

      public static void CallStoredProc() {
         try {
            QueriesTableAdapter q = new QueriesTableAdapter();
            Console.WriteLine("Enter ID of the car to look up: ");
            string ID = Console.ReadLine();
            string carName = string.Empty;
            q.GetPetName(int.Parse(ID), ref carName);
            Console.WriteLine("CarID {0} has the name of {1}",ID, carName);
         }
         catch (Exception ex) {
            Console.WriteLine(ex.Message);
         }
      }
   }
}
