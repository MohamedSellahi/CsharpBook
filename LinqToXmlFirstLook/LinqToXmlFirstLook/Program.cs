using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LinqToXmlFirstLook {
  class Program {
    static void Main(string[] args) {
      BuildXmlDocWithDOM();
      BuildXmlDocWithLINQtoXML();
    }

    // DOM for Document Object Model old style 
    public static void BuildXmlDocWithDOM() {
      // Make a new XML doc in memory 
      XmlDocument doc = new XmlDocument();

      // Fill this document with a root element named
      // Inventory 
      XmlElement inventory = doc.CreateElement("Inventory");
      // Now make a subelelemnt named <Car> with 
      // ID attribute 
      XmlElement car = doc.CreateElement("Car");
      car.SetAttribute("ID", "1000");

      XmlElement name = doc.CreateElement("PetName");
      name.InnerText = "jimbo";
      XmlElement color = doc.CreateElement("Color");
      color.InnerText = "Red";
      XmlElement maker = doc.CreateElement("Maker");
      maker.InnerText = "Ford";

      // add <PetName> <Color> <Maker> to <Car> element 
      car.AppendChild(name);
      car.AppendChild(color);
      car.AppendChild(maker);

      // add <Car> to <Inventory>
      inventory.AppendChild(car);

      // insert the complete xml into the xmlDocument 
      
      doc.AppendChild(inventory);
      doc.Save("Inventory");
      
    }

    // LINQ to XML 
    public static void BuildXmlDocWithLINQtoXML() {
      // create xmlDocument with a more functionnal manner 
      XElement doc = new XElement("Inventory",
                         new XElement("Car", new XAttribute("ID", "1000"),
                             new XElement("PetName", "Jimbo"),
                             new XElement("Color", "Red"),
                             new XElement("Maker", "Ford")
                         )
                      );
      XElement doc2 = new XElement("Head0",
                           new XElement("Head00", new XAttribute("at00", "00"), new XAttribute("at01", "01"),
                               new XElement("Head10", new XAttribute("at10", "10")),
                               new XElement("Head20", new XAttribute("at20", "20"),
                                   new XElement("Head200", new XAttribute("at200", "200"),
                                       new XElement("Head2000", new XAttribute("at2000", "2000")))
                               )
                           )
        );
      // Save to file
      doc.Save("InventoryWithLINQ.xml");
      doc2.Save("InventoryWithLINQ2.xml");

    }

  }
}
