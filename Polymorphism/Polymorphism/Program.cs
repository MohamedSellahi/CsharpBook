using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism {
  class Program {
    static void Main(string[] args) {

      MiniVan van = new MiniVan(50, "Smart");
      van.DisplayStats();

      // nested class usage 
      NestedOuter.PublicInnerClass inner = new NestedOuter.PublicInnerClass(5);
      NestedOuter.PublicInnerClass.innerEnum enm = NestedOuter.PublicInnerClass.innerEnum.Item1;
      Console.WriteLine(enm);


      // 
      Console.WriteLine("#####");
      Console.WriteLine("#");
      Console.WriteLine("###");
      Console.WriteLine("#");
      Console.WriteLine("#");
      //
      Console.WriteLine("----------------");
      ThreeDCercle cer = new ThreeDCercle();
      cer.Draw(); // calls 3d implementation 
      ((Cercle)cer).Draw(); // cast force calling draw of cercle class
      


    }// main 




  }
}
