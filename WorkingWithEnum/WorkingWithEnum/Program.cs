using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithEnum {
  class Program {
    static void Main(string[] args) {

      DayOfWeek samedi = DayOfWeek.Saturday;
      EvaluateEnum(samedi);



    }// end of main 
    enum WeekDay {
      samedi,
      dimanche,
      lundi,
      mardi,
      mecredi,
      jeudi,
      vendredi
    }

    static void EvaluateEnum(System.Enum e) {
      Console.WriteLine("=> information about {0}", e.GetType().Name);
      Console.WriteLine("underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()) );

      Array enumData = Enum.GetValues(e.GetType());
      foreach(var item in enumData) {
        Console.WriteLine("Name: {0}, Value: {0:D}", item, item);
      }
      Console.WriteLine();
    }



  }// end of class
}// end of namesapce

