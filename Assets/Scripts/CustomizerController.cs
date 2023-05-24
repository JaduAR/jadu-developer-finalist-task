using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerController : MonoBehaviour
{
    [SerializeField] private GameObject avatarObj;
    [SerializeField] private GameObject finishCustomizingButton;

    [SerializeField] private CustomizerCamera customCam;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator skinControllerAnimator;

    private bool IsCloseUp = false;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            TrySwitchToCloseUp();
        }
    }

    private void TrySwitchToCloseUp(){
        if(IsCloseUp) return;
        RaycastHit hit; 
        if (Physics.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), cam.transform.forward, out hit, 1000f))
        {
            if (hit.transform == avatarObj.transform)
            {
                customCam.SwitchToCloseUp();
                skinControllerAnimator.Play("ShowPanel");
                finishCustomizingButton.SetActive(true);
                IsCloseUp = true;
            }
        }
    }

    public void SwitchToFullBody(){
        customCam.SwitchToFullBody();
        skinControllerAnimator.Play("HidePanel");
        finishCustomizingButton.SetActive(false);
        IsCloseUp = false;
    }
}
