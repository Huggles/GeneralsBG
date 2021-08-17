using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madagascar : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.BayOfBengal),
            World.GetCountry(CountryName.IndianOcean)
        };
    }

}
