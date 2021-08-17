using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using SuperMaxim.Messaging;

public class RoundTrackerPanel : SingletonMonoBehaviour<RoundTrackerPanel>
{
    private GameManager gameState;

    private TextMeshProUGUI turnTrackerText;
    private TextMeshProUGUI playerTrackerText;

    public void Awake()
    {
        gameState = GameManager.Instance;
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI textMeshPro in texts)
        {
            if (textMeshPro.name == "TurnNumberText") turnTrackerText = textMeshPro;
            if (textMeshPro.name == "CurrentPlayerText") playerTrackerText = textMeshPro;
        }
        Messenger.Default.Subscribe((NextTurnEvent payload) => { Refresh(); });
    }
    public void Refresh()
    {
        if (gameState != null)
        {
            turnTrackerText.text = "Turn: " + gameState.TurnNumber.ToString();
            playerTrackerText.text = "Player: " + gameState.CurrentPlayer.playerName;
            playerTrackerText.color = gameState.CurrentPlayer.playerColor;
        }
    }

}
