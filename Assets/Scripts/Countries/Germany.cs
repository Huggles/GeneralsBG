using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germany : Country
{
    public override bool IsSupply()
    {
        return true;
    }
    public override List<Country> AdjacentCountries()
    {
        return new List<Country> {
            World.GetCountry(CountryName.WesternEurope),
            World.GetCountry(CountryName.BalticSea),
            World.GetCountry(CountryName.EasternEurope),
            World.GetCountry(CountryName.Balkans),
            World.GetCountry(CountryName.Italy),

        };
    }
}
