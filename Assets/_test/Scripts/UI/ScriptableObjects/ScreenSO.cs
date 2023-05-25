using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableOjbects/ScreenSetup", fileName = "ScreenObject")]
public class ScreenSO : ScriptableObject {

    public ScreenController.ScreenOrder screenOrder;
    public Screen screenScript;
    [Header("Camera")]
    public Vector3 cameraPosition;
    public Quaternion cameraRotation;
    public float lerpTotalTime;
    public AnimationCurve transitionCurve;
    public AnimationCurve rotationCurve;
    

    [Header("UI")]
    public bool showTopUI;
    public bool showBottomUI;

    public void SetupScript(Screen script) {
        screenScript = script;
    }
}
