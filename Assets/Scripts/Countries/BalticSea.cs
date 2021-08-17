using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalticSea : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.Scandinavia),
            World.GetCountry(CountryName.Russia),
            World.GetCountry(CountryName.EasternEurope),
            World.GetCountry(CountryName.Germany),
            World.GetCountry(CountryName.WesternEurope),
        };
    }
}
