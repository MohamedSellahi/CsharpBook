using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword {
  class Program {
    static void Main(string[] args) {

      UseObjectVariable();
      PrinttreeStrings();
      ChangeDynamicDataType();
      InvokeMembersOnDynamicData();

      // 
      DynamicClass dc = new DynamicClass();
      Console.WriteLine(dc.DynamicMethod(20.0));

    }


    static public void ImplicitlyTypedVariable() {
      var a = new List<int>();
      a.Add(90); 

      // this would not compile 
      // a = "Hello" 

    }

    static void UseObjectVariable() {
      object o = new Person() { FirstName = "Mike", LastName = "Larson" };
      // must cast to person to get access to the Person properies 
      Console.WriteLine("Perso'n first name is {0}", ((Person)o).FirstName);
      Console.WriteLine(o.GetType());
    }

    static void PrinttreeStrings() {
      var s1 = "Greeting";
      object s2 = "From";
      // object whos operation will be reslved at run time 
      dynamic s3 = "Minneapolis";
      Console.WriteLine("s1 is of type: {0}", s1.GetType());
      Console.WriteLine("s2 is of type: {0}", s2.GetType());
      Console.WriteLine("s3 is of type: {0}", s3.GetType());

    }

    static void ChangeDynamicDataType() {
      dynamic t = "Hello";
      Console.WriteLine("t is of type: {0}", t.GetType());

      t = false;
      Console.WriteLine("t is of type: {0}", t.GetType());

      t = new List<int>();
      Console.WriteLine("t is of type: {0}", t.GetType());


    }

    static void InvokeMembersOnDynamicData() {
      dynamic textData1 = "Hello";
      Console.WriteLine(textData1.ToUpper());
      
      // this will compile but causes a runtime exception 
      // of type Runtimebinderexception  found 
      // in Microsoft.CSharp.RuntimeBinder namespace

      try {
        Console.WriteLine(textData1.touuper());
      }
      catch (RuntimeBinderException e) {

        Console.WriteLine(e.Message);
      }

    }
  }
}
