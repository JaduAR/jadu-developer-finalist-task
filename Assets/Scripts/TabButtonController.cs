using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabButtonController : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    [Header("Component References")]
    [SerializeField] private GameObject _tabIndicator;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private Button _button;
    
    public Button Button => _button;

    protected void Start()
    {
        SetActiveState(false);
    }

    public void SetText(string text)
    {
        _buttonText.text = text;
    }
    
    public void SetActiveState(bool isActive)
    {
        _buttonText.color = isActive ? _activeColor : _inactiveColor;
        _tabIndicator.SetActive(isActive);
    }
}
