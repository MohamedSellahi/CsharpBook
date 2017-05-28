using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace LindToXmlWinApp {
  class LinqToXmlObjectModel {
    // populate an inventory object
    public static XDocument GetXmlInventory() {
      try {
        XDocument inventoryDoc = XDocument.Load("Inventory.XML");
        return inventoryDoc;
      }
      catch (Exception e) {
        MessageBox.Show(e.Message);
        return null;
      }

    }

    public static void InsertNewElement(string maker, string color, string petname) {
      // Load the current document 
      XDocument inventorDoc = XDocument.Load("Inventory.XML");

      // generate random number on incoming parameters 
      Random rnd = new Random();

      // Make new Element 
      XElement newElement = new XElement("Car", new XAttribute("ID", rnd.Next(5000)),
                              new XElement("Color", color),
                              new XElement("Maker", maker),
                              new XElement("PetName", petname)
                            );

      // Add in-memory object 
      inventorDoc.Descendants("Inventory").First().Add(newElement);

      // Save changes to disk 
      inventorDoc.Save("Inventory.XML");

    }

    public static void LookUpColorsForMaker(string maker) {
      // Load the document 
      XDocument inventoryDoc = XDocument.Load("Inventory.XML");



      var makeInfo = from car in inventoryDoc.Descendants("Car")
                     where (string)car.Element("Maker") == maker
                     select car.Element("Color").Value;
   
      // Build a string representin each color 
      string data = string.Empty;
      foreach (var item in makeInfo.Distinct()) {
        data += string.Format("- {0}\n", item);
      }
      MessageBox.Show(data, string.Format("{0} colors:", maker));

    }




  }
}
