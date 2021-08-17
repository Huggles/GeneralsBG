using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


using SuperMaxim.Core;
using SuperMaxim.Messaging;


public class UIBottomPanelSelectTwoCountriesState : UIBottomPanelSelectOneCountryState, IBottomPanelState
{
    private TextMeshProUGUI countryText2;

    protected override void OnEnable()
    {
        base.OnEnable();
        countryText2 = GameObject.Find("Country2Text").GetComponent<TextMeshProUGUI>();
    }
    protected override void OnDisable()
    {
        
    }
    
    public override void Refresh()
    {
        base.Refresh();
        Country to = _gameAction.Target;
        countryText2.text = to ? to.name : null;
    }

    public override UIBottomPanel.BottomPanelState PanelState()
    {
        return UIBottomPanel.BottomPanelState.SelectTwoCountries;
    }

}
