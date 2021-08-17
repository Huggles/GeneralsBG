using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEvent : PubSubEvent
{
    public Country TargetCountry;
    public Unit TargetUnit;
    public Player TriggeringPlayer;

    public UnitType UnitType;

    public UnitEvent(Country inCountry, Player byPlayer)
    {
        TargetCountry = inCountry;
        TriggeringPlayer = byPlayer;
    }
    public UnitEvent(Country inCountry, Player byPlayer, Unit unit)
    {
        TargetCountry = inCountry;
        TriggeringPlayer = byPlayer;
        TargetUnit = unit;

    }
}
