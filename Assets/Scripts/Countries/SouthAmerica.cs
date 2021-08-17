using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthAmerica : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.EasternUnitedStates),
            World.GetCountry(CountryName.NorthAtlantic),
            World.GetCountry(CountryName.SouthAtlantic),
            World.GetCountry(CountryName.SouthEastPacific),
            World.GetCountry(CountryName.SouthernOcean),
        };
    }
}
