using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperMaxim.Messaging;


public class PlaceArmyGameAction : GameAction
{

    public PlaceArmyGameAction() : base(GameManager.Instance.CurrentPlayer) { }
    public PlaceArmyGameAction(Player triggeringPlayer) : base(triggeringPlayer) { }

    protected override void ExecuteAction()
    {
        UIBottomPanel.Instance.SetGameAction(this);
        Messenger.Default.Subscribe<CountrySelectedEvent>(HandleOnCountrySelected);
    }

    public override void OnCountrySelected(CountrySelectedEvent countrySelectedEvent)
    {        
        UIBottomPanel.Instance.SetGameAction(this);        
    }

    public override void OnConfirmButtonClick()
    {
        AddUnit();
        FinishAction();
    }

    private void AddUnit()
    {
        Unit army = SpawnManager.Instance.InstantiateUnit<Army>(UnitType.Army);
        army.owner = Owner;
        army.name = "Army " + Owner.playerName;
        Target.CountryUnits.AddUnit(army);
    }
    public override void OnCancelButtonClick()
    {

    }

    /**
     * Is this card/action a valid play in the current state?
     */
    public override bool ValidPlay()
    {
        foreach(Country country in World.Instance.Countries)
        {
            if (country.CountryUnits.CanPlaceUnit(GameManager.Instance.CurrentPlayer))
            {
                return true;
            }
        }
        return false;
    }

    /**
     * Is the clicked country a valid target?
     */
    public override bool ValidateTarget(Country country)
    {
        return country.CountryUnits.CanPlaceUnit(Owner);
    }

    protected override void FinishAction()
    {
        Messenger.Default.Unsubscribe<CountrySelectedEvent>(HandleOnCountrySelected);
        base.FinishAction();
    }
    public override UIBottomPanel.BottomPanelState BottomPanelState()
    {
        return UIBottomPanel.BottomPanelState.SelectOneCountry;
    }
}
