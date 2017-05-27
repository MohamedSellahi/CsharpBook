using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenerateXMLFromArray {
  class Program {
    static void Main(string[] args) {
      MakeXElementFromArray();
      ParseAndLoadExistingXML();
    }


    static void MakeXElementFromArray() {
      // create anonymous array fro manomymous type
      var people = new[] {
        new {FirstName = "Mandy", Age = 32},
        new {FirstName = "Andrew", Age = 40},
        new {FirstName = "Dave", Age = 41},
        new {FirstName = "Sara", Age = 25},
      };

      XElement peopleDoc =
        new XElement("People",
          from c in people
          select new XElement("Person", new XAttribute("Age", c.Age),//new XAttribute("FirstName",c.FirstName))
                 new XElement("FirstName", c.FirstName))
        );
      Console.WriteLine(peopleDoc);
      Console.WriteLine("--------------");
    }

    // Build XML XElement from string 
    static void ParseAndLoadExistingXML() {
      string myElement = @"<Car ID = '3'> 
                             <Color>Yellow</Color>
                             <Maker>Yugo</Maker>
                           </Car>";
      try {
        XElement newElement = XElement.Parse(myElement);
        Console.WriteLine(newElement);
        Console.WriteLine("---------------");
      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }

      // Try Parse file 
      try {
        XDocument myDoc = XDocument.Load(@"C:\Users\Mohamed\Desktop\test.xml");
        Console.WriteLine(myDoc);
      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }


    }



  }
}
