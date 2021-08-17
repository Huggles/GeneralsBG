using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthAtlantic : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.NorthAtlantic),
            World.GetCountry(CountryName.NorthSea),
            World.GetCountry(CountryName.SouthAmerica),
            World.GetCountry(CountryName.SouthernOcean),
            World.GetCountry(CountryName.Africa),
        };
    }
}
