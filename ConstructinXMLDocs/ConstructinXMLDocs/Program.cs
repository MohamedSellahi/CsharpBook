using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConstructinXMLDocs {
  class Program {
    static void Main(string[] args) {
      CreateFullDocoment();
      CreateRootAndChildrn();
    }


    static void CreateFullDocoment() {
      // USe XDocument so to insert any processing instructions, XML declarations
      // otherwise XElement is sufficient 
      XDocument inventoryDoc =
        new XDocument(
          new XDeclaration("1.0","utf-8","yes"),
          new XComment("Current Inventory of cars"),
          new XProcessingInstruction("xml-stylesheet", "href='MyStyle.css' Title='Compact',type='text/css'"),
          new XElement("Inventory",
            new XElement("Car", new XAttribute("ID","1"),
              new XElement("Color", "Green"),
              new XElement("Maker", "BMW"),
              new XElement("PetName","Stan")
            ),
            new XElement("Car", new XAttribute("ID", "2"),
              new XElement("Color", "Pink"),
              new XElement("Maker", "Ford"),
              new XElement("PetName", "Melvin")
            )
         ) // Inventory 
      );
      // Save to Disk 
      inventoryDoc.Save("SimpleInventory.xml");
    }

    static void CreateRootAndChildrn() {
      // XElement root and children 
      XElement inventoryDoc =
        new XElement("Inventory",
        new XComment("Current Inventory of cars"),
          new XElement("Car", new XAttribute("ID", "1"),
            new XElement("Color", "Green"),
            new XElement("Maker","BMW"),
            new XElement("PetName", "Stan")
          ),
          new XElement("Car", new XAttribute("ID", "1"),
            new XElement("Color", "pink"),
            new XElement("Maker", "Ford"),
            new XElement("PetName", "Melvin")
            )
        );

      inventoryDoc.Save("SimpleInventory2.xml");
    }


  }
}
