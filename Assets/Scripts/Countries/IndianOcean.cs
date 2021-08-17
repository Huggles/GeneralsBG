using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndianOcean : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.BayOfBengal),
            World.GetCountry(CountryName.Madagascar),
            World.GetCountry(CountryName.SouthernOcean),
            World.GetCountry(CountryName.Africa),
            World.GetCountry(CountryName.SouthPacific),
            World.GetCountry(CountryName.Australia),
            World.GetCountry(CountryName.SouthChinaSea),

        };
    }
}
