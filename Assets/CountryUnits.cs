using System.Collections;
using System.Collections.Generic;
using SuperMaxim.Messaging;
using UnityEngine;

public class CountryUnits : MonoBehaviour
{
    [SerializeField]
    public SpawnLocations SpawnLocations;

    public Dictionary<Player, Unit> PlayerUnits = new Dictionary<Player, Unit>();

    private Country country
    {
        get { return GetComponentInParent<Country>(); }
    }

    public void AddUnit(Unit unit)
    {        
        unit.transform.parent = transform;

        SpawnLocation spawnLocation = SpawnLocations.getFirstAvailableSpawnLocation;
        unit.transform.position = spawnLocation.transform.position;
        spawnLocation.spawnedUnit = unit;
        PlayerUnits.Add(unit.owner, unit);
        Messenger.Default.Publish<UnitPlacedEvent>(new UnitPlacedEvent(country, unit.owner, unit));
    }
    public void RemoveUnit(Player player)
    {
        GameObject unit = PlayerUnits[player].gameObject;
        PlayerUnits.Remove(player);
        UnitType unitType = unit.GetComponent<Unit>().Type();
        if (unit) GameObject.Destroy(unit);
        Messenger.Default.Publish<UnitKilledEvent>(new UnitKilledEvent(country, player, unitType));
    }

    public bool CanPlaceUnit()
    {
        return CanPlaceUnit(GameManager.Instance.CurrentPlayer);
    }

    public bool CanPlaceUnit(Player player)
    {
        bool hasUnit = HasUnit(player);
        bool hasOtherPlayerUnit = HasOtherPlayerUnit(player);
        return !hasUnit && !hasOtherPlayerUnit;
    }

    public bool IsSupplied()
    {
        return IsSupplied(GameManager.Instance.CurrentPlayer);
    }
    public bool IsSupplied (Player player)
    {
        if (country.IsSupply()) return true;        
        return true;
    }

    public bool HasUnit()
    {
        return HasUnit(GameManager.Instance.CurrentPlayer);
    }
    public bool HasUnit(Player player)
    {
        return PlayerUnits.ContainsKey(player);
    }
    public bool HasOtherPlayerUnit()
    {
        return HasOtherPlayerUnit(GameManager.Instance.CurrentPlayer);
    }
    public bool HasOtherPlayerUnit(Player thisPlayer)
    {
        List<Player> playersOnCountry = new List<Player>(PlayerUnits.Keys);
        List<Player> otherPlayers = playersOnCountry.FindAll((Player player) => { return player != thisPlayer; });
        return otherPlayers.Count > 0;
    }
}
