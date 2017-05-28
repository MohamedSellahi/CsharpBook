using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator {
  class CityInfo {
    string _cityName;
    string _countryName;
    int _pop2010;

    public CityInfo(string name, string country, int pop) {
      _cityName = name;
      _countryName = country;
      _pop2010 = pop;
    }

    public string City { get { return _cityName; } }

    public string Country { get { return _countryName; } }

    public int Population { get { return _pop2010; } }

    // comparaison methods 
    public static int CompareByName(CityInfo c1, CityInfo c2) {
      return String.Compare(c1.City, c2.City);
    }

    public static int CompareByPopulation(CityInfo c1, CityInfo c2) {
      return c1.Population.CompareTo(c2.Population);
    }

    public static int CompareByNames(CityInfo c1, CityInfo c2) {
      return String.Compare(c1.Country + c1.City, c2.Country + c2.City);
    }






  }
}
