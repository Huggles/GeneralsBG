using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerSelectionPanelPayload
{
    public delegate void PlayerSelectionDelegate(Player selectedPlayer);

    public List<Player> Players;
    public PlayerSelectionDelegate Callback;

    public PlayerSelectionPanelPayload(List<Player> players, PlayerSelectionDelegate callback)
    {
        Players = players;
        Callback = callback;
    }

}
