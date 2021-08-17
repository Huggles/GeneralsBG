using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthernOcean : Country
{    
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.SouthAmerica),
            World.GetCountry(CountryName.SouthEastPacific),
            World.GetCountry(CountryName.SouthAtlantic),
            World.GetCountry(CountryName.Africa),
            World.GetCountry(CountryName.IndianOcean),
        };
    }
}
