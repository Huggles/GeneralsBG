using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonMonoBehaviour<SpawnManager>
{

    

    public Dictionary<UnitType, string> prefabPaths = new Dictionary<UnitType, string>
    {
        { UnitType.Army, LoadManager.PREFAB_ARMY },
        { UnitType.Navy, LoadManager.PREFAB_NAVY }
    };

    public GameObject LoadPrefab(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        return prefab;
    }
    public GameObject LoadUnit(UnitType unitType)
    {
        string prefabPath = prefabPaths[unitType];
        GameObject prefab = LoadPrefab(prefabPath);
        return prefab;
    }

    public T InstantiateUnit<T>(UnitType unitType) where T : Unit
    {
        return InstantiateUnit<T>(unitType, null);
    }
    public T InstantiateUnit<T>(UnitType unitType, Transform parent) where T : Unit
    {
        string prefabPath = prefabPaths[unitType];
        GameObject prefab = LoadPrefab(prefabPath);
        T instantiation = Instantiate(prefab, parent).GetComponent<T>();
        return instantiation;
    }
}
