using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : Unit
{    
    public override UnitType Type()
    {
        return UnitType.Army;
    }
}
