using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("***** Fun with interfaces *****");
      Hexagone hex = new Hexagone("MyHexagon");
      Console.WriteLine("Points: {0}", hex.Points);

      // determining if a class supports an interface
      // Method 1 : via casting 

      Circle cer = new Circle("Lisa");

      IPointy itPtcer = null;
      IPointy itPtHex = null;

      

      try { // 
        // 
        itPtHex = (IPointy)hex;
        Console.WriteLine(itPtHex.Points);

        Console.WriteLine(hex is IPointy);
        Console.WriteLine(cer is IPointy);

        itPtcer = (IPointy)cer;
        Console.WriteLine(itPtcer.Points);
         
      }
      catch (InvalidCastException e) {
        Console.WriteLine(e.Message);
      }

      // method 2 : via as keyword ==> Obtaining the interface reference 

      // Can we treat a shape as IPointy 
      Hexagone hex2 = new Hexagone("bob");

      IPointy itPhex2 = hex2 as IPointy;

      if (itPhex2 != null) { // hex2 can be treated as IPointy 
        Console.WriteLine(itPhex2.Points);
      }
      else {
        Console.WriteLine("OOPS! not pointy ...");
      }

      // method 2 : via is keyword ==> Obtaining the interface reference 

      Shape[] myShapes = { new Hexagone(), new Circle(), new Triangle("Joe-the-Triangle "), new Circle("jojo") };

      foreach (var item in myShapes) {
        // Calling draw method 
        item.Draw();

        if (item is IPointy) {
          Console.WriteLine("-> Points: {0}", ((IPointy)item).Points);
        }
        else {
          Console.WriteLine("{0} is not a pointy", item.PetName);
        }
      }

      // Interfaces as parameters 
      Console.WriteLine("\n****** Fun with interfaces parameters *****");
      foreach (var item in myShapes) {
        if (item is IDraw3D)
          DrawIn3D((IDraw3D)item);
      }

      // interface as return type :
      // we can return an object whos class implements an interface

      // get first Pointy object 
      IPointy firstPointyItem = FindFirstPointyShape(myShapes);
      if (firstPointyItem != null) {
        Console.WriteLine("The item has {0} points", firstPointyItem.Points);
      }

      // arrays of interfaces: useful to group objects that implement an interface 
      // even if they don't belong to the same class hierarechy 
      // (except for the System.Object class )

      IPointy[] myPontyObjects = { new Hexagone(), new Knife(), new Triangle(),
                                   new Fork(), new PitchFork()};

      foreach (var item in myPontyObjects) {
        Console.WriteLine("Object has {0} points.", item.Points);
      }


      // Explicit Interface Implementation


      



 

    }



    public static void DrawIn3D(IDraw3D itf3d) {
      Console.WriteLine("-> Drawing IDraw3D compatible type");
      itf3d.Draw3D();
    }

    public static IPointy FindFirstPointyShape(Shape[] shapes) {
      foreach (var item in shapes) {
        if (item is IPointy)
          return item as IPointy;
      }
      return null; 
    }

  


  }
}
