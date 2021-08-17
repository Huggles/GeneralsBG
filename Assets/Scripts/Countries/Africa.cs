using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Africa : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.SouthAtlantic),
            World.GetCountry(CountryName.SouthernOcean),
            World.GetCountry(CountryName.IndianOcean),
            World.GetCountry(CountryName.BayOfBengal),
            World.GetCountry(CountryName.NorthAfrica),
        };
    }
}
