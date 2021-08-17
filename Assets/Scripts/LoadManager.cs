using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : SingletonMonoBehaviour<LoadManager>
{
    /* List Items */
    public const string PREFAB_LIST_ITEM = "Prefabs/ListItem";

    /* Game Elements */
    public const string PREFAB_PLAYER = "Prefabs/Player";
    public const string PREFAB_WORLD = "Prefabs/World";
    public const string PREFAB_ARMY = "Prefabs/Army";
    public const string PREFAB_NAVY = "Prefabs/Navy";


    Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>
    {
        { PREFAB_LIST_ITEM , null },
        { PREFAB_PLAYER , null },
        { PREFAB_WORLD , null },
        { PREFAB_ARMY , null },
        { PREFAB_NAVY , null }
    };

    public void Start()
    {
        LoadResources();
    }
    public void LoadResources()
    {
        LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        Dictionary<string, GameObject> loadedPrefabs = new Dictionary<string, GameObject>();
        foreach (string path in prefabs.Keys)
        {
            GameObject prefab = Resources.Load<GameObject>(PREFAB_LIST_ITEM);
            loadedPrefabs[path] = prefab;
        }
        prefabs = loadedPrefabs;
    }

    public GameObject GetPrefab(string prefabPath)
    {
        return prefabs[prefabPath];
    }
}
