using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacedEvent : UnitEvent
{
    public Unit Unit;
    public UnitPlacedEvent(Country inCountry, Player byPlayer, Unit unit) : base (inCountry, byPlayer)
    {
        Unit = unit;
    }
}
