using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOneState : BaseState
{
    public override void PrepareState()
    {
        base.PrepareState();

        // Attach functions to view events
        foreach(var view in owner.UI.ScreenOneView)
        {
            view.OnModelClicked += ModelClicked;
            view.Return();

        }
    }

    public override void DestroyState()
    {

        foreach (var view in owner.UI.ScreenOneView)
        {
            view.OnModelClicked -= ModelClicked;
        }

        base.DestroyState();
    }

    private void ModelClicked()
    {
        owner.ChangeState(new ScreenTwoState());
    }

}
