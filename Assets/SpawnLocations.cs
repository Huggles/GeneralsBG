using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations : MonoBehaviour
{

    [SerializeField]
    public CountryUnits countryUnits;

    public SpawnLocation[] spawnLocations
    {
        get { return GetComponentsInChildren<SpawnLocation>(); }
    }
    public SpawnLocation getFirstAvailableSpawnLocation
    {
        get
        {
            return availableSpawnLocations[0];
        }
    }
    public SpawnLocation[] availableSpawnLocations
    {
        get {
            SpawnLocation[] allLocations = spawnLocations;
            List<SpawnLocation> availableLocations = new List<SpawnLocation>();            
            foreach(SpawnLocation spawnLocation in allLocations)
            {
                if (spawnLocation.spawnedUnit == null) availableLocations.Add(spawnLocation);
            }
            return availableLocations.ToArray();
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach (SpawnLocation spawnLocation in spawnLocations)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(spawnLocation.transform.position, 0.1f);
        }
        
    }
}
