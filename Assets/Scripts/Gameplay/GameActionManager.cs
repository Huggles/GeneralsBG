using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;

using UnityEngine;



public class GameActionManager : SingletonMonoBehaviour<GameActionManager>
{


    List<GameAction> gameActionQueue;

    GameAction nextAction
    {
        get { 
            return gameActionQueue.Count > 0 ? gameActionQueue[0] : null; 
        }
    }


    private GameAction _currentAction;
    GameAction currentAction
    {
        get { return _currentAction; }
        set {
            _currentAction = value;
            GameManager.Instance.currentGameAction = value;
        }
    }

    public void AddAction(GameAction action)
    {
        if (action.ValidPlay())
        {
            gameActionQueue.Add(action);
        }
       
    }
    private void Start()
    {
        gameActionQueue = new List<GameAction>();        
    }
    private void FixedUpdate()
    {
        if(currentAction == null)
        {
            runNextAction();
        }
    }

    public void runNextAction()
    {
        if(nextAction != null)
        {
            currentAction = nextAction;
            gameActionQueue.RemoveAt(0);
            currentAction.gameActionFinished += actionFinished;
            currentAction.Start();
        }
    }
    public void actionFinished(object gameAction, EventArgs args)
    {
        currentAction = null;
        GameManager.Instance.NextTurn();
    }

}
