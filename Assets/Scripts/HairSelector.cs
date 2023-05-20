using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HairSelector : Selector
{
    [Header("Component References")]
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Image _hairImage;
    [SerializeField] private TextMeshProUGUI _hairText;
    [Header("Button Sprites")]
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _unselectedSprite;
    [Header("Properties")]
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    protected void Start()
    {
        _buttonImage.sprite = _unselectedSprite;
        _hairText.color = _inactiveColor;
    }

    public void SetName(string name)
    {
        _hairText.text = name;
    }
    
    public void SetHairSprite(Sprite sprite)
    {
        _hairImage.sprite = sprite;
    }
    
    public override void Select()
    {
        _buttonImage.sprite = _selectedSprite;
        _hairText.color = _activeColor;
        owner.SetActiveItem(this);
    }

    public override void Deselect()
    {
        _hairText.color = _inactiveColor;
        _buttonImage.sprite = _unselectedSprite;
    }
}
