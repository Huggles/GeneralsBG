using System;
using System.Collections;
using System.Collections.Generic;

using SuperMaxim.Messaging;

using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

using UnityEngine;


public class World : SingletonNetworkBehaviour<World>
{


    private Dictionary<CountryName, Country> _CountriesMap;
    private Dictionary<CountryName, Country> CountriesMap
    {
        get
        {
            if (_CountriesMap == null) {

                _CountriesMap = new Dictionary<CountryName, Country>();
                Countries = new List<Country>(GetComponentsInChildren<Country>()); 
                foreach (Country country in Countries) 
                { 
                    try
                    {
                        CountryName countryName = (CountryName)Enum.Parse(typeof(CountryName), country.name);
                        _CountriesMap.Add(countryName, country);
                    }
                    catch(Exception ex)
                    {
                        Debug.LogError(country.name + " not found during init."); 
                        throw ex;
                    }
                    
                }
            }            
            return _CountriesMap; 
        }
    }
    public List<Country> Countries = new List<Country>();


    private Dictionary<Player, List<Country>> _SuppliedPlayerCountriesMap = new Dictionary<Player, List<Country>>();

    public void Awake()
    {
        Messenger.Default.Subscribe<UnitPlacedEvent>(OnUnitPlacedEvent);
        Messenger.Default.Subscribe<UnitKilledEvent>(OnUnitKilledEvent);
    }

    public Country GetCountry(CountryName countryName)
    {
        try
        {
            return CountriesMap[countryName];  
        }
        catch(Exception ex)
        {
            Debug.LogError(countryName + " not found.");
            throw ex;
        }        
    }

    /**
     * Get the supplied countries for player
     */
    public List<Country> GetSuppliedCountriesOwnedByCurrentPlayer()
    {
        return _SuppliedPlayerCountriesMap[GameManager.Instance.CurrentPlayer];
    }
    private List<Country> CalculateSuppliedCountriesOwnedBy(Player player)
    {
        List<Country> allSuppliedCountriesForPlayer = new List<Country>();        
        List<Country> countriesWithSupplyForPlayer = GetCountriesWithSupply().FindAll((Country country) => { return country.CountryUnits.HasUnit(player); });        

        foreach (Country countryWithSupplyForPlayer in countriesWithSupplyForPlayer)
        {
            allSuppliedCountriesForPlayer = calculateSuppliedCountriesIteration(player, allSuppliedCountriesForPlayer, countryWithSupplyForPlayer);            
        }           
        return allSuppliedCountriesForPlayer;
    }
    private List<Country> calculateSuppliedCountriesIteration(Player player, List<Country> supplied, Country countryToCheck)
    {
        if (countryToCheck.CountryUnits.HasUnit(player))
        {
            supplied.Add(countryToCheck);
            foreach(Country country in countryToCheck.AdjacentCountries())
            {
                if(!supplied.Contains(country)) supplied = calculateSuppliedCountriesIteration(player, supplied, country);
            }
        }
        return supplied;
    }

    /**
     * Gets the countries which are marked as Supply
     */
    public List<Country> GetCountriesWithSupply()
    {
        return Countries.FindAll((Country country) => { return country.IsSupply(); });
    }

    /**
     * Get countries owned by player
     */
    public List<Country> GetCountriesOwnedByCurrentPlayer()
    {
        return GetCountriesOwnedBy(GameManager.Instance.CurrentPlayer);
    }

    public List<Country> GetCountriesOwnedBy(Player player)
    {
        return Countries.FindAll((Country country) => { return country.CountryUnits.HasUnit(player); });        
    }
    public List<Country> GetSuppliedCountriesOwnedBy(Player player)
    {
        return GetCountriesOwnedBy(player).FindAll((Country country) => { return country.IsSupplied(); });
    }

    /**
     * Calculates the boundaries of the world based on this game object.
     */
    public Bounds WorldBoundaries()
    {
        Bounds bounds = new Bounds(this.transform.position, Vector3.zero);

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds;
    }

    private void CalculatePlayerCountrySupply()
    {
        foreach(Player player in GameManager.Instance.Players)
        {
            _SuppliedPlayerCountriesMap[player] = CalculateSuppliedCountriesOwnedBy(player);
        }
    }

    public void OnUnitPlacedEvent(UnitPlacedEvent unitPlacedEvent)
    {
        CalculatePlayerCountrySupply();
    }

    public void OnUnitKilledEvent(UnitKilledEvent unitKilledEvent)
    {
        CalculatePlayerCountrySupply();
    }
        
}
