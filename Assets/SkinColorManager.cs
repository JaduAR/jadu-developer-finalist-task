using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkinColorManager : MonoBehaviour
{
    [SerializeField] Color[] InitialSkinColors;
    [SerializeField] GameObject SkinColorPrefab;
    [SerializeField] Transform SkinColorContent;
    [SerializeField] GameObject[] SkinColorSelectors;

    public SkinColor CurrentColor {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        SkinColorSelectors = new GameObject[InitialSkinColors.Length];

        for (int i = 0; i < InitialSkinColors.Length; i++) {
            var skinColorGameObject = Instantiate(SkinColorPrefab, SkinColorContent);
            var skinColorSelector = skinColorGameObject.GetComponent<SkinColor>();
            skinColorSelector.Color = InitialSkinColors[i];
            skinColorSelector.SkinColorManager = this;

            SkinColorSelectors[i] = skinColorGameObject;
        }

    }
    public void SetCurrentSkinColor(SkinColor skinColor)
    {
        if (CurrentColor)
            CurrentColor.DeselectColor();

        CurrentColor = skinColor;
    }
}
