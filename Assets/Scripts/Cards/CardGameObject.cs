using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardGameObject : MonoBehaviour
{
    private Card _cardModel;

    TextMeshPro _cardText;
    TextMeshPro cardText
    {
        get
        {
            if (_cardText == null)
            {
                _cardText = GetComponentInChildren<TextMeshPro>();
            }
            return _cardText;
        }
    }

    public Card cardModel {
        get { return _cardModel; }
        set { _cardModel = value; }
    }

    private void initCard()
    {
        _cardText.text = _cardModel.cardText;
    }
}
