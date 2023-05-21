using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomizationTabTitleManager : MonoBehaviour
{
    public static CustomizationTabTitleManager Instance { get; private set; }

    [SerializeField] List<CustomizationTabTitle> customizationTabTitles = new List<CustomizationTabTitle>();
    public CustomizationTabTitle CurrentTab;
    [SerializeField] RectTransform tabUnderline;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetCurrentTab(customizationTabTitles[0]);
    }

    public void AddCustomizationTabTitle(CustomizationTabTitle customizationTabTitle)
    {
        customizationTabTitles.Insert(0, customizationTabTitle);
    }

    public void RemoveCustomizationTabTitle(CustomizationTabTitle customizationTabTitle)
    {
        customizationTabTitles.Remove(customizationTabTitle);
    }

    public void SetCurrentTab(CustomizationTabTitle customizationTabTitle)
    {
        if (CurrentTab) CurrentTab.UnSetCurrent();
        CurrentTab = customizationTabTitle;
        tabUnderline.parent = CurrentTab.transform;
        tabUnderline.DOAnchorPosX(0, 0.5f);
        GameManager.Instance.CurrentTabTitle = CurrentTab.Title.text;
    }
}
