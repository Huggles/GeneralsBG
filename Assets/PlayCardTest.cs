using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCardTest : MonoBehaviour
{
    public void OnPlayBattleButtonClicked()
    {
        LandBattleGameAction landBattleGameAction = new LandBattleGameAction(GameManager.Instance.CurrentPlayer);        
        GameActionManager.Instance.AddAction(landBattleGameAction);
    }
    public void OnPlayArmyButtonClicked()
    {
        PlaceArmyGameAction placeArmyGameAction = new PlaceArmyGameAction(GameManager.Instance.CurrentPlayer);
        GameActionManager.Instance.AddAction(placeArmyGameAction);
    }
}
