using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorKnob : MonoBehaviour, IPointerClickHandler
{
    public Action<ColorKnob> OnKnobClicked;

    public int Index;
    public bool IsSelected = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnKnobClicked(this);
    }
}
