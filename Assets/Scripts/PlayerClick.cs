using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerClick : MonoBehaviour
{
    public UnityEvent OnClick;
    private bool _canClick = true;
    
    private void OnMouseDown()
    {
        if(!_canClick)  return;
        OnClick?.Invoke();
    }
    
    public void SetCanClick(bool canClick)
    {
        _canClick = canClick;
    }
    
}
