using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WesternEurope : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.NorthSea),
            World.GetCountry(CountryName.MediterraneanSea),
            World.GetCountry(CountryName.BalticSea),
            World.GetCountry(CountryName.Germany),
            World.GetCountry(CountryName.Italy),
        };
    }
}
