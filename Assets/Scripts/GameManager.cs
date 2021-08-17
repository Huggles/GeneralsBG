using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SuperMaxim.Core;
using SuperMaxim.Messaging;

public class GameManager : SingletonMonoBehaviour<GameManager>
{    
    private int _turnNumber = 1;
    public int TurnNumber
    {
        get { return _turnNumber;  }
        set {
            _turnNumber = value;            
            Messenger.Default.Publish(new NextTurnEvent { TurnNumber = _turnNumber, Player = CurrentPlayer });
        }
    }

    public Player CurrentPlayer
    {
        get { return Players[((TurnNumber-1) % Players.Count)];  }
    }

    [SerializeField]
    public Country selectedCountry;

    [SerializeField]
    public GameAction currentGameAction;

    public List<Player> Players
    {
        get { 
            return new List<Player>(playerContainer.GetComponentsInChildren<Player>());  
        }
    }

    private GameObject _playerContainer;
    public GameObject playerContainer
    {
        get { 
            if(_playerContainer == null)
            {
                _playerContainer = GameObject.Find("PlayerContainer");
            }
            return _playerContainer;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }


    void InitGame()
    {        
        InitPlayers();
        InitMap();
        InitEventListeners();
        InitTestUnits();
        InitUI();
        StartFirstRound();
    }


    void InitMap()
    {
        GameObject worldGameObject = SpawnManager.Instance.LoadPrefab(LoadManager.PREFAB_WORLD);
        GameObject world = Instantiate(worldGameObject);
        world.name = "World";
    }
    void InitPlayers()
    {
        GameObject playerGameObject = SpawnManager.Instance.LoadPrefab(LoadManager.PREFAB_PLAYER);

        string player1Name = "Hugo";
        Player player1 = Instantiate(playerGameObject, playerContainer.transform).GetComponent<Player>();
        player1.name = player1Name;
        player1.playerName = player1Name;
        player1.playerColor = new Color(255, 0, 0);

        string player2Name = "Jasper";
        Player player2 = Instantiate(playerGameObject, playerContainer.transform).GetComponent<Player>();
        player2.name = player2Name;
        player2.playerName = player2Name;
        player2.playerColor = new Color(0, 255, 0);

        string player3Name = "Verm";
        Player player3 = Instantiate(playerGameObject, playerContainer.transform).GetComponent<Player>();
        player3.name = player3Name;
        player3.playerName = player3Name;
        player3.playerColor = new Color(0, 0, 255);

        /*
        string player4Name = "Floris";
        Player player4 = Instantiate(playerGameObject, playerContainer.transform).GetComponent<Player>();
        player4.name = player4Name;
        player4.playerName = player4Name;
        player4.playerColor = new Color(255, 255, 0);

        string player5Name = "Lida";
        Player player5 = Instantiate(playerGameObject, playerContainer.transform).GetComponent<Player>();
        player5.name = player5Name;
        player5.playerName = player5Name;
        player5.playerColor = new Color(0, 255, 255);

        string player6Name = "Jorrit";
        Player player6 = Instantiate(playerGameObject, playerContainer.transform).GetComponent<Player>();
        player6.name = player6Name;
        player6.playerName = player6Name;
        player6.playerColor = new Color(255, 0, 255);
        */
    }

    void InitEventListeners()
    {
        Messenger.Default.Subscribe((CountrySelectedEvent payload) => { selectedCountry = payload.Selected ? payload.SelectedCountry : null; });
    }

    void InitTestUnits()
    {
        Player player1 = GameManager.Instance.playerContainer.GetComponentsInChildren<Player>()[0];
        Player player2 = GameManager.Instance.playerContainer.GetComponentsInChildren<Player>()[1];
        Player player3 = GameManager.Instance.playerContainer.GetComponentsInChildren<Player>()[2];

        Unit unit = SpawnManager.Instance.InstantiateUnit<Army>(UnitType.Army);
        unit.owner = player1;
        unit.name = "Army " + player1.playerName;
        World.Instance.GetCountry(CountryName.UnitedKingdom).CountryUnits.AddUnit(unit);

        Unit unit1 = SpawnManager.Instance.InstantiateUnit<Army>(UnitType.Army);
        unit1.owner = player2;
        unit1.name = "Army " + player2.playerName;
        World.Instance.GetCountry(CountryName.Germany).CountryUnits.AddUnit(unit1);


        Unit unit3 = SpawnManager.Instance.InstantiateUnit<Army>(UnitType.Army);
        unit3.owner = player3;
        unit3.name = "Army " + player3.playerName;
        World.Instance.GetCountry(CountryName.Italy).CountryUnits.AddUnit(unit3);
    }

    public void InitUI()
    {
        UIBottomPanel.Instance.SetPanelState(UIBottomPanel.BottomPanelState.Default);
    }
    public void StartFirstRound()   
    {
        TurnNumber = 1;
    }

    public void NextTurn()
    {
        TurnNumber += 1;
    }
}
