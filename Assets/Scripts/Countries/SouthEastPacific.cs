using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthEastPacific : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.EastPacific),
            World.GetCountry(CountryName.SouthAmerica),
            World.GetCountry(CountryName.SouthernOcean)
        };
    }
}
