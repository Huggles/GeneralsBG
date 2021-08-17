using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balkans : Country
{
    public override List<Country> AdjacentCountries()
    {
        return new List<Country>{
            World.GetCountry(CountryName.Italy),
            World.GetCountry(CountryName.MediterraneanSea),
            World.GetCountry(CountryName.EasternEurope),
            World.GetCountry(CountryName.Ukraine),
            World.GetCountry(CountryName.Germany),
            World.GetCountry(CountryName.MiddleEast),
            World.GetCountry(CountryName.BlackSea),
        };
    }
}
