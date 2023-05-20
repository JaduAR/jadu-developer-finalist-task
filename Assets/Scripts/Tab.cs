using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Tab : MonoBehaviour
{
    public string TabName;
    public UnityEvent OnTabSelected;
    public Vector2 TabPosition = new Vector2(0, 0);

    protected Selector activeItem;
    protected bool isActive;
    
    private TabButtonController _buttonController;
    
    public TabButtonController ButtonController => _buttonController;
    public Selector ActiveItem => activeItem;

    [SerializeField] protected GameObject tabContent;

    public virtual void SetActiveItem(Selector selector)
    {
        if(activeItem != null && selector != activeItem)
            activeItem.Deselect();
        activeItem = selector;
    }

    public virtual void Select()
    {
        if(isActive) return;
        OnTabSelected.Invoke();
        _buttonController.SetActiveState(true);
        tabContent.SetActive(true);
        isActive = true;
    }

    public virtual void Deselect()
    {
        _buttonController.SetActiveState(false);
        tabContent.SetActive(false);
        isActive = false;
    }

    //Assigns the button to the tab.
    public virtual void SetButton(TabButtonController button)
    {
        _buttonController = button;
    }
}
