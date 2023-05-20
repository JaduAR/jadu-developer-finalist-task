using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelectionManager : SelectionManager
{
    [SerializeField] GameObject[] InitialPrefabs;
    [SerializeField] Transform HairContent;
    [SerializeField] GameObject[] HairContentSelectors;

    private void Start()
    {
        foreach (GameObject pref in InitialPrefabs)
        {
             Instantiate(pref, HairContent).GetComponent<HairSelector>().SelectionManager = this;
        }
    }
    public override void SetSelection(CustomizationSelector selection)
    {
        if (CurrentSelection)
            CurrentSelection.OnDeselect();

        CurrentSelection = selection;
    }
}
