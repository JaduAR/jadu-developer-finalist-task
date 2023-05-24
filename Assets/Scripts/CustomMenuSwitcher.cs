using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMenuSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject skinMenu;
    [SerializeField] private GameObject hairMenu;
    [SerializeField] private CustomizerCamera customCam;

    public void SwitchToMenuByIndex(int index){
        switch(index){
            case 0:
                skinMenu.SetActive(true);
                hairMenu.SetActive(false);
                customCam.SwitchToCloseUp();
                break;
            case 1:
                skinMenu.SetActive(false);
                hairMenu.SetActive(true);
                customCam.SwitchToHairCloseUp();
                break;
        }
    }
}
