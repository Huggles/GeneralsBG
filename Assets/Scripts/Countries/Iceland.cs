using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceland : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.NorthAtlantic),
            World.GetCountry(CountryName.NorthSea)
        };
    }
}
