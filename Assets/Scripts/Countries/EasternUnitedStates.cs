using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasternUnitedStates : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.EasternCanada),
            World.GetCountry(CountryName.SouthAmerica),
            World.GetCountry(CountryName.WesternUnitedStates),
            World.GetCountry(CountryName.NorthAtlantic),
        };
    }
}
