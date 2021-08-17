using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class NetworkClient : NetworkBehaviour
{
    NetworkObject networkObject;
    public void Start()
    {
        networkObject = GetComponent<NetworkObject>();
        name = networkObject.NetworkObjectId.ToString();
    }
}
