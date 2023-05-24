using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour//, IPointerClickHandler//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject selectedRoot = null;
    [SerializeField] private GameObject unselectedRoot = null;

    public void SetActivate(bool isEnabled)
    {
        selectedRoot.SetActive(isEnabled);
        unselectedRoot.SetActive(!isEnabled);
    }   



    // public TabGroup tabGroup;

    // public Image backgroud;

    void Start()
    {
        // if(tabGroup == null)
        //     Debug.LogWarning("TabGroup is not initialized");
        // else
        // tabGroup.Subscribe(this);
    }


    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     tabGroup.OnTabSelected(this);
    // }


    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     tabGroup.OnTabEnter(this);
    // }

    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     tabGroup.OnTabExit(this);
    // }
}
