using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleEast : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.Balkans),
            World.GetCountry(CountryName.MediterraneanSea),
            World.GetCountry(CountryName.NorthAfrica),
            World.GetCountry(CountryName.Ukraine),
            World.GetCountry(CountryName.Kazakhstan),
            World.GetCountry(CountryName.India),
            World.GetCountry(CountryName.BayOfBengal),
            World.GetCountry(CountryName.Szechuan),
            World.GetCountry(CountryName.BlackSea),
            World.GetCountry(CountryName.CaspianSea),
        };
    }
}
