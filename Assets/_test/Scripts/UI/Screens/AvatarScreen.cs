using UnityEngine;

public class AvatarScreen : Screen {
    public override bool FinishedTransition { set; get; }

    public override void EnterScreen() {
        LeftScreen = false;
        Debug.Log("AvatarScreen.EnterScreen()");

        AvatarClickDetection.OnAvatarClick += ScreenController.Instance.ScreenForward;
        FinishedTransition = true;
        Debug.Log($"AvatarScreen.FinishedTransition {FinishedTransition}");

    }


    public override bool LeftScreen { set; get; }

    public override void LeaveScreen() {
        LeftScreen = false;
        Debug.Log("AvatarScreen.LeaveScreen()");

        AvatarClickDetection.OnAvatarClick -= ScreenController.Instance.ScreenForward;
        LeftScreen = true;
    }
}
