using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataBinding {
   public partial class Form1 : Form {
      // A collections of cars 
      private List<Car> _cars = null;

      // DataTable information 
      DataTable inventoryTable = new DataTable();
      DataView yogosOnlyDV = null; 
   

      public Form1() {
         InitializeComponent();
         
         // Fill in the list 
         _cars = new List<Car>() {
            new Car { CarID = 100, PetName = "Chucky", Maker = "BMW", Color = "Green" },
            new Car { CarID = 101, PetName = "Tiny", Maker = "Yugo", Color = "White" },
            new Car { CarID = 102, PetName = "Ami", Maker = "Jeep", Color = "Tan" },
            new Car { CarID = 103, PetName = "Pain Inducer", Maker = "Caravan",Color = "Pink" },
            new Car { CarID = 104, PetName = "Fred", Maker = "BMW", Color = "Green" },
            new Car { CarID = 105, PetName = "Sidd", Maker = "BMW", Color = "Black" },
            new Car { CarID = 106, PetName = "Mel", Maker = "Firebird", Color = "Red" },
            new Car { CarID = 107, PetName = "Sarah", Maker = "Colt", Color = "Black" },
         };

         CreateTable();
         // Make a view 
         CreateDataView();
      }

      private void CreateDataView() {
         //Set the table that is used to construct this view
         yogosOnlyDV = new DataView(inventoryTable);

         // configure the view using the filter 
         yogosOnlyDV.RowFilter = "Maker = 'Yugo'";

         // bind to the data grid 
         YogoGridView.DataSource = yogosOnlyDV;
      }

      private void CreateTable() {
         // Create Table Schema
         DataColumn carIDColumn = new DataColumn("ID", typeof(int));
         DataColumn carMakerColumn = new DataColumn("Maker", typeof(string));
         DataColumn carColorColumn = new DataColumn("Color", typeof(string));
         DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
         carPetNameColumn.Caption = "Pet Name";

         inventoryTable.Columns.AddRange(new DataColumn[]
         { carIDColumn,carMakerColumn, carColorColumn, carPetNameColumn});

         // iterate over the list to make rows 
         foreach (Car c in _cars) {
            DataRow newRow = inventoryTable.NewRow();
            newRow["ID"] = c.CarID;
            newRow["Maker"] = c.Maker;
            newRow["Color"] = c.Color;
            newRow["PetName"] = c.PetName;
            inventoryTable.Rows.Add(newRow);
         }

         // bind the table to the data grid 
         this.GridView1.DataSource = inventoryTable;

      }

      private void btnDelete_Click(object sender, EventArgs e) {
         try {
            // Find the ro to delete 
            DataRow[] rowToDelete = inventoryTable.Select(
               string.Format("ID={0}", int.Parse(txtCartoDelete.Text)));

            // Delete it 
            rowToDelete[0].Delete();
            // dont forget to accept changes 
            inventoryTable.AcceptChanges(); 
         }
         catch (Exception ex) {
            MessageBox.Show(ex.Message);
         }
      }

      private void btnDisplay_Click(object sender, EventArgs e) {
         // Build a filter based on user in put 
         string filterStr = string.Format("Maker='{0}'", txtMakerAdd.Text);

         // find all rows matching the filter
         DataRow[] makers = inventoryTable.Select(filterStr,"PetName DESC");

         if (makers.Length == 0) {
            MessageBox.Show("no cars for this maker...", "Selection error!");
         }
         else {
            string strMaker = string.Empty;
            for (int i = 0; i < makers.Length; i++) {
               // from the current row get PetName 
               strMaker += makers[i]["PetName"] + "\n";
            }

            // show names of all cars 
            MessageBox.Show(strMaker, string.Format("we have {0}s named: ", txtMakerAdd.Text));
         }
         ShowCarsWithIdGreaterThanFive();

      }

      private void ShowCarsWithIdGreaterThanFive() {
         DataRow[] properIDs;
         string filter = "ID > 5 ";
         properIDs = inventoryTable.Select(filter);
         string strIDs = string.Empty;
         for (int i = 0; i < properIDs.Length; i++) {
            DataRow tmp = properIDs[i];
            strIDs += tmp["PetName"] + "is ID" + tmp["ID"] + "\n";
         }
         MessageBox.Show(strIDs, "Pet names of cars wher id > 5");
      }

      private void btnChangeBMW_Click(object sender, EventArgs e) {
         // Confirm selection 
         if (DialogResult.Yes == MessageBox.Show("Are you sure? BMW are nicer than Yogos","Please confirm",
            MessageBoxButtons.YesNo)) {
            // build a filter 
            string filter = "Maker = 'BMW'";
            string strMakers = string.Empty;

            // find all rows matching the filter 
            DataRow[] makers = inventoryTable.Select(filter);
            // change all beemer to yogo 
            for (int i = 0; i < makers.Length; i++) {
               makers[i]["Maker"] = "Yugo";
            }
         }
      }
   }
}
