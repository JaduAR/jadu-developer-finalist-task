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

        // Attach functions to view events
/*        owner.UI.ScreenThreeView.OnSkinButtonClicked += SkinButtonClicked;
        owner.UI.ScreenThreeView.OnDoneButtonClicked += DoneButtonClicked;

        // Show menu view
        owner.UI.ScreenThreeView.ShowView();*/
    }

    public override void DestroyState()
    {

        foreach (var view in owner.UI.ScreenThreeView)
        {
            view.HideView();
            view.OnSkinButtonClicked += SkinButtonClicked;
            view.OnDoneButtonClicked += DoneButtonClicked;
        }
        // Hide menu view
        /*        owner.UI.ScreenThreeView.HideView();

                // Detach functions from view events
                owner.UI.ScreenThreeView.OnSkinButtonClicked -= SkinButtonClicked;
                owner.UI.ScreenThreeView.OnDoneButtonClicked -= DoneButtonClicked;*/

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
