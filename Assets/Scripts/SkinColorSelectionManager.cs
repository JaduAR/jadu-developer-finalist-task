using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkinColorSelectionManager : SelectionManager
{
    [Tooltip("Collection of colors to spawn")]
    [SerializeField] List<Color> InitialSkinColors;
    [Tooltip("Prefab to spawn in from InitialSkinColors")]
    [SerializeField] GameObject SkinColorPrefab;
    [Tooltip("Parent color selectors to viewport")]
    [SerializeField] Transform SkinColorContent;
    [SerializeField] List<GameObject> SkinColorSelectors = new List<GameObject>();

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
}
