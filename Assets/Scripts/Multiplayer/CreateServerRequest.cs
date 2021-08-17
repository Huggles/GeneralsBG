using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateServerRequest : ServerRequest
{
    public string serverName;

    public CreateServerRequest(string serverName) : base("CreateServer")
    {
        this.serverName = serverName;
    }
}
