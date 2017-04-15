using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithPointers {
  class Program {
    static void Main(string[] args) {
      int x = 10;
      int[] myInts = new int[] { 1, 2, 3, 4 };

      unsafe
      {

        SquareIntPointer(&x);
        Console.WriteLine(x);

      }

      unsafe
      {
        PrintValueAndAddress();
      }

      // swap safely
      int a = 10, b = 20;
      Console.WriteLine("\n***** Safe swap *****");
      Console.WriteLine("Values before swap: a = {0}, b = {1}", a, b);
      SafeSwap(ref a, ref b);
      Console.WriteLine("Values after safeSwap: a = {0}, b = {1}", a, b);
      Console.WriteLine("\n***** unSafe swap *****");
      Console.WriteLine("Values before swap: a = {0}, b = {1}", a, b);
      unsafe { UnsafeSwap(&a, &b); }
      Console.WriteLine("Values After unsafeswap: a = {0}, b = {1}", a, b);

      Console.WriteLine();
      unsafe { UsePointerToPoint(); }
      unsafe { UnsafeStackAlloc(); }
      unsafe { UseAndPinPoint(); }
      unsafe { UseSizeOfOperator();}




    }

    struct Point {
      public int x;
      public int y;

      public override string ToString() {
        return String.Format("({0},{1})", x, y);
      }
    }

    class PointRef {
      public int x;
      public int y;

      public override string ToString() {
        return String.Format("({0},{1})", x, y);
      }
    }

    unsafe static void SquareIntPointer(int* x_ptr) {
      *x_ptr *= *x_ptr;
    }

    unsafe static void PrintValueAndAddress() {
      int x;
      int* x_ptr = &x;
      *x_ptr = 10;
      // print some stats 
      Console.WriteLine("Value of x {0}", *x_ptr);
      Console.WriteLine("Address of x {0:X}", (long)x_ptr);
    }

    static void SafeSwap(ref int x, ref int y) {
      int tmp = x;
      x = y;
      y = tmp;
    }

    unsafe static void UnsafeSwap(int* x, int* y) {
      int tmp = *x;
      *x = *y;
      *y = tmp;
    }
    
    unsafe static void UsePointerToPoint() {
      // access via pointer 
      Point p;
      Point* p_ptr = &p;

      p_ptr->x = 100;
      p_ptr->y = 200;
      Console.WriteLine(p_ptr->ToString());

      // 
      Point p2;
      Point* p2_ptr = &p2;
      (*p2_ptr).x = 15;
      (*p2_ptr).y = 19;
      Console.WriteLine((*p2_ptr).ToString());
    }

    unsafe static void UnsafeStackAlloc() {
      char* p = stackalloc char[256];
      Point* points = stackalloc Point[5];

      for (int i = 0; i < 256; i++) {
        p[i] = (char)i;
      }

      for (int j = 0; j < 5; j++) {
        Point ptmp;
        ptmp.x = 10 * j;
        ptmp.y = 10 * j;
        points[j] = ptmp;
        Console.WriteLine(points[j].ToString());
      }


    }

    unsafe public static void UseAndPinPoint() {
      PointRef p = new PointRef();
      p.x = 5;
      p.y = 6;

      // pint pt in place so it will not be moved or GC-ed
      fixed (int* pt = &p.x) {
        *pt = 10;
      }
      // pt is now unpinned and can be GC-ed 
      Console.WriteLine("Point is: {0}", p.ToString());


    }

    unsafe static void UseSizeOfOperator() {
      Console.WriteLine("The size of short is {0}.", sizeof(short));
      Console.WriteLine("The size of int is {0}.", sizeof(int));
      Console.WriteLine("The size of long is {0}.", sizeof(long));
      Console.WriteLine("The size of Point is {0}.", sizeof(Point));

    }



  }
}
