using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MLAPI;
using MLAPI.Transports.UNET;

using SuperMaxim.Messaging;

public class ServerListItem : ListItem
{
    private TextMeshProUGUI ServerNameText;
    private TextMeshProUGUI IpAddressText;
    private ServerDTO ServerDTO;

    public void Awake()
    {
        List<Transform> children = new List<Transform>(GetComponentsInChildren<Transform>());
        ServerNameText = children.Find((child) => { return child.name == "ServerName"; }).GetComponent<TextMeshProUGUI>();
        IpAddressText = children.Find((child) => { return child.name == "IpAddress"; }).GetComponent<TextMeshProUGUI>();
    }

    public void Init(ServerDTO serverDTO)
    {
        this.ServerDTO = serverDTO;
        this.ServerNameText.text = serverDTO.serverName;
        this.IpAddressText.text = serverDTO.ipAddress;
    }

    public void JoinClicked()
    {
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ServerDTO.ipAddress;
        NetworkManager.Singleton.StartClient();

        JoinServerEvent joinServerEvent = new JoinServerEvent();
        joinServerEvent.ipAddress = ServerDTO.ipAddress;
        Messenger.Default.Publish(joinServerEvent);
    }


}
