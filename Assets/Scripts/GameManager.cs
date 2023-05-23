using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public ColorSelection[] colorSelection;
    public TextMeshProUGUI selectSkinColorButtonText;
    public GameObject selectSkinColorWindow;
    public TextMeshProUGUI selectHairstyleButtonText;
    public GameObject selectHairstyleWindow;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DoneButton()
    {

    }

    public void SelectSkinColor()
    {
        selectSkinColorButtonText.color = Color.white;
        selectHairstyleButtonText.color = Color.grey;

        selectSkinColorWindow.SetActive(true);
        selectHairstyleWindow.SetActive(false);
    }

    public void SelectHairstyle()
    {
        selectSkinColorButtonText.color = Color.grey;
        selectHairstyleButtonText.color = Color.white;

        selectSkinColorWindow.SetActive(false);
        selectHairstyleWindow.SetActive(true);
    }
}
