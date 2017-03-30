using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Exceptions {
  class Program {
    static void Main(string[] args) {

      #region TargetSite 

      Console.WriteLine("***** Simple Exception Example *****");
      Console.WriteLine("=> Creating  a car and stepping on it!");

            

      Car myCar = new Car("Zippy", 20);
      try {
        for (int i = 0; i < 10; i++) {
          myCar.Accelerate(10);
        }
      }
      catch (Exception e) {
        Console.WriteLine("\n*** Error! ***");
        Console.WriteLine("Method (targetsite): {0}", e.TargetSite);
        Console.WriteLine("Message: {0}", e.Message);
        Console.WriteLine("Source: {0}", e.Source);
        Console.WriteLine("\n-------------------------");
        Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType);
        Console.WriteLine("Member Type (member type): {0}",e.TargetSite.MemberType);
        Console.WriteLine("Member Type (get type): {0}", e.TargetSite.GetType());
        Console.WriteLine("\n--------- StackTrace  ------------\n");
        Console.WriteLine(e.StackTrace);
        Console.WriteLine("\n----------- HelpLink --------\n");
        Console.WriteLine(e.HelpLink);
        Console.WriteLine("\n-------- data propertie ---------\n");
        if (e.Data != null) {
          IDictionary dic = e.Data; 
          foreach (DictionaryEntry item in e.Data) {
            Console.WriteLine("{0}: {1}", item.Key, item.Value);
          }
        }
        
      }

      Console.WriteLine("\n***** Out of Exceptiuon Logic");
      
      #endregion


      #region StackProperty




      #endregion


    }
  }
}
