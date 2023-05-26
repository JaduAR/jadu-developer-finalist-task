//Created 5/23/2023
//Handles selection and color changes for hair items in UI screen.

using UnityEngine;
using UnityEngine.UI;

public class HairSelectControl : MonoBehaviour
{
    [SerializeField] GameObject previousCover;
    [SerializeField] Text previousText;

    [SerializeField] Color deselectColor;

    public void HairButtonCoverSelection(GameObject selectionCover)
    {
        if(previousCover == selectionCover) { return; }

        selectionCover.SetActive(true);

        if(previousCover != null)
        {
            previousCover.SetActive(false);
        }

        previousCover = selectionCover;
    }

    public void HairButtonTextChange(Text currText)
    {
        if (previousText == currText) { return; }

        currText.color = Color.white;

        if (previousText != null)
        {
            previousText.color = deselectColor;
        }

        previousText = currText;
    }
}
