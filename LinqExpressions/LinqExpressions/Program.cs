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





  }
}
