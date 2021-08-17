using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthAtlantic : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.EasternCanada),
            World.GetCountry(CountryName.EasternUnitedStates),
            World.GetCountry(CountryName.SouthAmerica),
            World.GetCountry(CountryName.NorthSea),
            World.GetCountry(CountryName.SouthAtlantic),
            World.GetCountry(CountryName.Iceland)
        };
    }
}
