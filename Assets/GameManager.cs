using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] CameraManager CameraManager = CameraManager.Instance;

    public CinemachineVirtualCamera IdleCam;
    public CinemachineVirtualCamera SkinCloseUpCam;
    public CinemachineVirtualCamera HairCloseUpCam;

    public GameObject CustomizationPanel;

    public List<GameObject> CustomizationPanelTabs = new List<GameObject>();// Will contain all the below tabs

    public GameObject SkinCustomizationPanel;
    public GameObject HairCustomizationPanel;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!CameraManager) CameraManager = CameraManager.Instance;

        CustomizationPanelTabs.Add(SkinCustomizationPanel);
        CustomizationPanelTabs.Add(HairCustomizationPanel);
    }
    public void SetIdleState()
    {
        CameraManager.SwitchCamera(IdleCam);
        CustomizationPanel.SetActive(false);
        DisableTabs();
    }
    public void SetSkinSelectState()
    {
        CameraManager.SwitchCamera(SkinCloseUpCam);
        EnableTab(SkinCustomizationPanel);
    }
    public void SetHairSelectState()
    {
        CameraManager.SwitchCamera(HairCloseUpCam);
        EnableTab(HairCustomizationPanel);
    }

    public void SetCustomizeState()
    {
        CustomizationPanel.SetActive(true);
        SetSkinSelectState();
        if (Input.GetMouseButtonDown(0))
        {
            print(Input.mousePosition);
        }
    }
    private void EnableTab(GameObject currentTab)
    {
        foreach (var tab in CustomizationPanelTabs)
        {
            if (tab == currentTab)
                tab.SetActive(true);
            else
                tab.SetActive(false);
        }
    }

    private void DisableTabs() {
        foreach (var tab in CustomizationPanelTabs)
        {
            tab.SetActive(false);
        }
    }
}
