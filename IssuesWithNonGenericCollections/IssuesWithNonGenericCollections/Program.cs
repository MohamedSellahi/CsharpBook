using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithNonGenericCollections {
  class Program {
    static void Main(string[] args) {
      // Value types are autmatically boxed when 
      // passed to a member requiring an object

      ArrayList myInts = new ArrayList();
      for (int j = 0; j < 10; j++) {
        myInts.Add(j);
      }

      // unbooxing occurs when an object to converted back to 
      // stack-based datatypes 
      int i = (int)myInts[0];

      // Now it is reboxed as WriteLine() requires object types!
      Console.WriteLine("Value of your int is {0}", i);

      Console.WriteLine("\n***** Custom Person Collection ******\n");
      PersonCollection myPeople = new PersonCollection();
      for (int j = 0; j < 5; j++) {
        myPeople.AddPerson(new Person("fname" + j, "lname" + j, 2 * j + 30));
      }

      foreach (Person item in myPeople) {
        Console.WriteLine(item);
      }

      // A first look at generics 
      Console.WriteLine("\n***** Fun With generics *****\n");
      List<Person> morePeople = new List<Person>();
      morePeople.Add(new Person("Frank", "Black", 50));
      Console.WriteLine(morePeople[0]);

      //
      List<int> moreInts = new List<int>();
      moreInts.Add(10);
      moreInts.Add(2);
      int sum = moreInts.Sum();
      Console.WriteLine(sum);
      
     

    }





    static void SimpleBoxUnboxOperation() {
      // Make a value type (int) variable 
      int myInt = 25;
      // box the int into an object reference 
      object boxedInt = myInt;

      // Unbox the reference back to a corresponding int;
      int unBoxedInt = (int)boxedInt;
    }



  }
}
