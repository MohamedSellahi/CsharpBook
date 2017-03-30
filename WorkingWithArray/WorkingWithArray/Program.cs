using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithArray {
  class Program {
    static void Main(string[] args) {

      DeclareImplicitArrays();
      ArrayOfObjects();
      Console.WriteLine('\n');

      // Multidimentional arrays
      RectMultidimentionalArray();

      // jagged arrays (arrays of arrays)
      JaggedMultidiementionalArray();

      // somme important members of array base class
      int[,,] Matrix3D = new int[1, 2, 4];
      Console.WriteLine("------------------------------");
      Console.WriteLine("Rank = {0}", Matrix3D.Rank);
      Console.WriteLine("Length = {0}", Matrix3D.Length);




    }// end of main 
    static void DeclareImplicitArrays() {
      Console.WriteLine("=> Implicit array Initialization. ");

      // a is int[] 
      var a = new[] { 1, 10, 100, 1000 };
      Console.WriteLine("a is a: {0}", a.ToString());

      // b is double[]
      var b = new[] { 1, 1.5, 2, 2.5 };
      Console.WriteLine("b is a :{0}", b.ToString());

      // c is really string[]
      var c = new[] { "hello", null, "World!" };
      Console.WriteLine("c is a : {0}", c.ToString());
     

    }

    static void ArrayOfObjects() {
      Console.WriteLine("=> Array of objects.");
      // array of objects can be anything 
      object[] myObjects = new object[4];
      myObjects[0] = 10;
      myObjects[1] = false;
      myObjects[2] = new DateTime(1969, 3, 24);
      myObjects[3] = "form & Void";

      foreach(var item in myObjects) {
        Console.WriteLine("Type: {0}, value: {1}", item.GetType(), item);
      }

    }

    static void RectMultidimentionalArray() {
      Console.WriteLine("=> Rectangular Multidimentional array. ");
      int[,] myMatrix;
      myMatrix = new int[6, 6];

      for(int i = 0; i < 6; i++) {
        for(int j = 0; j < 6; j++) {
          myMatrix[i, j] = i * j;
        }
      }

      // print 6*6 array
      for(int i = 0; i < 6; i++) {
        for(int j = 0; j < 6; j++) {
          Console.Write(myMatrix[i,j] + "\t");
        }
        Console.WriteLine();
      }     
    }

    static void JaggedMultidiementionalArray() {
      Console.WriteLine("\n\n=> Jagged multidimentional array.\n");

      int[][] myJaggedArray = new int[5][];

      Console.WriteLine("Rank: {0}", myJaggedArray.Rank);
      Console.WriteLine("Length: {0}", myJaggedArray.Length);
      // create jagged array
      for(int i = 0; i < myJaggedArray.Length; i++) {
        myJaggedArray[i] = new int[i + 7];
      }

      for(int i = 0; i < myJaggedArray.GetLength(0); i++) {
        for(int j = 0; j < myJaggedArray[i].Length; j++) {
          Console.Write(myJaggedArray[i][j] + " ");
        }
        Console.WriteLine();
      }
    }

    static void PrintArray(int[] myInts) {
      for(int i = 0; i < myInts.Length; i++) {
        Console.Write("Item {0} is {1}", i, myInts[i]);
      }
      Console.WriteLine();
    }


  }// end of class
}
