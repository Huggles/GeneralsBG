using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SuperMaxim.Core;
using SuperMaxim.Messaging;


public class UIBottomPanel : SingletonMonoBehaviour<UIBottomPanel>
{
    public enum BottomPanelState
    {
        Default,
        SelectOneCountry,
        SelectTwoCountries,
    }
    
    public BottomPanelState _state;
    private GameAction _gameAction;


    public void SetGameAction(GameAction gameAction)
    {

        _gameAction = gameAction;
        SetPanelState(gameAction.BottomPanelState());
        refreshActiveChildren();
    }
    public void SetPanelState(BottomPanelState state)
    {
        if (_state != state)
        {
            _state = state;
            handleStateChange();
        }
    }

    private void handleStateChange()
    {
        Transform[] panelStateTransforms = GetComponentsInChildren<Transform>(true);
        foreach (Transform panelStateTransform in panelStateTransforms) {
            IBottomPanelState panelState = panelStateTransform.GetComponent<IBottomPanelState>();
            if (panelStateTransform == this.transform || panelState == null)
            {
                continue;
            }
            if (panelStateTransform.parent == this.transform && panelState.PanelState() == _state){
                panelStateTransform.gameObject.SetActive(true);
            }
            else
            {
                panelStateTransform.gameObject.SetActive(false);
            }            
        }        
    }
    private void refreshActiveChildren()
    {
        IBottomPanelState[] activeComponents = GetComponentsInChildren<IBottomPanelState>();
        foreach(IBottomPanelState bottomPanelState in activeComponents)
        {
            bottomPanelState.SetGameAction(_gameAction);
        }
    }
}
