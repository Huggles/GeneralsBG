using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasternEurope : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.Russia),
            World.GetCountry(CountryName.BalticSea),
            World.GetCountry(CountryName.Ukraine),
            World.GetCountry(CountryName.Germany),
            World.GetCountry(CountryName.Balkans),
        };
    }
}
