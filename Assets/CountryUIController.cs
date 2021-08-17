using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryUIController : MonoBehaviour
{
    public void OnMouseUpAsButton()
    {
        GetComponentInParent<Country>().OnMouseUpAsButton();
    }
}
