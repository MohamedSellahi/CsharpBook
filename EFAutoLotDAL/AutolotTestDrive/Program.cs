using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAutoLotDAL.EF;
using EFAutoLotDAL.Repos;
using EFAutoLotDAL.Models;
using System.Data.Entity;

namespace AutolotTestDrive {
   class Program {
      static void Main(string[] args) {
         Database.SetInitializer(new DataInitializer());
         Console.WriteLine("***** Fun with ADO.NET EF Code First *****\n");
         var car1 = new Inventory() { Maker = "Moh", Color = "Black", PetName = "Brownie" };
         var car2 = new Inventory() { Maker = "SmartCar", Color = "Brown", PetName = "Shorty" };

         AddNewRecord(car1);
         AddNewRecord(car1);

         AddNewRecords(new List<Inventory>() { car1, car2 });

         PrintAllInventory();

      }

      private static void PrintAllInventory() {

         using (var repo = new InventoryRepo()) {
            foreach (Inventory item in repo.GetAll()) {
               Console.WriteLine(item);
            }
         }
      }

      private static void AddNewRecord(Inventory car) {
         // Add record to the Inventory table of the AutoLot
         // database.
         using (var repo = new InventoryRepo()) {
            repo.Add(car);
         }
      }

      private static void AddNewRecords(IList<Inventory> cars) {
         // Add records to the inventory table of 
         // the database 
         using (var repo = new InventoryRepo()) {
            repo.AddRange(cars);
         }
      }




   }
}
