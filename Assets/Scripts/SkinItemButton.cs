using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinItemButton : MonoBehaviour
{
    [SerializeField] GameObject selectedRoot = null;
    [SerializeField] GameObject unselectedRoot = null;


    public void SetActivate(bool isEnabled)
    {
        selectedRoot.SetActive(isEnabled);
        unselectedRoot.SetActive(!isEnabled);
    }
}
