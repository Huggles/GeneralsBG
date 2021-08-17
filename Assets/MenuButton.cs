using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using MLAPI;
using MLAPI.Transports;
using MLAPI.Transports.Tasks;

public class MenuButton : MonoBehaviour
{
    public void OnStartClick()
    {
        AsyncOperation sceneLoader =  SceneManager.LoadSceneAsync("GameScene");
    }

    public void OnMultiplayerClick()
    {
        MenuStateController.Instance.SetMenuState(MenuStateController.MenuStateEnum.MPGameList);
    }

    public void OnHostClick()
    {
        ServerController.Instance.CreateServer("Test Server 1");
        NetworkManager.Singleton.StartHost();
        /*
        NetworkManager.Singleton.StartHost();

        MenuStateController.Instance.SetMenuState(MenuStateController.MenuStateEnum.MPGameLobby);
        */
    }
    public void OnJoinClick()
    {
        SocketTasks socketTasks = NetworkManager.Singleton.StartClient();
    }
    public void OnRefreshClick()
    {
        
    }
}
