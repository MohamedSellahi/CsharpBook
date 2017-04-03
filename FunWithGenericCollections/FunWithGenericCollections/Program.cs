using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;


namespace FunWithGenericCollections {
  class Program {
    static void Main(string[] args) {

      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
      Console.WriteLine("*** Fun with List *****");
      UseGenericList();

      Console.WriteLine("\n*** Fun with stack *****");
      UseGenericStack();

      Console.WriteLine("\n*** Fun with Queue *****");
      UseGenericQueue();

      Console.WriteLine("\n*** Fun with Queue *****");
      UseGenericSet();
    }


    static void UseGenericList() {

      List<Person> people = new List<Person>()
      {
        new Person { Fname = "Homer", Lname = "Simpson", Age = 47 },
        new Person { Fname = "Marge", Lname = "Simpson", Age = 45 },
        new Person { Fname = "Lisa", Lname = "Simpson", Age = 9 },
        new Person { Fname = "Bart", Lname = "Simpson", Age = 8 }
      };
      Console.WriteLine("Items in list {0}", people.Count);

      // ENumerate over list 
      foreach (Person item in people) {
        Console.WriteLine(item);
      }

      // insert new person 
      Console.WriteLine("\n->inserting new person.");
      people.Insert(2, new Person { Fname = "Maggie", Lname = "Simpson", Age = 2 });
      Console.WriteLine("Items in list {0}", people.Count);


      // copy Date into an array 
      Person[] arrayPeople = people.ToArray();
      for (int i = 0; i < arrayPeople.Length; i++) {
        Console.WriteLine("First names: {0}", arrayPeople[i].Fname);
      }

    }

    static void UseGenericStack() {
      Stack<Person> stackPeople = new Stack<Person>();
      stackPeople.Push(new Person { Fname = "Homer", Lname = "Simpson", Age = 47 });
      stackPeople.Push(new Person { Fname = "Marge", Lname = "Simpson", Age = 45 });
      stackPeople.Push(new Person { Fname = "Lisa", Lname = "Simpson", Age = 9 });
      stackPeople.Push(new Person { Fname = "Bart", Lname = "Simpson", Age = 8 });

      // Looking at the top item then poping it 
      Console.WriteLine("First person is:{0}", stackPeople.Peek());
      Console.WriteLine("Popped off {0}", stackPeople.Pop());

      Console.WriteLine("\nFirst person is:{0}", stackPeople.Peek());
      Console.WriteLine("Popped off {0}", stackPeople.Pop());

      Console.WriteLine("\nFirst person is:{0}", stackPeople.Peek());
      Console.WriteLine("Popped off {0}", stackPeople.Pop());


      Console.WriteLine("\nFirst person is:{0}", stackPeople.Peek());
      Console.WriteLine("Popped off {0}", stackPeople.Pop());


      try {
        Console.WriteLine("\nFirst person is:{0}", stackPeople.Peek());
        Console.WriteLine("Popped off {0}", stackPeople.Pop());
      }
      catch (InvalidOperationException e) {
        Console.WriteLine("\nError! {0}", e.Message);
      }


    }

    static void UseGenericQueue() {
      Queue<Person> queuePeople = new Queue<Person>();
      queuePeople.Enqueue(new Person { Fname = "Homer", Lname = "Simpson", Age = 47 });
      queuePeople.Enqueue(new Person { Fname = "Marge", Lname = "Simpson", Age = 45 });
      queuePeople.Enqueue(new Person { Fname = "Lisa", Lname = "Simpson", Age = 9 });
      queuePeople.Enqueue(new Person { Fname = "Bart", Lname = "Simpson", Age = 8 });

      // peek at first person
      Console.WriteLine("{0} is first in the line.", queuePeople.Peek());

      // remove each person from the que
      while (queuePeople.Count > 0) {
        GetCoffee(queuePeople.Dequeue());
      }

      // this will throw an exception 
      try {
        GetCoffee(queuePeople.Dequeue());
      }
      catch (InvalidOperationException e) {
        Console.WriteLine("Error! {0}", e.Message);
      }

    }

    static void GetCoffee(Person p) {
      Console.WriteLine("{0} got coffee!", p.Fname);

    }

    static void UseGenericSet() {
      SortedSet<Person> People = new SortedSet<Person>(new SortPeopleByAge()) {
         new Person { Fname = "Homer", Lname = "Simpson", Age = 47 },
        new Person { Fname = "Marge", Lname = "Simpson", Age = 45 },
        new Person { Fname = "Lisa", Lname = "Simpson", Age = 9 },
        new Person { Fname = "Bart", Lname = "Simpson", Age = 8 }
      };

      // are the items sorted by age 
      foreach (Person item in People) {
        Console.WriteLine(item);
      }

      // Add a few new people, with various ages.
      People.Add(new Person { Fname = "Saku", Lname = "Jones", Age = 1 });
      People.Add(new Person { Fname = "Mikko", Lname = "Jones", Age = 32 });

      foreach (Person item in People) {
        Console.WriteLine(item);
      }


    }

  }
}
