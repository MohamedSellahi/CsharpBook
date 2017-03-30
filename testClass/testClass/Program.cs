using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testClass {
  class Program {
    static void Main(string[] args) {

      Personne per1 = new Personne();
      per1.setNom("Merouane");
      Console.WriteLine(per1.getNom());

      // 
      Console.WriteLine("---------- test Client -----------");
      Client cl1 = new Client();
      cl1.setNom("Merouane");
      cl1.setAdresse("Montpellier");
      Console.WriteLine("{0} vie à {1}", cl1.getNom(), cl1.getAdresse());


    }// end of main

    class Personne {
      // les attributs
      protected string nom, prenom;
      
      public string getNom() {
        return nom;
      }

      public void setNom(string s) {
        nom = s;
      }
    }


    class Client : Personne {
      private string addresse;
      public void setAdresse(string s) {
        addresse = s;
      }

      public string getAdresse() {
        return addresse;
      }
    }

    class Directeur: Personne {
      private float revenu;

      public void setRevenue(float rev) {
        revenu = rev;
      }

      public float getRevenue() {
        return revenu;
      }

    }





  }
}
