using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public abstract class GameAction
{
    public Player Owner;
    public Country Target;


    public GameAction(Player triggeringPlayer)
    {
        Owner = triggeringPlayer;
    }

    public event EventHandler gameActionFinished;    

    public void Start()
    {
        ExecuteAction();
    }
    public virtual UIBottomPanel.BottomPanelState BottomPanelState()
    {
        return UIBottomPanel.BottomPanelState.Default;
    }
    public void HandleOnCountrySelected(CountrySelectedEvent countrySelectedEvent)
    {
        if (ValidateTarget(countrySelectedEvent.SelectedCountry))
        {
            if (Target == null && countrySelectedEvent.Selected)
            {
                Target = countrySelectedEvent.SelectedCountry;
            }
            else if (Target == countrySelectedEvent.SelectedCountry)
            {
                Target = null;
            }
            OnCountrySelected(countrySelectedEvent);
        }
    }
    public abstract void OnCountrySelected(CountrySelectedEvent countrySelectedEvent);

    public abstract void OnConfirmButtonClick();
    public abstract void OnCancelButtonClick();

    public abstract bool ValidPlay();
    public virtual bool ValidateTarget(Country country)
    {
        return true;
    }

    protected abstract void ExecuteAction();
    protected virtual void FinishAction()
    {
        UIBottomPanel.Instance.SetPanelState(UIBottomPanel.BottomPanelState.Default);
        gameActionFinished(this, null);
    }
}
