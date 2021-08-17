using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasternCanada : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.EasternUnitedStates),
            World.GetCountry(CountryName.WesternCanada),
            World.GetCountry(CountryName.NorthAtlantic)
        };
    }
}
