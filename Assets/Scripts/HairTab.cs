using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairTab : Tab
{
    [SerializeField] private List<Hair> _hairs;
    [SerializeField] private GameObject _hairSelectorPrefab;

    protected void Awake()
    {
        //Create hair buttons for grid container.
        foreach (var hair in _hairs)
        {
            var hairSelector = Instantiate(_hairSelectorPrefab,tabContent.transform).GetComponent<HairSelector>();
            hairSelector.SetOwner(this);
            hairSelector.SetName(hair.HairName);
            hairSelector.SetHairSprite(hair.HairSprite);
        }
    }
}
