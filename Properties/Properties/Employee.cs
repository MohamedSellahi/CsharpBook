using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties {
  class Employee {

    private string empName;
    private int empID;
    private float currPay;
    private int empAge;

    // properties 
    public string NAME {
      get {
        return empName;
      }
      set {
        if (value.Length > 15) {
          Console.WriteLine("Error: name too long");
        }
        else {
          empName = value;
        }
      }
    }
    public int AGE {
      get {
        return empAge;
      }
      set {
        empAge = value;
      }
    }
    public int ID {
      get {
        return empID;
      }
      set {
        empID = value;
      }
    }
    public float PAY {
      get {
        return currPay;
      }
      set {
        currPay = value;
      }
    }

    // static data:
    private static int Count = 0;
    public static int NbEmployee {
      get {
        return Count;
      }
      private set {
        Count = value;
      }
    }

    // constructors 
    public Employee() {
      ++Count;
    }
    /// <summary>
    /// Creates and employee 
    /// </summary>
    /// <param name="name">
    /// <value>
    /// name of the employee
    /// </value>
    /// </param>
    /// <param name="age">
    /// <value>age de l'employe</value>
    /// </param>
    /// <param name="id"><value> Identifiant unique de l'emplye </value></param>
    /// <param name="pay"><value>payement initial de l'employe</value></param>
    public Employee(string name, int age, int id, float pay) {
      NAME = name;
      AGE = age;
      ID = id;
      PAY = pay;
      ++Count;
    }

    public Employee(string name, int id, float pay):this(name, 0, id, pay) {
    }

    // Methods
    public void GiveBonus(float bonus) {
      PAY += bonus;
    }

    public void DisplayStats() {
      Console.WriteLine("Name: {0}", NAME);
      Console.WriteLine("ID: {0}", ID);
      Console.WriteLine("Age: {0}", AGE);
      Console.WriteLine("pay: {0}", PAY);
    }




  }
}
