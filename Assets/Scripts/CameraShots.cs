using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;




public class CameraShots : MonoBehaviour
{
    public enum CharacterScreen { preview = 0, skin, hair, na };
    public CinemachineVirtualCamera[] virtualCameras;
    [SerializeField] private CharacterScreen currentScreen = CharacterScreen.na;
    [SerializeField] private GameObject tabGroup;
    [SerializeField] private int[] tabGroupYPositions;
    [SerializeField] private GameObject topGroup;
    [SerializeField] private int[] topGroupYPositions;

    const float appearingDuration = .5f;

    void Start()
    {
        ResetCam();
        SetScreen(CharacterScreen.preview);
    }

    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            SetScreen(CharacterScreen.preview);
        }
        if (Input.GetKeyUp("2"))
        {
            SetScreen(CharacterScreen.skin);
        }
        if (Input.GetKeyUp("3"))
        {
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
        currentScreen = CharacterScreen.na;
        SetScreen(CharacterScreen.preview);
    }

    public void SetScreen(CharacterScreen characterScreen)
    {
        if(currentScreen == characterScreen) return;

        currentScreen = characterScreen;
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

    public void OnClickDone()
    {
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
}
