using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabGroup : MonoBehaviour
{
    [SerializeField] private TabButton[] characterMenuTabs;

    [SerializeField] private GameObject[] characterMenuPages;
    [SerializeField] private float[] characterMenuYPositions; //-356, 0

    TabButton selectedTab = null;
    

    // // Start is called before the first frame update
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
            // if(selectedTab != null && characterMenuTabs[i] == selectedTab)
            //     continue;
            characterMenuTabs[i].SetActivate(false);
        }

        for(int i = 0; i < characterMenuPages.Length; i++)
        {
            // if(selectedTab != null && tabPages[i] == selectedTab)
            //     continue;
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
