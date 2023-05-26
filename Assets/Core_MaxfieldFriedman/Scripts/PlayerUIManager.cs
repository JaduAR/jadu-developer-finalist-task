//Created 5/22/2023 by Maxfield Friedman
//Handling system changes to account for screens 1-3, Camera events and UI firing.
//Essentially the main hub for all control in this scene that involves user interaction.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    public delegate void CameraActionShift(int position);
    public static CameraActionShift cameraShift;

    public static bool isUIActive = false;

    [SerializeField] GameObject UIPanel;
    [SerializeField] RectTransform mainContainerTransform;
    [SerializeField] RectTransform doneButtonTransform;
    [SerializeField] List<float> mainCanvasPositions = new List<float>();

    bool isUIChanging = false;

    //Register user touch or click on character to verify selection and change to UI screen should occur
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isUIActive)
        {
            int layerMask = 1 << 6;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, 15.0f, layerMask))
                ChangeUserUIPositioning(2, true);
        }   
    }
    //Dependent on button presses or interactions call the desired UI screen and transition
    #region UITransitionFunctions
    public void UserUIDone()
    {
        ChangeUserUIPositioning(1);
    }

    public void UserUIHair()
    {
        ChangeUserUIPositioning(3);
    }

    public void UserUISkin()
    {
        ChangeUserUIPositioning(2);
    }
    #endregion

    //Logic for camera and UI movement dependent on screen selection
    public void ChangeUserUIPositioning(int screenSelection, bool fromClick = false)
    {        
        isUIActive = screenSelection >= 2;

        if(!isUIChanging && !CameraControl.isRunningCameraShift)
            StartCoroutine(ChangeUIPos(screenSelection, fromClick));
        
        cameraShift?.Invoke(screenSelection);
    }

    //Move UI up from button of screen and scale the done button to be visible from the user
    //The opposite occurs when closing the UI menu
    IEnumerator ChangeUIPos(int screenSelection, bool fromClick = false)
    {
        if (fromClick)
            yield return new WaitForSeconds(1.5f);

        isUIChanging = true;
        float tValue = 0f;

        Vector3 mainStart = mainContainerTransform.localPosition;
        Vector3 mainGoal = new Vector3(mainStart.x, mainCanvasPositions[screenSelection - 1], mainStart.z);

        Vector3 doneStart = doneButtonTransform.localScale;        
        Vector3 doneGoal = Vector3.zero;

        if (screenSelection != 1) { doneGoal = new Vector3(1, 1, 1); }     

        while (tValue < 1f)
        {
            mainContainerTransform.localPosition = Vector3.Lerp(mainStart, mainGoal, tValue);
            doneButtonTransform.localScale = Vector3.Lerp(doneStart, doneGoal, tValue);
            tValue += 0.95f * Time.deltaTime;
            yield return new WaitForSeconds(0.000025f);
        }

        mainContainerTransform.localPosition = Vector3.Lerp(mainStart, mainGoal, 1f);
        doneButtonTransform.localScale = Vector3.Lerp(doneStart, doneGoal, 1f);

        isUIChanging = false;

    }
}
