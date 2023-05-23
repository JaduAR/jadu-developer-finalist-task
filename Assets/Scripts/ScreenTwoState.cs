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

/*        owner.UI.ScreenTwoView.OnHairButtonClicked += HairButtonClicked;
        owner.UI.ScreenTwoView.OnDoneButtonClicked += DoneButtonClicked;

        // Show menu view
        owner.UI.ScreenTwoView.ShowView();*/
    }

    public override void DestroyState()
    {

        foreach (var view in owner.UI.ScreenTwoView)
        {
            view.HideView();
            view.OnHairButtonClicked -= HairButtonClicked;
            view.OnDoneButtonClicked -= DoneButtonClicked;
        }

        // Hide menu view
        /*        owner.UI.ScreenTwoView.HideView();

                // Detach functions from view events
                owner.UI.ScreenTwoView.OnHairButtonClicked -= HairButtonClicked;
                owner.UI.ScreenTwoView.OnDoneButtonClicked -= DoneButtonClicked;*/

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
