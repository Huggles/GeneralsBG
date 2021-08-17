using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class PlayerSelectionPanel : SingletonMonoBehaviour<PlayerSelectionPanel>
{
    PlayerSelectionPanelPayload _playerSelectionPanelPayload;


    private List<Button> _buttons
    {
        get { return new List<Button>(GetComponentsInChildren<Button>(true));  }
    }

    public void Show(PlayerSelectionPanelPayload playerSelectionPanelPayload)
    {
        _playerSelectionPanelPayload = playerSelectionPanelPayload;        
        gameObject.SetActive(true);
        Refresh();
    }
    public void Hide()
    {
        _playerSelectionPanelPayload = null;
        gameObject.SetActive(false);
    }

    private void Refresh()
    {
        foreach (Button button in _buttons)
        {
            button.gameObject.SetActive(true);
            int index = _buttons.IndexOf(button);
            if(index < _playerSelectionPanelPayload.Players.Count)
            {
                Player player = _playerSelectionPanelPayload.Players[index];
                button.GetComponentInChildren<TextMeshProUGUI>().text = player.playerName;
                button.GetComponent<Image>().color = player.playerColor;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => { _playerSelectionPanelPayload.Callback(player); });                
            }
            else
            {
                button.GetComponentInChildren<TextMeshProUGUI>().text = null;
                button.GetComponent<Image>().color = Color.white;
                button.gameObject.SetActive(false);
            }
        }
    }
}
