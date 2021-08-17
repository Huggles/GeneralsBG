using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountrySelectedEvent : PubSubEvent
{
    public Country SelectedCountry;
    public bool Selected;
}
