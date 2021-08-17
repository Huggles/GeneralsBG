using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackedEvent : UnitEvent
{
    public UnitAttackedEvent(Country inCountry, Player byPlayer, UnitType unitType) : base(inCountry, byPlayer)
    {
        UnitType = unitType;
    }
}
