using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinTab : Tab
{
    
    [SerializeField] private List<SkinColor> _skinColors = new List<SkinColor>();
    [SerializeField] private GameObject _colorSelectorPrefab;

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

    //Called on by button click event in ColorSelector.cs
    public override void SetActiveItem(Selector selector)
    {
        if(selector != null && selector != activeItem)
            activeItem?.Deselect();
        activeItem = selector;
    }

    public override void Select()
    {
        OnTabSelected?.Invoke();
        tabContent.SetActive(true);
    }
    
    public override void Deselect()
    {
        tabContent.SetActive(false);
    }
}
