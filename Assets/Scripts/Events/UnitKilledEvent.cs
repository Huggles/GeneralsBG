using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitKilledEvent : UnitEvent
{
    public UnitKilledEvent(Country inCountry, Player byPlayer, UnitType unitType) : base(inCountry, byPlayer)
    {
        UnitType = unitType;
    }
}
