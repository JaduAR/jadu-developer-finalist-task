//Created 5/23/2023
//Handles skin color selection and deselections process designated via Figma
//OnButtonClick size objects accordingly.

using UnityEngine;

public class ColorSelectControl : MonoBehaviour
{
    readonly int defaultSize = 45;
    readonly int selectedSize = 20;

    [SerializeField] RectTransform previousTransform;

    public void ColorButtonClicked(RectTransform buttonTransform)
    {
        if(previousTransform == buttonTransform) { return; }
        
        buttonTransform.sizeDelta = new Vector2(selectedSize, selectedSize);        
        if(previousTransform != null) 
            previousTransform.sizeDelta = new Vector2(defaultSize, defaultSize); 
        previousTransform = buttonTransform;
    }   
}
