using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Tab : MonoBehaviour
{
    public UnityEvent OnTabSelected;
    
    public Vector2 TabPosition = new Vector2(0, 0);
    protected Selector activeItem;
    
    [SerializeField] protected GameObject tabContent;
    
    public abstract void SetActiveItem(Selector selector);
    public abstract void Select();
    public abstract void Deselect();
}
