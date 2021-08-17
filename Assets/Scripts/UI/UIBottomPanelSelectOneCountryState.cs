using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBottomPanelSelectOneCountryState : SingletonMonoBehaviour<UIBottomPanelSelectOneCountryState>, IBottomPanelState
{
    protected GameAction _gameAction;

    protected Button confirmButton;
    protected Button cancelButton;
    protected TextMeshProUGUI countryText1;

    public virtual UIBottomPanel.BottomPanelState PanelState()
    {
        return UIBottomPanel.BottomPanelState.SelectOneCountry;
    }
    protected virtual void OnEnable()
    {
        countryText1 = GameObject.Find("Country1Text").GetComponent<TextMeshProUGUI>();
        confirmButton = GameObject.Find("ConfirmButton").GetComponent<Button>();
        cancelButton = GameObject.Find("CancelButton").GetComponent<Button>();
    }
    protected virtual void OnDisable()
    {

    }

    public void SetGameAction(GameAction gameAction)
    {
        _gameAction = gameAction;
        Refresh();
    }

    public virtual void Refresh()
    {
        Country target = _gameAction.Target;
        countryText1.text = target ? target.name : null;

        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();

        confirmButton.onClick.AddListener(_gameAction.OnConfirmButtonClick);
        cancelButton.onClick.AddListener(_gameAction.OnCancelButtonClick);

    }

}
