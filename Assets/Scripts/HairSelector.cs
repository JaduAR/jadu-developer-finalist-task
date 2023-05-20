using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelector : CustomizationSelector
{
    [SerializeField] GameObject selectionHighlight;
    public override void OnSelect()
    {
        SelectionManager.SetSelection(this);
        selectionHighlight.SetActive(true);
    }

    public override void OnDeselect()
    {
        selectionHighlight.SetActive(false);
    }

}
