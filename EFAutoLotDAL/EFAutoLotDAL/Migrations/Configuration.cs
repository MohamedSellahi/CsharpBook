namespace EFAutoLotDAL.Migrations {
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;
   using EFAutoLotDAL.Models;
   using System.Collections.Generic;

   internal sealed class Configuration : DbMigrationsConfiguration<EFAutoLotDAL.EF.AutoLotEntities> {
      public Configuration() {
         AutomaticMigrationsEnabled = false;
         ContextKey = "EFAutoLotDAL.EF.AutoLotEntities";
      }

      protected override void Seed(EFAutoLotDAL.EF.AutoLotEntities context) {
         var customers = new List<Customer>
{
            new Customer {FirstName = "Dave", LastName = "Brenner"},
            new Customer {FirstName = "Matt", LastName = "Walton"},
            new Customer {FirstName = "Steve", LastName = "Hagen"},
            new Customer {FirstName = "Pat", LastName = "Walton"},
            new Customer {FirstName = "Bad", LastName = "Customer"},
            };

         customers.ForEach(x =>
context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));
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
            new Inventory {Maker = "Moh", Color = "Sel", PetName = "Brownie"},
            };
         cars.ForEach(x =>
         context.Inventory.AddOrUpdate(i => new { i.Maker, i.Color, i.PetName }, x));
         var orders = new List<Order>
         {
            new Order {Car = cars[0], Customer = customers[0]},
            new Order {Car = cars[1], Customer = customers[1]},
            new Order {Car = cars[2], Customer = customers[2]},
            new Order {Car = cars[3], Customer = customers[3]},
            };
         orders.ForEach(x =>
         context.Orders.AddOrUpdate(o => new { o.CarId, o.CustId }, x));
         context.CreditRisks.AddOrUpdate(c => new { c.FirstName, c.LastName },
         new CreditRisk {
            CustId = customers[4].CustId,
            FirstName = customers[4].FirstName,
            LastName = customers[4].LastName,
         });
      }
   }
}
