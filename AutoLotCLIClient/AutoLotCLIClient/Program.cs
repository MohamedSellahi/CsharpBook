using System;
using AutoLotConnectedLayer;
using System.Configuration;
using System.Data;

namespace AutoLotCLIClient {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** The AutoLot Console UL *****\n");
         string cnstr =
            ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
         bool userDone = false;
         string userCmd = "";

         // Create an inventory object 
         using (InventoryDAL invDAL = new InventoryDAL()) {
            invDAL.OpenConnection(cnstr);
            Console.WriteLine(invDAL.State);
            // keep asking for input until user presses the Q key
            try {
               ShowInstructions();
               do {
                  Console.Write("\nPlease enter your command: ");
                  userCmd = Console.ReadLine();
                  Console.WriteLine();
                  switch (userCmd.ToUpper()) {
                     case "I":
                        InsertNewCar(invDAL);
                        break;
                     case "U":
                        UpdateCarPetName(invDAL);
                        break;
                     case "D":
                        DeleteCar(invDAL);
                        break;
                     case "L":
                        ListInventory(invDAL);
                        break;
                     case "S":
                        ShowInstructions();
                        break;
                     case "P":
                        LookUpPetName(invDAL);
                        break;
                     case "Q":
                        userDone = true;
                        break;
                     default:
                        Console.WriteLine("Bad input! try again");
                        break;
                  }

               } while (!userDone);

            }
            catch (Exception e) {
               Console.WriteLine(e.Message);
            }
            finally {
               invDAL.CloseConnection();
            }
         }
      }

      private static void LookUpPetName(InventoryDAL invDAL) {
         // Get ID of car to look up
         Console.Write("Enter ID of Car to look up: ");
         try {
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("PetName of {0} is {1}.",
               id , invDAL.LookUpPetName(id).TrimEnd());
         }
         catch (Exception e) {
            Console.WriteLine("Bad input");
         }

      }

      private static void ListInventory(InventoryDAL invDAL) {
         // Get the list of Inventory 
         DataTable dt = invDAL.GetAllInventoryAsDataTable();

         // Pass datatable to helper function to display 
         DisplayTable(dt);
      }

      private static void DisplayTable(DataTable dt) {
         // Print out collumn names 
         for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
            Console.Write(dt.Columns[curCol].ColumnName + "\t");
         }
         Console.WriteLine("\n-------------------------------");

         // Print the DataTable
         for (int curRow = 0; curRow < dt.Rows.Count; curRow++) {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++) {
               Console.Write(dt.Rows[curRow][curCol].ToString().Trim(' ') + "\t");
            }
            Console.WriteLine();
         }
      }

      private static void DeleteCar(InventoryDAL invDAL) {
         // Get ID of car to delete 
         Console.WriteLine("Enter ID of Car to delete: ");
         int id;
         try {
            id = int.Parse(Console.ReadLine());
            invDAL.DeleteCar(id);
         }
         catch (Exception ex) {
            Console.WriteLine(ex.Message);
         }
      }

      private static void UpdateCarPetName(InventoryDAL invDAL) {
         // First get the user Car 
         int carID;
         string newCarPetName;

         Console.Write("Enter Car ID: ");
         carID = int.Parse(Console.ReadLine());
         Console.Write("Enter NEw Pet Name: ");
         newCarPetName = Console.ReadLine();

         // Now pass to data access 
         invDAL.UpdateCarPetName(carID, newCarPetName);
      }

      private static void InsertNewCar(InventoryDAL invDAL) {
         // First Get the user data 
         int newCarID;
         string newColor, newCarMaker, newCarPetName;

         Console.Write("Enter Car ID: ");
         newCarID = int.Parse(Console.ReadLine());

         Console.Write("Enter Car Color: ");
         newColor = Console.ReadLine();

         Console.Write("Enter Car Maker: ");
         newCarMaker = Console.ReadLine();

         Console.Write("Enter Pet Name: ");
         newCarPetName = Console.ReadLine();

         // pass to data access library
         invDAL.InsertAutoParam(newCarID, newColor, newCarMaker, newCarPetName);
      }

      private static void ShowInstructions() {
         Console.WriteLine("I: Inserts a new car.");
         Console.WriteLine("U: Updates an existing car.");
         Console.WriteLine("D: Deletes an existing car.");
         Console.WriteLine("L: Lists current inventory.");
         Console.WriteLine("S: Shows these instructions.");
         Console.WriteLine("P: Looks up pet name.");
         Console.WriteLine("Q: Quits program.");
      }


   }
}
