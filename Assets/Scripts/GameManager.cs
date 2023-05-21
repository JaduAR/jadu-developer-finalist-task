using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] CameraManager CameraManager = CameraManager.Instance;
    [SerializeField] CustomizationTabTitleManager CustomizationTabTitleManager = CustomizationTabTitleManager.Instance;

    [SerializeField] Ease EaseStyle = Ease.OutCirc;
    [SerializeField] float FadeDuration = 0.5f;

    [Header("Virtual Cameras")]
    public CinemachineVirtualCamera IdleCam;
    public CinemachineVirtualCamera SkinCloseUpCam;
    public CinemachineVirtualCamera HairCloseUpCam;

    public CanvasGroup CustomizationPanel;

    [Header("Done button")]
    public RectTransform DoneButton;
    public float DoneButtonInitial_Y = 125, DoneButtonFinal_Y = 0;

    [Header("Customziation panel")]
    public RectTransform CustomizationSelectionPanel;
    public float CustomizationSelectionPanel_Y = -500;
    public List<GameObject> CustomizationPanelTabs = new List<GameObject>();// Will contain all the below tabs

    [Header("Skin customization")]
    public GameObject SkinCustomizationPanel;
    public float SkinCustomizationPanel_Y = -250;

    [Header("Hair customization")]
    public GameObject HairCustomizationPanel;
    public float HairCustomizationPanel_Y = 100;

    [Header("Tabs")]
    public string CurrentTabTitle;

    // Hacky solution to couple tabs and their panels, not ideal, would work on this in the future
    public Dictionary<string, Action> TabTitleToFunctionDict = new Dictionary<string, Action>();

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!CameraManager) CameraManager = CameraManager.Instance;

        CustomizationPanelTabs.Add(SkinCustomizationPanel);
        CustomizationPanelTabs.Add(HairCustomizationPanel);
        SetIdleState();

        TabTitleToFunctionDict["Skin"] = SetSkinSelectState;
        TabTitleToFunctionDict["Hair"] = SetHairSelectState;

    }
    public void SetIdleState()
    {
        CameraManager.SwitchCamera(IdleCam);
        DoneButton.DOAnchorPosY(DoneButtonInitial_Y, FadeDuration);
        CustomizationSelectionPanel.DOAnchorPosY(CustomizationSelectionPanel_Y, FadeDuration).SetEase(EaseStyle);
        CustomizationPanel.DOFade(0, FadeDuration);
        DisableTabs();
    }
    public void SetSkinSelectState()
    {
        CameraManager.SwitchCamera(SkinCloseUpCam);
        DoneButton.DOAnchorPosY(DoneButtonFinal_Y, FadeDuration);
        CustomizationPanel.DOFade(1, FadeDuration);
        EnableTab(SkinCustomizationPanel);
        CustomizationSelectionPanel.DOAnchorPosY(SkinCustomizationPanel_Y, FadeDuration).SetEase(EaseStyle);
    }
    public void SetHairSelectState()
    {
        CameraManager.SwitchCamera(HairCloseUpCam);
        DoneButton.DOAnchorPosY(DoneButtonFinal_Y, FadeDuration);
        CustomizationPanel.DOFade(1, FadeDuration);
        EnableTab(HairCustomizationPanel);
        CustomizationSelectionPanel.DOAnchorPosY(HairCustomizationPanel_Y, FadeDuration).SetEase(EaseStyle);
    }

    public void SetCustomizeState()
    {
        CustomizationPanel.gameObject.SetActive(true);

        TabTitleToFunctionDict[CurrentTabTitle]();
    }

    /// <summary>
    /// Enables a certain tab while disabling the others
    /// </summary>
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

    /// <summary>
    /// Disables all tabs (called when "done")
    /// </summary>
    private void DisableTabs() {
        foreach (var tab in CustomizationPanelTabs)
        {
            tab.SetActive(false);
        }
    }
}
