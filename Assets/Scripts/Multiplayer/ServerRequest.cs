using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerRequest
{
    public string action;

    public ServerRequest(string action)
    {
        this.action = action;
    }


    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
}
