using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkinColorSelectionManager : SelectionManager
{
    [SerializeField] List<Color> InitialSkinColors;
    [SerializeField] GameObject SkinColorPrefab;
    [SerializeField] Transform SkinColorContent;
    [SerializeField] List<GameObject> SkinColorSelectors = new List<GameObject>();

    //public SkinColorSelector CurrentColor {get; private set;}

    // Start is called before the first frame update
    void Start()
    {   
        foreach (var initialSkinColor in InitialSkinColors)
        {
            var skinColorGameObject = Instantiate(SkinColorPrefab, SkinColorContent);
            var skinColorSelector = skinColorGameObject.GetComponent<SkinColorSelector>();
            skinColorSelector.Color = initialSkinColor;
            skinColorSelector.SelectionManager = this;

            SkinColorSelectors.Add(skinColorGameObject);
        }

    }
    public override void SetSelection(CustomizationSelector selection)
    {
        if (CurrentSelection)
            CurrentSelection.OnDeselect();

        CurrentSelection = selection;
    }

}
