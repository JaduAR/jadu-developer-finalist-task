using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] CameraManager CameraManager = CameraManager.Instance;

    public float FadeDuration = 0.5f;

    public CinemachineVirtualCamera IdleCam;
    public CinemachineVirtualCamera SkinCloseUpCam;
    public CinemachineVirtualCamera HairCloseUpCam;

    public CanvasGroup CustomizationPanel;
    
    public RectTransform DoneButton;
    public float DoneButtonInitial_Y = 125, DoneButtonFinal_Y = 0;

    public RectTransform CustomizationSelectionPanel;
    public float CustomizationSelectionPanel_Y = -500;

    public List<GameObject> CustomizationPanelTabs = new List<GameObject>();// Will contain all the below tabs

    public GameObject SkinCustomizationPanel;
    public float SkinCustomizationPanel_Y = -250;

    public GameObject HairCustomizationPanel;
    public float HairCustomizationPanel_Y = 100;


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
    }
    public void SetIdleState()
    {
        CameraManager.SwitchCamera(IdleCam);
        DoneButton.DOAnchorPosY(DoneButtonInitial_Y, FadeDuration);
        CustomizationSelectionPanel.DOAnchorPosY(CustomizationSelectionPanel_Y, FadeDuration).SetEase(Ease.Linear);
        CustomizationPanel.DOFade(0, FadeDuration);
        DisableTabs();
    }
    public void SetSkinSelectState()
    {
        CameraManager.SwitchCamera(SkinCloseUpCam);
        DoneButton.DOAnchorPosY(DoneButtonFinal_Y, FadeDuration);
        CustomizationPanel.DOFade(1, FadeDuration);

        EnableTab(SkinCustomizationPanel);
        CustomizationSelectionPanel.DOAnchorPosY(SkinCustomizationPanel_Y, FadeDuration).SetEase(Ease.Linear);
        
    }
    public void SetHairSelectState()
    {
        CameraManager.SwitchCamera(HairCloseUpCam);
        DoneButton.DOAnchorPosY(DoneButtonFinal_Y, FadeDuration);

        CustomizationPanel.DOFade(1, FadeDuration);
        EnableTab(HairCustomizationPanel);
        CustomizationSelectionPanel.DOAnchorPosY(HairCustomizationPanel_Y, FadeDuration).SetEase(Ease.Linear);
    }

    public void SetCustomizeState()
    {
        CustomizationPanel.gameObject.SetActive(true);
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
