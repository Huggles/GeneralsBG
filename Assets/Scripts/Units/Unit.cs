using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract UnitType Type();


    private Player _owner;
    [SerializeField]
    public Player owner {
        get { return _owner; }
        set {
            _owner = value;
            if (_owner != null)
            {               
                handleChangeOwner();
            }            
        }
    }

    [SerializeField]
    public Country country;

    SpriteRenderer _spriteRenderer;
    SpriteRenderer spriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }
    
    void handleChangeOwner()
    {        
        spriteRenderer.color = owner.playerColor;
    }
}
