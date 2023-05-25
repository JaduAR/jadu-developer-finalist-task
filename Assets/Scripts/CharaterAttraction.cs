using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterAttraction : MonoBehaviour
{
    
    private void OnMouseDown()
    {
        if (SkinManager.Instance.CanInteractWithModel)
        {
            SkinManager.Instance.Screens[0].SetActive(true);
            SkinManager.Instance.EnableCameraState(1);
            SkinManager.Instance.SkinSlideManager(0);
            SkinManager.Instance.CanInteractWithModel = false;
        }
    }
}
