using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Keeps track of which <see cref="CustomizationTabTitle"/> is currently picked
/// </summary>
public class CustomizationTabTitleManager : MonoBehaviour
{
    public static CustomizationTabTitleManager Instance { get; private set; }

    [SerializeField] List<CustomizationTabTitle> customizationTabTitles = new List<CustomizationTabTitle>();
    public CustomizationTabTitle CurrentTab;
    [SerializeField] RectTransform activePageIndicator;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {// Default current to first tab
        GameManager.Instance.CurrentTabTitle = customizationTabTitles[0];
    }

    public void AddCustomizationTabTitle(CustomizationTabTitle customizationTabTitle)
    {// Adding in reverse order bc Unity likes to Start() from bottom of hierarchy
        customizationTabTitles.Insert(0, customizationTabTitle);
        GameManager.Instance.CustomizationPanelTabs.Insert(0, customizationTabTitle.PanelReference);
    }

    public void RemoveCustomizationTabTitle(CustomizationTabTitle customizationTabTitle)
    {
        customizationTabTitles.Remove(customizationTabTitle);
    }

    public void SetCurrentTab(CustomizationTabTitle customizationTabTitle)
    {
        if (CurrentTab) 
            CurrentTab.UnSetCurrent();

        CurrentTab = customizationTabTitle;
        activePageIndicator.SetParent(CurrentTab.transform, worldPositionStays: false);
        activePageIndicator.DOAnchorPosX(0, 0.5f);       
        GameManager.Instance.CurrentTabTitle = CurrentTab;
        GameManager.Instance.SetCustomizeState();
    }
}
