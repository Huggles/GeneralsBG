using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using MLAPI;



public class MPGameList : MonoBehaviour
{  
    private ListView listView;

    public void Awake()
    {
        listView = GetComponentInChildren<ListView>(true);
    }

    // Start is called before the first frame update
    void Start()
    {        
        ServerController.Instance.OnGetServerList += (serverListDTO) =>
        {
            UnityMainThreadDispatcher.Instance().Enqueue(ThisWillBeExecutedOnTheMainThread(serverListDTO));
        };
    }

    private void OnApplicationQuit()
    {
        ServerController.Instance.Disconnect();
    }

    public IEnumerator ThisWillBeExecutedOnTheMainThread(ServerListDTO serverListDTO)
    {
        foreach (ServerDTO serverDTO in serverListDTO.servers)
        {
            ServerListItem listItem = Instantiate(LoadManager.Instance.GetPrefab(LoadManager.PREFAB_LIST_ITEM)).GetComponent<ServerListItem>();
            listItem.Init(serverDTO);            
            listView.AddItem(listItem);
        }
        yield return null;
    }

    
}
