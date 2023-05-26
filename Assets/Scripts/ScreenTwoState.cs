using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTwoState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        foreach (var view in owner.UI.ScreenTwoView)
        {
            view.OnHairButtonClicked += HairButtonClicked;
            view.OnDoneButtonClicked += DoneButtonClicked;

            view.ShowView(); 
        }
    }

    public override void DestroyState()
    {

        foreach (var view in owner.UI.ScreenTwoView)
        {
            view.OnHairButtonClicked -= HairButtonClicked;
            view.OnDoneButtonClicked -= DoneButtonClicked;
            view.HideView();
        }

        base.DestroyState();
    }

    private void HairButtonClicked()
    {
        owner.ChangeState(new ScreenThreeState());
    }

    private void DoneButtonClicked()
    {
        owner.ChangeState(new ScreenOneState());
    }
}
