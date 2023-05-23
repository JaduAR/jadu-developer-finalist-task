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

        //owner.UI.ScreenOneView.OnModelClicked += ModelClicked;

        // Show menu view
        //owner.UI.ScreenOneView.ShowView();
    }

    public override void DestroyState()
    {
        // Hide menu view
        //owner.UI.ScreenOneView.HideView();

        // Detach functions from view events
        //owner.UI.ScreenOneView.OnModelClicked -= ModelClicked;

        foreach (var view in owner.UI.ScreenOneView)
        {
            view.OnModelClicked -= ModelClicked;
        }

        base.DestroyState();
    }

    /// <summary>
    /// Function called when Start button is clicked in Menu view.
    /// </summary>
    private void ModelClicked()
    {
        owner.ChangeState(new ScreenTwoState());
    }
}
