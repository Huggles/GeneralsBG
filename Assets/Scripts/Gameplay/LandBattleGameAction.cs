using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperMaxim.Messaging;

public class LandBattleGameAction : GameAction
{
    public LandBattleGameAction() : base(GameManager.Instance.CurrentPlayer) { }
    public LandBattleGameAction(Player triggeringPlayer) : base(triggeringPlayer) { }
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
        List<Player> players = new List<Player>(Target.CountryUnits.PlayerUnits.Keys);

        if (players.Count > 1)
        {
            PlayerSelectionPanel.Instance.Show(new PlayerSelectionPanelPayload(players, (Player player) => {
                PlayerSelectionPanel.Instance.Hide();
                KillUnitOfPlayer(player);
            }));
        }
        else
        {
            KillUnitOfPlayer(players[0]);
        }
    }
    private void KillUnitOfPlayer(Player player)
    {
        Target.CountryUnits.RemoveUnit(player);        
        FinishAction();
    }
    public override void OnCancelButtonClick()
    {

    }

    public override bool ValidPlay()
    {
        List<Country> ownedCountries = World.Instance.GetCountriesOwnedBy(Owner);
        foreach(Country country in ownedCountries)
        {
            if (country.IsSupplied() && country.HasEnemyNeighboor()) return true;
        }
        return false;
    }
    public override bool ValidateTarget(Country target)
    {
        List<Country> ownedCountries = World.Instance.GetSuppliedCountriesOwnedBy(Owner);
        foreach (Country ownedCountry in ownedCountries)
        {
            if (ownedCountry.IsCountryAdjacent(target)) return true;
        }
        return false;
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
