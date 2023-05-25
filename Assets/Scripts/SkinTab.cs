using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinTab : Tab
{
    
    [SerializeField] private GameObject _colorSelectorPrefab;
    [SerializeField] private List<SkinColor> _skinColors = new List<SkinColor>();

    protected void Awake()
    {
        //Create color buttons for grid container.
        foreach (var skinColor in _skinColors)
        {
           var colorButton = Instantiate(_colorSelectorPrefab, tabContent.transform).GetComponent<ColorSelector>();
           colorButton.SetColor(skinColor.Color);
           colorButton.SetOwner(this);
        }
    }
}
