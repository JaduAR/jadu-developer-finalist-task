using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private TabButton[] characterMenuTabs;

    [SerializeField] private GameObject[] characterMenuPages;
    [SerializeField] private float[] characterMenuYPositions;

    TabButton selectedTab = null;

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        ResetTabs();

        characterMenuTabs[0].SetActivate(true);
        characterMenuPages[0].SetActive(true);
    }

    private void ResetTabs()
    {
        for(int i = 0; i < characterMenuTabs.Length; i++)
        {
            characterMenuTabs[i].SetActivate(false);
        }

        for(int i = 0; i < characterMenuPages.Length; i++)
        {
            characterMenuPages[i].SetActive(false);
        }
    }

    public void OnClick()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        selectedTab = tempBtn.GetComponent<TabButton>();

        int index = tempBtn.transform.GetSiblingIndex();

        ResetTabs();
        selectedTab.SetActivate(true);
        characterMenuPages[index].SetActive(true);
    }
}
