using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviourSingleton<ColorSelector>
{

    public ColorButton SelectedButton;


    public void ColorButtonClicked(ColorButton btn)
    {
        if(btn == SelectedButton)
        {
            //btn.CancelRunningTween();
            //btn.Grow();
            //SelectedButton = null;
        }
        else
        {
            btn.CancelRunningTween();
            btn.Shrink();
            if(SelectedButton != null)
            {
                SelectedButton.CancelRunningTween();
                SelectedButton.Grow();
            }
            SelectedButton = btn;
        }
    }
}
