using UnityEngine;

[System.Serializable]
public class HairSelectionScreen : Screen
{

    public override bool FinishedTransition { set; get; }

    public override void EnterScreen() {
        FinishedTransition = false;
        Debug.Log("HairSelectionScreen.EnterScreen()");

        //Do HairTabUpAnim

        FinishedTransition = true;
    }


    public override bool LeftScreen { set; get; }

    public override void LeaveScreen() {
        LeftScreen = false;
        Debug.Log("HairSelectionScreen.LeaveScreen()");

        LeftScreen = true;
    }
}
