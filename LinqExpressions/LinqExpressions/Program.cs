using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExpressions {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with Query Expressions *****");
      // This array will be the basis of our testing... 
      ProductInfo[] itemsInStock = new[] {
        new ProductInfo{ Name = "Mac's Coffee", Description = "Coffee with TEETH", NumberInStock = 24},
        new ProductInfo{ Name = "Milk Maid Milk", Description = "Milk cow's love", NumberInStock = 100},
        new ProductInfo{ Name = "Pure Silk Tofu", Description = "Bland as Possible", NumberInStock = 120},
        new ProductInfo{ Name = "Cruchy Pops", Description = "Cheezy, peppery goodness", NumberInStock = 2},
        new ProductInfo{ Name = "RipOff Water", Description = "From the tap to your wallet", NumberInStock = 100},
        new ProductInfo{ Name = "Classic Valpo Pizza", Description = "Everyone loves pizza!", NumberInStock = 73}
      };
      

      SelectEverything(itemsInStock);
      Console.WriteLine('\n');
      ListProductnaes(itemsInStock);

      Console.WriteLine('\n');
      GetOverStock(itemsInStock);

      Console.WriteLine('\n');
      GetGamesAndDescription(itemsInStock);

      Console.WriteLine('\n');
      Console.WriteLine("Using projected data ");
      /* using the Array type: can hold any object */
      Array objs = GetProjectedData(itemsInStock);
      foreach (object item in objs) {
        Console.WriteLine(item);
      }

      Console.WriteLine('\n');
      GetcountFromQuery();

      Console.WriteLine('\n');
      ReverseEveryThing(itemsInStock);

      Console.WriteLine('\n');
      AlphabetizedProductNames(itemsInStock);







    }

    /* Basic Selection Syntax */
    static void SelectEverything(ProductInfo[] products) {
      Console.WriteLine("All product details:");
      var AllProduct = from p in products
                       select p;
      foreach (var item in AllProduct) {
        Console.WriteLine(item);
      }
    }

    /* List product names */
    static void ListProductnaes(ProductInfo[] products) {
      Console.WriteLine("Only product names: ");
      var names = from p in products
                  select p.Name;
      foreach (var item in names) {
        Console.WriteLine("Name: {0}", item);
      }

    }

    /* Obtaining Subset of Data */
    static void GetOverStock(ProductInfo[] products) {
      Console.WriteLine("The overstock items!");
      // get only item where we have more than 25 in stock 
      var overStock = from p in products
                      where p.NumberInStock > 25
                      select p;
      foreach (var item in overStock) {
        Console.WriteLine(item);
      }
      
    }

    /* Projecting New Data Types */
    static void GetGamesAndDescription(ProductInfo[] products){
      Console.WriteLine("Names and Description");
      var nameDesc = from p in products
                     select new { p.Name, p.Description }; // store in anonymous type
      foreach (var item in nameDesc) {
        Console.WriteLine(item.ToString());
      }


    }

    /* returning projected subsets */
    static Array GetProjectedData(ProductInfo[] products) {
      
      var nameDesc = from p in products
                     select new {
                       p.Name, p.Description
                     };
      // Map the anponymous type to an Array of objects 
      return nameDesc.ToArray();
    }

    /* Obtaining count using Enumerable */
    static void GetcountFromQuery() {
      string[] games = {"Morrowind", "Uncharted 2","Fallout 3", "Daxter", "System Shock 2"};

      // Get count from query 
      int numb = (from g in games
                  where g.Length > 6
                  select g).Count();

      // print out the number 
      Console.WriteLine("{0} items honor the LinQ Query", numb);
    }

    /* Reversing result sets */
    static void ReverseEveryThing(ProductInfo[] product) {
      Console.WriteLine("Product in reverse.");
      var allProducts = (from p in product select p).Reverse();
      foreach (var item in allProducts) {
        Console.WriteLine(item);
      }
    }

    /*sorting expressions */
    static void AlphabetizedProductNames(ProductInfo[] product) {
      // Get Names of products in alphabetic order 
      var subset = from p in product orderby p.Name select p;
      Console.WriteLine("Ordered by Name ");
      foreach (var item in subset) {
        Console.WriteLine(item);
      }

    }


  }
}
