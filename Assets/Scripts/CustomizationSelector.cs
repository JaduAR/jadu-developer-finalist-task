using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CustomizationSelector : MonoBehaviour
{
    public SelectionManager SelectionManager { get; set; }
    public abstract void OnSelect();
    public abstract void OnDeselect();


    public void PrintType()
    {
        print($"Selector type of {this.GetType()}");
    }
}
