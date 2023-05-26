//Created 5/23/2023 by Maxfield Friedman
//Move and rotate camera between desired screen positions for different UI specifications according to Figma and when triggered by the user via PlayerUIManager.cs
//Some values are assigned arbitrarily for flow but system can be abstracted for larger scale use.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static bool isRunningCameraShift = false;
    public static int previousScreen = 1;

    [SerializeField] List<CameraInfo> camInfo = new List<CameraInfo>();
    [SerializeField] float cameraChangeSpeed = 1.0f;
    [SerializeField, Range(0.0075f, 0.1f)] float fovChangeSpeed = 0.25f;    

    void Awake()
    {
        PlayerUIManager.cameraShift += CallCameraMove;      
        this.transform.SetPositionAndRotation(camInfo[0].position, camInfo[0].rotation);
        Camera.main.fieldOfView = camInfo[0].fov;
    }
    
    //Player manager calls via delegate to move camera to new screen 1,2 or 3.
    void CallCameraMove(int cameraPosition)
    {
        //Duplicate calls is only going to cause problems here. Resets after Coroutine completion.
        if(!isRunningCameraShift)
            StartCoroutine(CameraMove(cameraPosition));
    }

    //Shift camera to new position and rotation values
    IEnumerator CameraMove(int cameraPosition)
    {
        isRunningCameraShift = true;
        CameraInfo goalValues = camInfo[cameraPosition - 1];

        float tValue = 0f;
        float startingFOV = Camera.main.fieldOfView;
        float tChange = (cameraPosition == 3 || previousScreen == 3) && cameraPosition != 1 ? fovChangeSpeed : 0.0075f; 

        Transform currentTransform = this.transform;
        Vector3 currPos = currentTransform.position;
        Quaternion currRot = currentTransform.rotation;

        //Simple Lerp functionality to move camera between current and goal transform and FOV.
        while (tValue < 1f)
        {
            Camera.main.fieldOfView = Mathf.Lerp(startingFOV, goalValues.fov, tValue);
            currentTransform.SetPositionAndRotation(Vector3.Lerp(currPos, goalValues.position, tValue), Quaternion.Lerp(currRot, goalValues.rotation, tValue));            
            tValue += tChange * cameraChangeSpeed * Time.deltaTime;             
            yield return new WaitForSeconds(0.01f);
        }

        Camera.main.fieldOfView = Mathf.Lerp(startingFOV, goalValues.fov, 1f);
        currentTransform.SetPositionAndRotation(Vector3.Lerp(currPos, goalValues.position, 1f), Quaternion.Lerp(currRot, goalValues.rotation, 1f));        

        previousScreen = cameraPosition;
        isRunningCameraShift = false;
    }

    void OnDestroy()
    {
        PlayerUIManager.cameraShift -= CallCameraMove;
    }
}
