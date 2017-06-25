using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SimpleDataSet {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** Fun with DataSets *****");
         // Create a data set object and add few properties 
         DataSet carsInventoryDS = new DataSet("Car Inventory");

         carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
         carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
         carsInventoryDS.ExtendedProperties["Company"] = "Mikko’s Hot Tub Super Store";

         // building the columns of the datatable representing the Inventory 
         FillDataSet(carsInventoryDS);
         //ManipulateDataRowState();
         PrintDataSet(carsInventoryDS);

      }

      private static void PrintDataSet(DataSet ds) {
         // Print out the DataSet Name and any extended properties 
         Console.WriteLine("DataSet is named: {0}",ds.DataSetName);
         foreach (System.Collections.DictionaryEntry item in ds.ExtendedProperties) {
            Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
         }
         Console.WriteLine();

         //PrintOut each table 
         foreach (DataTable dt in ds.Tables) {
            Console.WriteLine("=> Table: {0},",dt.TableName);
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
               Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine("\n-------------------------------------");
            //Print Table 
            for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
               for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
                  Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
               }
               Console.WriteLine();
            }

         }
      }

      private static void FillDataSet(DataSet ds) {
         // Create data columns that map to the
         // "real" columns in the Inventory table
         // of the AutoLot database.
         DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
         carIDColumn.Caption = "Car ID"; // caption is used for display purpuses only 
         carIDColumn.ReadOnly = true;
         carIDColumn.AllowDBNull = false;
         carIDColumn.Unique = true; // this is the primary key
         carIDColumn.AutoIncrement = true;
         carIDColumn.AutoIncrementSeed = 0;
         carIDColumn.AutoIncrementStep = 1;

         DataColumn carMakeColumn = new DataColumn("Maker", typeof(string));
         DataColumn carColorColumn = new DataColumn("Color", typeof(string));
         DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
         carPetNameColumn.Caption = "Pet Name";

         // Now add data columns to DataTable
         DataTable inventoryTable = new DataTable("Inventory");
         inventoryTable.Columns.AddRange(new DataColumn[] 
         { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

         // Now add some rows to the inventory table;
         DataRow carRow = inventoryTable.NewRow();
         carRow["Maker"] = "BMW";
         carRow["Color"] = "Red";
         carRow["PetName"] = "Hamlet";
         inventoryTable.Rows.Add(carRow);

         carRow = inventoryTable.NewRow();
         // Column 0 is the autoincremented ID field,
         // so start at 1.
         carRow[1] = "Saab";
         carRow[2] = "Red";
         carRow[3] = "Sea Breeze";
         inventoryTable.Rows.Add(carRow);

         // mak the primary key of this table 
         inventoryTable.PrimaryKey = new DataColumn[] { inventoryTable.Columns[0] };

         // add table to data set 
         ds.Tables.Add(inventoryTable);

      }

      private static void ManipulateDataRowState() {
         // Create temp table for testing 
         DataTable temp = new DataTable("Temp");
         temp.Columns.Add(new DataColumn("TempColumn", typeof(int)));
         // RowState = Detached (not part of a DataTable)
         DataRow row = temp.NewRow();
         Console.WriteLine("After calling NewRow(): {0}", row.RowState);

         //RowState = Added
         temp.Rows.Add(row);
         Console.WriteLine("After calling Rows.Add(): {0}", row.RowState);
         
         // RowState=Added.
         row["TempColumn"] = 10;
         Console.WriteLine("After first assignment: {0}", row.RowState);

         // RowState= unchanged 
         temp.AcceptChanges();
         Console.WriteLine("After calling AcceptChanges: {0}", row.RowState);

         // RowState = Modified 
         row["TempColumn"] = 11;
         Console.WriteLine("After first assignment: {0}", row.RowState);

         // RowState = deleted 
         temp.Rows[0].Delete();
         Console.WriteLine("After calling Delete: {0}", row.RowState);

      }

   }
}
