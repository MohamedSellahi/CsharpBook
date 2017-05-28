using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQchapter0 {
  class Program {
    static void Main(string[] args) {
      DeclareImplictVars();
      /* object initialization syntax */
      List<Rectangle> myListofRects = new List<Rectangle> {
        new Rectangle{TopLeft = new Point{X = 10, Y = 20},
                      BottomRight = new Point{ X = 20, Y = 20} },
        new Rectangle{BottomRight= new Point{X = 5, Y = 9 },
                      TopLeft = new Point{X = 30, Y = 75 } }
      };

      /* lambda expressions
       * (ArgumentsToProcess) => {statmentsToProcessThem}
       */
      LambdaExpressionSyntax();
      int x = 10;
      x.DisplayDefiningAssembly();
      



    }


    /* implicit variables */
    static void DeclareImplictVars() {
      var myInt = 0;
      var myBool = true;
      var myString = "Hello World";

      /* print out the underlying types */
      Console.WriteLine("myint is a: {0}",myInt.GetType().Name );
      Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
      Console.WriteLine("myString is a: {0}", myString.GetType().Name);

    }

    /* lambda expression exemple */
    static void LambdaExpressionSyntax() {
      List<int> lst = new List<int>();
      lst.AddRange(new int[] { 20, 1, 2, 8, 9, 44 });

      // C# lambda expression 
      List<int> evenNumber = lst.FindAll(i => (i % 2 == 0));

      Console.WriteLine("Here are your even numbers: ");
      foreach (int item in evenNumber) {
        Console.Write("{0} ", item);
        
      }
      Console.WriteLine();

    }


    /* extension methods */
   

  }


  static class ObjectExtension {

    /* define an extension method to System.Object */
    public static void DisplayDefiningAssembly(this object obj) {
      Console.WriteLine("{0} lives in : \n\t ->{1}\n", obj.GetType().Name,
                         Assembly.GetAssembly(obj.GetType()));
    }
  }


}
