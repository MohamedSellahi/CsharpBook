using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsevableCollection {
  class Program {
    static void Main(string[] args) {
      ObservableCollection<Person> people = new ObservableCollection<Person>() {
        new Person{ Fname = "Peter", Lname = "Murphy", Age = 52},
        new Person { Fname = "Kevin", Lname = "Key", Age = 48}
      };

      // Wire up the collection event.
      people.CollectionChanged += People_CollectionChanged;

      foreach (Person item in people) {
        Console.WriteLine(item);
      }
      Console.WriteLine();

      Person Mickel = new Person { Fname = "Mickel", Lname = "Jackson", Age = 50 };
      people.Add( new Person { Fname = "Bob", Lname = "Marley", Age = 50 });
      people.Add(Mickel);
      people.Remove(Mickel);


    }


    static void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
      // What was the action that caused the event 
      Console.WriteLine("Action for this event: {0}", e.Action);

      // thesy removed something ? 
      if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
        Console.WriteLine("Here are the old items ");
        foreach (Person item in e.OldItems) {
          Console.WriteLine(item);
        }
        Console.WriteLine();
      }
      if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
        // Now shpw the new items 
        Console.WriteLine("Here are the new items ");
        foreach (Person item in e.NewItems) {
          Console.WriteLine(item);
        }
        Console.WriteLine();
      }


    }




  }
}
