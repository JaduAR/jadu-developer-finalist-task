using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelector : MonoBehaviourSingleton<HairSelector>
{
    public HairButton SelectedButton;


    public void ButtonClicked(HairButton btn)
    {
        if (btn == SelectedButton)
        {

        }
        else
        {
            btn.CancelRunningTween();
            btn.Select();
            if (SelectedButton != null)
            {
                SelectedButton.CancelRunningTween();
                SelectedButton.Deselect();
            }
            SelectedButton = btn;
        }
    }
}
