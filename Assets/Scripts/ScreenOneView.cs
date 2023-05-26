using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenOneView : BaseView
{
    public UnityAction OnModelClicked;
    public UnityAction OnReturn;

    public void ModelClick()
    {
        OnModelClicked?.Invoke();
    }

    public void Return()
    {
        OnReturn?.Invoke();
    }
}
