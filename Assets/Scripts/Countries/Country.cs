using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using SuperMaxim.Core;
using SuperMaxim.Messaging;

public abstract class Country : MonoBehaviour
{
    Color selectedColor = Color.green;
    Color deselectedColor = Color.white;

    SpriteRenderer spriteRenderer;

    CountryUnits _countryUnits;

    public virtual bool IsSupply()
    {
        return false;
    }
    public virtual bool IsSupplied()
    {
        return World.Instance.GetSuppliedCountriesOwnedByCurrentPlayer().Contains(this);
    }

    protected World World
    {
        get { 
            World w = GetComponentInParent<World>();
            return w;
        }
    }
    public CountryUnits CountryUnits
    {
        get
        {
            if (_countryUnits == null)
            {
                _countryUnits = GetComponentInChildren<CountryUnits>();
            }
            return _countryUnits;
        }
    }

    bool _selected;
    public void SetSelected(bool selected)
    {
        _selected = selected;
        spriteRenderer.color = _selected == true ? selectedColor : deselectedColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();      
    }

    public virtual List<Country> AdjacentCountries()
    {
        return new List<Country>();
    }
    public virtual bool IsCountryAdjacent(Country country)
    {
        return AdjacentCountries().Contains(country);
    }

    public virtual bool HasEnemyNeighboor()
    {
        foreach(Country country in AdjacentCountries())
        {
            if(country.CountryUnits.HasOtherPlayerUnit()) return true;
        }
        return false;        
    }


    public void OnMouseUpAsButton()
    {
        _selected = !_selected;
        Messenger.Default.Publish(new CountrySelectedEvent{ SelectedCountry =  this, Selected = _selected });
    }

    private void OnDrawGizmosSelected()
    {
        foreach(Country country in AdjacentCountries())
        {
            Gizmos.color = Color.red;            
            Gizmos.DrawLine(this.transform.position, country.transform.position);
            Gizmos.DrawSphere(country.transform.position, 0.25f);
        }
    }
    private void OnDrawGizmos()
    {
        if (IsSupplied())
        {
            Gizmos.color = GameManager.Instance.CurrentPlayer.playerColor;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }
    }
}
