using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthSea : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.UnitedKingdom),
            World.GetCountry(CountryName.Iceland),
            World.GetCountry(CountryName.Scandinavia),
            World.GetCountry(CountryName.NorthAtlantic),
            World.GetCountry(CountryName.SouthAtlantic),
            World.GetCountry(CountryName.MediterraneanSea),
            World.GetCountry(CountryName.WesternEurope),
            World.GetCountry(CountryName.NorthAfrica),
            World.GetCountry(CountryName.BalticSea),
        };
    }
}
