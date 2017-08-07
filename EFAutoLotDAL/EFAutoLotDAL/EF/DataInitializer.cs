using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EFAutoLotDAL.Models;

namespace EFAutoLotDAL.EF {
   public class DataInitializer : DropCreateDatabaseAlways<AutoLotEntities> {

      protected override void Seed(AutoLotEntities context) {
         // Create some data to insert into database 
         var customers = new List<Customer>() {
            new Customer {FirstName = "Dave", LastName = "Brenner"},
            new Customer {FirstName = "Matt", LastName = "Walton"},
            new Customer {FirstName = "Steve", LastName = "Hagen"},
            new Customer {FirstName = "Pat", LastName = "Walton"},
            new Customer {FirstName = "Bad", LastName = "Customer"},
         };

         // Add customer list to customer table 
         customers.ForEach(x => context.Customers.Add(x));

         var cars = new List<Inventory>
            {
            new Inventory {Maker = "VW", Color = "Black", PetName = "Zippy"},
            new Inventory {Maker = "Ford", Color = "Rust", PetName = "Rusty"},
            new Inventory {Maker = "Saab", Color = "Black", PetName = "Mel"},
            new Inventory {Maker = "Yugo", Color = "Yellow", PetName = "Clunker"},
            new Inventory {Maker = "BMW", Color = "Black", PetName = "Bimmer"},
            new Inventory {Maker = "BMW", Color = "Green", PetName = "Hank"},
            new Inventory {Maker = "BMW", Color = "Pink", PetName = "Pinky"},
            new Inventory {Maker = "Pinto", Color = "Black", PetName = "Pete"},
            new Inventory {Maker = "Yugo", Color = "Brown", PetName = "Brownie"},
            };
         cars.ForEach(x => context.Inventory.Add(x));

         // Orders 
         // be carfull to respoce the constraints of the db
         var orders = new List<Order>() {
            new Order {Car = cars[0], Customer = customers[0]},
            new Order {Car = cars[1], Customer = customers[1]},
            new Order {Car = cars[2], Customer = customers[2]},
            new Order {Car = cars[3], Customer = customers[3]},
         };

         orders.ForEach(x => context.Orders.Add(x));
         context.CreditRisks.Add(
            new CreditRisk {
               CustId = customers[4].CustId,
               FirstName = customers[4].FirstName,
               LastName = customers[4].LastName,
            });

         context.SaveChanges();
      }
   }
}
