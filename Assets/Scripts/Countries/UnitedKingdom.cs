using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitedKingdom : Country
{

    public override bool IsSupply()
    {
        return true;
    }
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.NorthSea)
        };
    }
}
