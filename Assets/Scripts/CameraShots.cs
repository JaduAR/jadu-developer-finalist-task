using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;




public class CameraShots : MonoBehaviour
{
    public Camera fullFigureCam;
    public Camera closeUpCam;
    public Camera bustCam;


    public enum CharacterScreen { preview = 0, skin, hair, na };
    public Camera[] screenCameras;
    public CinemachineVirtualCamera[] virtualCameras;
    [SerializeField] private CharacterScreen currentScreen = CharacterScreen.na;
    // [SerializeField] private Camera lastCamera = null;
    [SerializeField] private Camera currentCamera = null;
    

    [SerializeField] private GameObject tabGroup;
    [SerializeField] private int[] tabGroupYPositions; //-900, -356, 0
    [SerializeField] private GameObject topGroup; //200, 0, 0
    [SerializeField] private int[] topGroupYPositions;

    

    const float appearingDuration = .5f;
    const float cameraDuration = 1f;




    // Start is called before the first frame update
    void Start()
    {
        // if(characterMenu != null)
        //     characterMenu.SetActive(false);
        ResetCam();
        

        // currentCamera = fullFigureCam;
        // FullFigureCam();
        SetScreen(CharacterScreen.preview);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            // FullFigureCam();
            SetScreen(CharacterScreen.preview);
        }
        if (Input.GetKeyUp("2"))
        {
            // CloseUpCam();
            SetScreen(CharacterScreen.skin);
        }
        if (Input.GetKeyUp("3"))
        {
            // BustCam();
            SetScreen(CharacterScreen.hair);
        }
        if(Input.GetMouseButtonDown(0) && currentScreen == CharacterScreen.preview)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, Camera.main.transform.forward * 1000, Color.red, 10f);

            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.tag);

                if (hit.transform.tag == "avatar")
                {
                    // CloseUpCam();
                    SetScreen(CharacterScreen.skin);
                    tabGroup.GetComponent<TabGroup>().Reset();


                }
            }

        }
    }

    public void ResetCam()
    {
        // fullFigureCam.enabled = false;
        // closeUpCam.enabled = false;
        // bustCam.enabled = false;

        // fullFigureCam.gameObject.tag = "Untagged";
        // closeUpCam.gameObject.tag = "Untagged";
        // bustCam.gameObject.tag = "Untagged";

        // currentCamera = null;


        // currentScreen = CharacterScreen.preview;
        currentScreen = CharacterScreen.na;
        
        SetScreen(CharacterScreen.preview);

    }

    public void SetScreen(CharacterScreen characterScreen)
    {
        Debug.LogWarning("default: " + characterScreen);
        if(currentScreen == characterScreen) return;

        currentScreen = characterScreen;
Debug.LogWarning("default: " + characterScreen);
        switch(characterScreen)
        {
            case CharacterScreen.skin:
                virtualCameras[(int)CharacterScreen.skin].enabled = true;
                virtualCameras[(int)CharacterScreen.preview].enabled = false;
                break;
            case CharacterScreen.hair:
                virtualCameras[(int)CharacterScreen.hair].enabled = true;
                virtualCameras[(int)CharacterScreen.skin].enabled = false;
                break;
            case CharacterScreen.preview:
                virtualCameras[(int)CharacterScreen.preview].enabled = true;
                break;
        }

        tabGroup.GetComponent<RectTransform>().DOAnchorPosY(tabGroupYPositions[(int)characterScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
        topGroup.GetComponent<RectTransform>().DOAnchorPosY(topGroupYPositions[(int)characterScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);

    }


    // public void SetScreen(CharacterScreen characterScreen)
    // {
    //     Debug.Log($"SetScreen({(int)characterScreen})");

    //     Camera newCamera = screenCameras[(int)characterScreen];
    //     if(newCamera == currentCamera && currentCamera != null)
    //         return;
        
    //     Debug.Log($"ㄴ#1");
        
    //     if(currentCamera != null)
    //     {
    //         // Transform backupTransform = newCamera.transform;

    //         // newCamera.transform.position = currentCamera.transform.position;
    //         // newCamera.transform.rotation = currentCamera.transform.rotation;
    //         // newCamera.transform.localScale = currentCamera.transform.localScale;


    //         currentCamera.enabled = false;
    //         currentCamera.gameObject.tag = "Untagged";
    //         Debug.Log($"ㄴ#2");
    //         // currentCamera.transform.DOMove(newCamera.transform.position, cameraDuration);



    //         // newCamera.transform.DOMove(backupTransform.transform.position, cameraDuration);
    //         // newCamera.transform.DORotateQuaternion(backupTransform.transform.rotation, cameraDuration);
    //     }

    //     currentCamera = newCamera;
    //     currentCamera.enabled = true;
    //     currentCamera.gameObject.tag = "MainCamera";
        
        
    //     currentScreen = characterScreen;

    //     tabGroup.GetComponent<RectTransform>().DOAnchorPosY(tabGroupYPositions[(int)characterScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    //     topGroup.GetComponent<RectTransform>().DOAnchorPosY(topGroupYPositions[(int)characterScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    // }

    // public void CloseUpCam()
    // {
    //     // if(currentScreen == CharacterScreen.skin)
    //     //     return;

    //     currentScreen = CharacterScreen.skin;

    //     ResetCam();
    //     closeUpCam.enabled = true;
    //     closeUpCam.gameObject.tag = "MainCamera";

    //     //-900 to 0
    //     tabGroup.GetComponent<RectTransform>().DOAnchorPosY(tabGroupYPositions[(int)currentScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    //     topGroup.GetComponent<RectTransform>().DOAnchorPosY(topGroupYPositions[(int)currentScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    // }


    // public void FullFigureCam()
    // {
    //     // if(currentScreen == CharacterScreen.preview)
    //     //     return;
    //     if(currentCamera == lastCamera && lastCamera != null)
    //         return;

    //     if(lastCamera != null)
    //     {
    //         lastCamera.enabled = false;
    //         lastCamera.gameObject.tag = "Untagged";
    //         lastCamera = currentCamera;
    //     }
    //     currentCamera = fullFigureCam;
    //     currentCamera.enabled = true;
    //     currentCamera.gameObject.tag = "MainCamera";

    //     currentScreen = CharacterScreen.preview;

    //     // ResetCam();
    //     // fullFigureCam.enabled = true;
    //     // fullFigureCam.gameObject.tag = "MainCamera";

    //     tabGroup.GetComponent<RectTransform>().DOAnchorPosY(tabGroupYPositions[(int)currentScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    //     topGroup.GetComponent<RectTransform>().DOAnchorPosY(topGroupYPositions[(int)currentScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    // }

    // public void BustCam()
    // {
    //     // if(currentScreen == CharacterScreen.hair)
    //     //     return;

    //     currentScreen = CharacterScreen.hair;

    //     ResetCam();
    //     bustCam.enabled = true;
    //     bustCam.gameObject.tag = "MainCamera";

    //     tabGroup.GetComponent<RectTransform>().DOAnchorPosY(tabGroupYPositions[(int)currentScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    //     topGroup.GetComponent<RectTransform>().DOAnchorPosY(topGroupYPositions[(int)currentScreen], appearingDuration).SetEase(Ease.OutExpo).SetUpdate(true);
    // }

    public void OnClickDone()
    {
        // FullFigureCam();
        SetScreen(CharacterScreen.preview);
    }

    public void OnClickSkin()
    {
        SetScreen(CharacterScreen.skin);
    }

    public void OnClickHair()
    {
        SetScreen(CharacterScreen.hair);
    }

    // public void SwapCameras(Camera )
    // {
    //     // cameraA.gameObject.SetActive(true); // Activate CameraA
    //     // cameraB.gameObject.SetActive(false); // Deactivate CameraB

    //     // // Tween the cameras' positions
    //     // cameraA.transform.DOMove(cameraB.transform.position, 1f);
    //     // cameraB.transform.DOMove(cameraA.transform.position, 1f);
    // }

}
