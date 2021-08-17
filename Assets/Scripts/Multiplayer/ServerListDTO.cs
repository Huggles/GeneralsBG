using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ServerListDTO : ServerResponse
{
    public List<ServerDTO> servers;
}
