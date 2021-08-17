using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateController : SingletonMonoBehaviour<MenuStateController>
{
    public enum MenuStateEnum
    {
        Main,
        MPGameList,
        MPGameLobby
    }


    private Dictionary<MenuStateEnum, MenuState> MenuStates;
    public void Awake()
    {
        MenuStates = new Dictionary<MenuStateEnum, MenuState>();
        MenuState[] menuStates = GetComponentsInChildren<MenuState>(true);
        foreach(MenuState menuState in menuStates)
        {
            MenuStates[GetMenuStateEnum(menuState.gameObject.name)] = menuState;
            menuState.gameObject.SetActive(false);
        }
    }
    public void Start()
    {
        SetMenuState(MenuStateEnum.Main);
    }

    private MenuStateEnum GetMenuStateEnum(string menuState)
    {
        return (MenuStateEnum)Enum.Parse(typeof(MenuStateEnum), menuState);
    }

    public void SetMenuState(MenuStateEnum menuState)
    {
        DeactivateMenuStates();
        MenuStates[menuState].gameObject.SetActive(true);
    }

    private void DeactivateMenuStates()
    {
        MenuState[] menuStates = GetComponentsInChildren<MenuState>();
        foreach (MenuState menuState in menuStates)
        {
            menuState.gameObject.SetActive(false);
        }
    }
}
