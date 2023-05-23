using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenOneView : BaseView
{
    // Events to attach to.
    public UnityAction OnModelClicked;
    public UnityAction OnReturn;

    /// <summary>
    /// Method called by Start Button.
    /// </summary>
    public void ModelClick()
    {
        OnModelClicked?.Invoke();
    }

    public void Return()
    {
        OnReturn?.Invoke();
    }
}
