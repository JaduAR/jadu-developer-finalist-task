using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenTwoView : BaseView
{
    // Events to attach to.
    public UnityAction OnHairButtonClicked;
    public UnityAction OnDoneButtonClicked;

    public void HairButtonClick()
    {
        OnHairButtonClicked?.Invoke();
    }

    public void DoneButtonClick()
    {
        OnDoneButtonClicked?.Invoke();
    }
}
