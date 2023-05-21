using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

/// <summary>
/// A tab title among the customization tabs
/// </summary>
public class CustomizationTabTitle : MonoBehaviour
{
    CustomizationTabTitleManager manager;
    public TextMeshProUGUI Title;

    [Header("Bold on selected")]
    public TMP_FontAsset Regular;
    public TMP_FontAsset Bold;

    public CinemachineVirtualCamera CameraReference;
    public GameObject PanelReference;
    public float Panel_Y;

    void Awake()
    {
        // Janky but sure way to get manager
        manager = transform.parent.parent.parent.GetComponent<CustomizationTabTitleManager>();
        manager.AddCustomizationTabTitle(this);
    }

    public void SetCurrent()
    {
        manager.SetCurrentTab(this);
        Title.font = Bold;
    }

    public void UnSetCurrent()
    {
        Title.font = Regular;
    }
}
