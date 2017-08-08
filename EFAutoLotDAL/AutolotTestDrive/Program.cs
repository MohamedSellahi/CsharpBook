using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFAutoLotDAL.EF;
using EFAutoLotDAL.Repos;
using EFAutoLotDAL.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
         Console.WriteLine("----------------------------");
         ShowAllOrders();
         ShowAllOrdersEagerlFetched();

         Console.WriteLine("============ Cust and Risks ==========");
         PrintAllCustiomersAndRisks();
         var customerRepo = new CustomerRepo();
         var customer = customerRepo.GetOne(4);
         customerRepo.Context.Entry(customer).State = EntityState.Detached;
         var risk = MakeCustomerARisk(customer);
         PrintAllCustiomersAndRisks();

         Console.ReadLine();


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

      // Using navigation properties 
      private static void ShowAllOrders() {
         using (var repo = new OrderRepo()) {
            Console.WriteLine("Pending Orders");
            foreach (var item in repo.GetAll()) {
               Console.WriteLine($"{item.Customer.FullName} is " +
                  $"wainting on {item.Car.PetName}");
            }

         }
      }

      // Using Eager loading 
      private static void ShowAllOrdersEagerlFetched() {
         using (var context = new AutoLotEntities()) {
            Console.WriteLine("Eagerly Loaded Pending Orders");
            var orders = context.Orders
               .Include(x => x.Car)
               .Include(x => x.Customer)
               .ToList();
            foreach (var item in orders) {
               Console.WriteLine($"{item.Customer.FullName} is wainting on {item.Car.PetName}");
            }

         }
      }

      //Multitable actions/ Implicit transactions
      private static CreditRisk MakeCustomerARisk(Customer customer) {

         // the customer passed here should have been detached 
         // from the original context 
         using (var context = new AutoLotEntities()) {
            context.Customers.Attach(customer);
            context.Customers.Remove(customer);
            var creditRisk = new CreditRisk() {
               FirstName = customer.FirstName,
               LastName = customer.LastName
            };

            context.CreditRisks.Add(creditRisk);
            try {
               context.SaveChanges();
            }
            catch (DbUpdateException ex) {
               Console.WriteLine(ex);
            }
            catch(Exception ex) {
               Console.WriteLine(ex);
            }
            return creditRisk;
         }
      }

      private static void PrintAllCustiomersAndRisks() {
         Console.WriteLine("**** Customers ");
         using (var repo = new CustomerRepo()) {
            foreach (var cust in repo.GetAll()) {
               Console.WriteLine($"->{cust.FirstName} {cust.LastName} is a Customer.");
            }
         }

         Console.WriteLine("***** Credit risks ******");
         using (var repo = new CreditRiskRepo()) {
            foreach (var risk in repo.GetAll()) {
               Console.WriteLine($"{risk.FirstName} {risk.LastName} is a credit risk!");
            }
         }
      }

   }
}
