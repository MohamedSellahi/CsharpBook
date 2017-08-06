using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutoLotConsoleApp {
   class Program {
      static void Main(string[] args) {
         Console.WriteLine("***** fun with ADO.NET EF *****\n");
         //int carId = AddNewRecord();
         //Console.WriteLine("Car added with id : {0}", carId);
         PrintAllInventory();
         Console.WriteLine("\nUsing SQL Query");
         PrintAllInventoryUsingSQLQuery();
         Console.WriteLine("\nUsing LINQ");
         PrinAllinventoryUsingLINQ();
         Console.WriteLine("\n More on LINQ queries");
         FunWithLinqQueries();
         RemoveRecord(8890);
         Console.WriteLine("\nUpdatin car");
         UpdateRecord(8888);
      }


      private static int AddNewRecord() {
         // Add a record to the inventory table of 
         // auto lot database 
         using (var context = new AutoLotEntities()) {

            try {
               // AHrd code for new car for testing
               var car = new Car() {
                  Maker = "Ford",
                  Color = "Brown",
                  CarNickName = "Brownnie",
                  // we don't provide CarId, since its identity, EF will populate it for us
               };
               context.Cars.Add(car);
               context.SaveChanges();
               // On successful save, EF populates the database denerated identity field.
               return car.CarID;

            }
            catch (Exception ex) {
               Console.WriteLine(ex.InnerException.Message);
               return 0;
            }
         }
      }

      private static void PrintAllInventory() {
         // Select all items from the Inventory table of AutoLot,
         // and print out the data using our custom ToString()
         // of the Car entity class.

         using (var context = new AutoLotEntities()) {
            foreach (Car c in context.Cars) {
               Console.WriteLine(c);
            }

         }
      }

      private static void PrintAllInventoryUsingSQLQuery() {
         using (var context = new AutoLotEntities()) {
            string query = @"Select CarId,Maker,Color,PetName as CarNickName " +
               "from Inventory " +
               "where Maker = 'BMW'";

            //foreach (Car c in context.Cars.SqlQuery(query)) {
            //   Console.WriteLine(c);
            //}

            foreach (Car c in context.Cars.SqlQuery("Select CarId, Maker, Color,PetName as CarNickName" +
               " from Inventory" +
               " where Maker=@p0 or Maker =@p1", "BMW", "Ford")) {
               Console.WriteLine(c);
            }

         }
      }

      private static void PrinAllinventoryUsingLINQ() {

         using (var context = new AutoLotEntities()) {
            foreach (Car c in context.Cars.Where(e => e.Maker == "BMW")) {
               Console.WriteLine(c);
            }

         }

      }

      private static void FunWithLinqQueries() {
         using (var context = new AutoLotEntities()) {

            // Get all data 
            var AllData = (from item in context.Cars select item).ToArray();                          

            // Get a projection of new data 
            var colrosMakers = from item in AllData
                               select new { item.Color, item.Maker }
                               ;
            foreach (var item in colrosMakers) {
               Console.WriteLine(item);
            }

            // GEt only item where color is black 
            var blackCars = from item in AllData
                            where item.Color == "Black"
                            select item;
            foreach (var item in blackCars) {
               Console.WriteLine(item);
            }

         }
      }

      private static void RemoveRecord(int carId) {
         // find the car to delete by the primary key 
         using (var context = new AutoLotEntities()) {
            // see if it exists 
            Car cartoDelete = context.Cars.Find(carId);
            if (cartoDelete != null) {
               context.Cars.Remove(cartoDelete);
               context.SaveChanges();
            }
         }

      }

      private static void RemoveRecordUsingEntityState(int carId) {
         using (var context = new AutoLotEntities()) {
            Car carToDelete = new Car() { CarID = carId };
            // mark this car as deleted 
            context.Entry(carToDelete).State = System.Data.Entity.EntityState.Deleted;
            try {
               context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) {
               // if the entry doesn't exist in the data base 
               // we can see what enttites cased the exception 
               // by examinig:  
               //ex.Entries
               
               Console.WriteLine(ex);
            }
         }
      }

      private static void UpdateRecord(int carId) {
         // find the car to update by primary key 
         using (var context= new AutoLotEntities()) {
            Car carToUpdate = context.Cars.Find(carId);
            if (carToUpdate != null) {
               Console.WriteLine(context.Entry(carToUpdate).State);
               carToUpdate.Color = "Blue";
               Console.WriteLine(context.Entry(carToUpdate).State);
               context.SaveChanges();
            }
         }
      }

   }
}
