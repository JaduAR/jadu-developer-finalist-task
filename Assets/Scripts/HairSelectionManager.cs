using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelectionManager : SelectionManager
{
    [Tooltip("Collection of hairstyle selectors to spawn in")]
    [SerializeField] GameObject[] InitialPrefabs;
    [Tooltip("Parent hair selectors to viewport")]
    [SerializeField] Transform HairContent;
    [SerializeField] GameObject[] HairContentSelectors;

    private void Start()
    {
        foreach (GameObject pref in InitialPrefabs)
        {
             Instantiate(pref, HairContent).GetComponent<HairSelector>().SelectionManager = this;
        }
    }
}
