using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenThreeView : BaseView
{
    // Events to attach to.
    public UnityAction OnSkinButtonClicked;
    public UnityAction OnDoneButtonClicked;

    /// <summary>
    /// Method called by Start Button.
    /// </summary>
    public void SkinButtonClick()
    {
        OnSkinButtonClicked?.Invoke();
    }

    public void DoneButtonClick()
    {
        OnDoneButtonClicked?.Invoke();
    }
}
