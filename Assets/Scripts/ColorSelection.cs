using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    private RawImage image;
    private GameManager gameManager;

    private void Start()
    {
        image = GetComponent<RawImage>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SelectColorButton()
    {
        // Reset the other color bubbles
        foreach (ColorSelection colorSelection in gameManager.colorSelection)
        {
            colorSelection.image.transform.localScale = Vector3.one;
        }

        image.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
