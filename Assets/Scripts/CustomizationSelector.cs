using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Abstract class for customization selections (selector item)
/// </summary>
public abstract class CustomizationSelector : MonoBehaviour
{
    protected Ease EaseStyle = Ease.OutCirc;
    protected float EaseDuration = 0.2f;

    /// <summary>
    /// <see cref="SelectionManager"/> that keeps track of which selection in the collection is selected
    /// </summary>
    public SelectionManager SelectionManager { get; set; }
    public virtual void OnSelect() {
        SelectionManager.SetSelection(this);
    }
    public virtual void OnDeselect()
    {

    }

    public void PrintType()
    {
        print($"Selector type of {this.GetType()}");
    }
}
