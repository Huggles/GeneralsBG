using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using WebSocketSharp;

public class ServerController
{

    public string serverIp = "192.168.2.48";
    public string serverPort = "1234";

    private static ServerController _instance;

    public static ServerController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ServerController();
            }
            return _instance;
        }
    }
    public void Disconnect()
    {        
        ws.Close();
        _instance = null;
    }

    public delegate void GetServersResponseDelegate(ServerListDTO serverListDTO);
    public GetServersResponseDelegate OnGetServerList;



    private WebSocket ws;
    public ServerController()
    {
        InitConnection();
    }

    public void InitConnection()
    {
        try
        {
            ws = new WebSocket("ws://"+ serverIp + ":"+serverPort);
            ws.ConnectAsync();
            ws.OnMessage += HandleIncomingMessage;
            ws.OnOpen += (sender, e) =>
            {
                Debug.Log("Connection Established");
                GetServerList();
            };
            ws.OnError += (sender, e) => {
                Debug.Log(e.Message);
            };

        }
        catch (Exception ex)
        {
            Debug.Log("Could not connect to socket" + ex.Message);
            ws = null;
        }
    }
    public void HandleIncomingMessage(object sender, MessageEventArgs e)
    {
        try
        {
            ServerResponse serverResponse = JsonUtility.FromJson<ServerResponse>(e.Data);
            if (serverResponse != null)
            {
                if (serverResponse.type == "GetServers")
                {
                    ServerListDTO serverListDTO = JsonUtility.FromJson<ServerListDTO>(serverResponse.data);
                    OnGetServerList(serverListDTO);
                }
            }
            else
            {
                Debug.Log("Could not parse response: " + e.Data);
            }
        }
        catch(Exception ex)
        {
            Debug.LogError(ex.Message);
            Debug.LogError(ex.StackTrace);

        }

         
    }

    public void GetServerList()
    {
        if (ws != null)
        {
            GetServersRequest serverRequest = new GetServersRequest();
            ws.Send(serverRequest.ToString());
        }
    }
    public void CreateServer(string serverName)
    {
        if (ws != null)
        {
            CreateServerRequest serverRequest = new CreateServerRequest(serverName);
            ws.Send(serverRequest.ToString());
        }
    }

}
