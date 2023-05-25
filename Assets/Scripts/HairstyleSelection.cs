using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairstyleSelection : MonoBehaviour
{
    private RawImage image;
    private GameManager gameManager;
    public Texture[] textures;

    private void Start()
    {
        image = GetComponent<RawImage>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void SelectHairstyleButton()
    {
        // Reset the other color bubbles
        foreach (HairstyleSelection hairstyleSelection in gameManager.hairstylesSelection)
        {
            hairstyleSelection.image.texture = textures[0];
        }

        image.texture = textures[1];
    }
}
