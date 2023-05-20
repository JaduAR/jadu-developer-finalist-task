using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerClick : MonoBehaviour
{
    public UnityEvent OnClick;
    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
