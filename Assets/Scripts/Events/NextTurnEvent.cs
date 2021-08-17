using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurnEvent : PubSubEvent
{
    public int TurnNumber;
    public Player Player;
}
