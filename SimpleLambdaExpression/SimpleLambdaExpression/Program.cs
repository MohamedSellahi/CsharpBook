using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpression {
  class Program {


    static void Main(string[] args) {
      Console.WriteLine("***** Fun with lambdas *****\n");

      List<int> myList = new List<int>() { Capacity = 50 };

      // fill with random data ; 
      Random rnd = new Random();

      for (int i = 0; i < myList.Capacity; i++) {
        myList.Add(rnd.Next(100));
      }

      foreach (int item in myList) {
        Console.Write("{0} ", item);
      }
      Console.WriteLine();
      Console.WriteLine("Total number: {0}", myList.Count);
      // Call find all using traditional syntax 
      Predicate<int> callbackMatchEven = new Predicate<int>(IsEvenNumber);
      Predicate<int> callBackMultipleOfThree = new Predicate<int>(IsMultipleOfThree);

      List<int> evenNumbers = myList.FindAll(callbackMatchEven);
      Console.WriteLine("Number of even numbers: {0}", evenNumbers.Count);

      List<int> multipleOfThree = myList.FindAll(callBackMultipleOfThree);
      Console.WriteLine("Number of multiples of three: {0}", multipleOfThree.Count);

      // USe anonymous Method syntax 

      List<int> MultiplesOfFive = myList.FindAll(delegate (int i) { return (i % 5) == 0; });
      Console.WriteLine("Number of multiples of five: {0}", MultiplesOfFive.Count);

      // Lambda expression syntax 
      // Another possibility of syntax : explicit types 
      // List<int> OddNumbers = myList.FindAll((int i)=>(i%2) == 0);

      List<int> OddNumbers = myList.FindAll(i => (i % 2) == 1);
      Console.WriteLine("Number of odd numbers: {0}", OddNumbers.Count);

      List<int> OddnumbersStepBystep = myList.FindAll((i) => {
        Console.WriteLine("Actual value of i : {0}", i);
        return (i % 2) == 0;
      });


      // Lambda expression syntax : continued 
      // 
      Console.WriteLine("\n-----------Math using lambdas ------------\n");
      int x = 90;
      int y = 10;
      MathFunction<int> AddHandler = new MathFunction<int>(Add);
      MathFunction<int> Substraction = delegate (int i, int j) { return i - j; };
      MathFunction<int> Multiplication = (int i, int j) => (i * j);
      MathFunction<int> Devision = (int i, int j) => (i / j);

      

      Console.WriteLine("{0} + {1} = {2}", x, y, AddHandler(x, y));
      Console.WriteLine("{0} - {1} = {2}", x, y, Substraction(x, y));
      Console.WriteLine("{0} * {1} = {2}", x, y, Multiplication(x, y));
      Console.WriteLine("{0} / {1} = {2}", x, y, Devision(x, y));


      double a = 3.0, b = 0;

      MathFunction<double> Delta = new MathFunction<double>(DoubleProduct);
      Console.WriteLine("{0:N2} * {1:N2} = {2:N2}", a, b, Delta(a,b));

      // Processing lambda with multiple parametters 
      MathFunction<double> ComplexFun = (double val1, double val2) => {
        if (val2 == 0)
          return 0;
        return val1/val2;
      };
      Console.WriteLine("{0:N2} / {1:N2} = {2:N2}", a,b,ComplexFun(a,b));










    }

    #region MYDelegates
    public delegate T MathFunction<T>(T x, T y);

    #endregion


    #region Handlers 
    private static bool IsMultipleOfThree(int obj) {
      return (obj % 3) == 0;
    }

    public static bool IsEvenNumber(int obj) {
      return (obj % 2) == 0;
    }

    // 
    public static bool FindInt(int x) {
      if (x <= 20)
        return true;
      return false;
    }


    public static int Add(int x, int y){
      return x + y;
    }

    public static double DoubleProduct(double a, double b) {
      return a*b; 
    }
    #endregion




  }
}
