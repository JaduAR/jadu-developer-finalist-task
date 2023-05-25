using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinItemGroup : MonoBehaviour
{
    [SerializeField] private SkinItemButton[] itemButtons;
    [SerializeField] private ScrollRect scrollRect = null;
    SkinItemButton selectedItem = null;
    int itemCount = 0;

    void Start()
    {
        ResetItems();
        itemCount = itemButtons.Length;
        if(itemCount > 0)
        {
            itemButtons[0].SetActivate(true);
            scrollRect.ScrollToCenter((RectTransform)itemButtons[0].gameObject.transform);
        }
    }

    private void ResetItems()
    {
        for(int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].SetActivate(false);
        }
    }

    public void OnClick()
    {
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        selectedItem = tempBtn.GetComponent<SkinItemButton>();

        scrollRect.ScrollToCenter((RectTransform)tempBtn.transform);

        ResetItems();
        selectedItem.SetActivate(true);
    } 

}