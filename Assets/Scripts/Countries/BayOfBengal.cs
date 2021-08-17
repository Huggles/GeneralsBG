using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayOfBengal : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.Madagascar),
            World.GetCountry(CountryName.Africa),
            World.GetCountry(CountryName.NorthAfrica),
            World.GetCountry(CountryName.IndianOcean),
            World.GetCountry(CountryName.MediterraneanSea),
            World.GetCountry(CountryName.MiddleEast),
            World.GetCountry(CountryName.India),
            World.GetCountry(CountryName.SouthEastAsia),
            World.GetCountry(CountryName.SouthChinaSea),
            World.GetCountry(CountryName.Indonesia),
        };
    }
}
