using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassRefByValue {
  class Program {
    static void Main(string[] args) {
      // Passing ref-Types by value
      Console.WriteLine("****** Passing Person by value ******");
      Person fred = new Person("Fred", 12);
      Console.WriteLine("\nBefore by value call, Person is:");
      fred.display();

      SendPersonByValue(fred);
      Console.WriteLine("\nAfter by value call, Person is:");
      fred.display();

      SendPersonByReference(ref fred);
      Console.WriteLine("\nAfter by ref call, Person is:");
      fred.display();
       


    }// end of main 

    class Person {
      public string personName;
      public int personAge;

      // Constructors.
      public Person(string name, int age) {
        personName = name;
        personAge = age;
      }

      public Person() { }

      public void display() {
        Console.WriteLine("Name: {0}, Age: {1}\n", personName,personAge);
      }
    }

    static void SendPersonByValue(Person p) {
      // Change the caller age of "p"
      p.personAge = 100;
      // Will the caller see this reassignement 
      p = new Person("Nikki", 99);
    }

    static void SendPersonByReference(ref Person p) {
      // change some data of p;
      p.personAge = 555;
      // the previous change will be lost 
      // "p" is now pointing 
      p = new Person("Nikki", 999);
    }
  }
}
