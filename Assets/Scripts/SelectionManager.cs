using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectionManager : MonoBehaviour
{
    public CustomizationSelector CurrentSelection { get; set; }
    public abstract void SetSelection(CustomizationSelector selection);
}
