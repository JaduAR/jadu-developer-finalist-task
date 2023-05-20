using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CustomizationTabTitleManager : MonoBehaviour
{
    [SerializeField] List<CustomizationTabTitle> customizationTabTitles = new List<CustomizationTabTitle>();
    [SerializeField] CustomizationTabTitle currentTab;
    // Start is called before the first frame update
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
        if (currentTab) currentTab.UnSetCurrent();
        currentTab = customizationTabTitle;
    }
}
