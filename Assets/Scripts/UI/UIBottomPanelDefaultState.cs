using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBottomPanelDefaultState : SingletonMonoBehaviour<UIBottomPanelDefaultState>, IBottomPanelState
{
    public UIBottomPanel.BottomPanelState PanelState()
    {
        return UIBottomPanel.BottomPanelState.Default;
    }
    public void SetGameAction(GameAction gameAction)
    {
    }

}
