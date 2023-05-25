using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinColorScreen : Screen {
    public override bool FinishedTransition { set; get; }

    public override void EnterScreen() {
        FinishedTransition = false;
        Debug.Log("HairColorScreen.EnterScreen()");

        //Do HairTabUpAnim

        FinishedTransition = true;
    }


    public override bool LeftScreen { set; get; }

    public override void LeaveScreen() {
        LeftScreen = false;
        Debug.Log("HairColorScreen.LeaveScreen()");

        LeftScreen = true;
    }
}
