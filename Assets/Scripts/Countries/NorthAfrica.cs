using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthAfrica : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.MediterraneanSea),
            World.GetCountry(CountryName.MiddleEast),
            World.GetCountry(CountryName.Africa),
            World.GetCountry(CountryName.BayOfBengal),
            World.GetCountry(CountryName.NorthSea)
        };
    }
}
