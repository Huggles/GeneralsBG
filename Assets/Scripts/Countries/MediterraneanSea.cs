using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediterraneanSea : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.WesternEurope),
            World.GetCountry(CountryName.NorthAfrica),
            World.GetCountry(CountryName.Balkans),
            World.GetCountry(CountryName.BlackSea),
            World.GetCountry(CountryName.MiddleEast)
        };
    }
}
