using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenThreeState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();


        foreach (var view in owner.UI.ScreenThreeView)
        {
            view.OnSkinButtonClicked += SkinButtonClicked;
            view.OnDoneButtonClicked += DoneButtonClicked;

            view.ShowView();
        }
    }

    public override void DestroyState()
    {

        foreach (var view in owner.UI.ScreenThreeView)
        {
            view.OnSkinButtonClicked += SkinButtonClicked;
            view.OnDoneButtonClicked += DoneButtonClicked;
            view.HideView();
        }

        base.DestroyState();
    }

    private void SkinButtonClicked()
    {
        owner.ChangeState(new ScreenTwoState());
    }

    private void DoneButtonClicked()
    {
        owner.ChangeState(new ScreenOneState());
    }
}
