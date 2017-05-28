using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate {
  class Program {
    // using the Action<> and Func<> 



    static void Main(string[] args) {
      Console.WriteLine("***** Fun with aaction and function *****\n");

      // Use the Action<> delegate to point to Display
      Action<string, ConsoleColor, int> actionTerget = new Action<string, ConsoleColor, int>(DisplayMessage);
      Func<int, int, int> funcTarget = new Func<int, int ,int>(Add);
      Func<int, int, string> funcStrTarget = new Func<int, int, string>(SumToString);

      actionTerget("Action Message!", ConsoleColor.Yellow, 5);
      actionTerget(string.Format("{0} + {1} = {2}", 5, 6, funcStrTarget(5, 6)), ConsoleColor.DarkCyan, 1);

      int result = funcTarget.Invoke(10, 10);


    }

    public static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount) {
      // set color for console text.
      ConsoleColor previous = Console.ForegroundColor;
      Console.ForegroundColor = txtColor;

      for (int i = 0; i < printCount; i++) {
        Console.WriteLine(msg);
      }

      //Restore Color
      Console.ForegroundColor = previous;

    }
    public static int Add(int x, int y) {
      return x + y;
    }

    public static string SumToString(int x, int y) {
      return (x + y).ToString();
    }


  }
}
