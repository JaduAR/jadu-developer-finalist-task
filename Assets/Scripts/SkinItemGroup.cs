using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkinItemGroup : MonoBehaviour
{
    [SerializeField] private SkinItemButton[] itemButtons;
    SkinItemButton selectedItem = null;

    void Start()
    {
        ResetItems();
        if(itemButtons.Length > 0)
            itemButtons[0].SetActivate(true);
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

        ResetItems();
        selectedItem.SetActivate(true);

        Debug.Log(selectedItem);
    } 

}
