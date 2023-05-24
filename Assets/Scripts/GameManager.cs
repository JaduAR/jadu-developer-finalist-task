using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // UI
    public GameObject uiWindow;
    private Animator uiWindowAnimator;
    public ColorSelection[] colorSelection;
    public TextMeshProUGUI selectSkinColorButtonText;
    public GameObject selectSkinColorWindow;
    public TextMeshProUGUI selectHairstyleButtonText;
    public GameObject selectHairstyleWindow;
    public GameObject doneButton;
    public GameObject mainCamera;
    private Animator cameraAnimator;
    public GameObject uiNavigationBar;
    private Animator uiNavigationBarAnimator;

    void Start()
    {
        uiWindowAnimator = uiWindow.GetComponent<Animator>();
        cameraAnimator = mainCamera.GetComponent<Animator>();
        uiNavigationBarAnimator = uiNavigationBar.GetComponent<Animator>();
    }

    public void OpenCustomization()
    {
        uiWindow.SetActive(true);
        doneButton.SetActive(true);
        SelectSkinColor();
    }

    IEnumerator CloseCustomization()
    {
        yield return new WaitForSeconds(0.5f);
        uiWindow.SetActive(false);
    }

    public void SelectSkinColor()
    {
        // Switch window to skin color customization
        selectSkinColorButtonText.color = Color.white;
        selectHairstyleButtonText.color = Color.grey;
        uiWindowAnimator.SetInteger("level", 1);
        cameraAnimator.SetInteger("zoom", 1);
        uiNavigationBarAnimator.SetBool("goRight", false);

        selectSkinColorWindow.SetActive(true);
        selectHairstyleWindow.SetActive(false);
    }

    public void SelectHairstyle()
    {
        // Switch window to hairstyle customization
        selectSkinColorButtonText.color = Color.grey;
        selectHairstyleButtonText.color = Color.white;
        uiWindowAnimator.SetInteger("level", 2);
        cameraAnimator.SetInteger("zoom", 2);
        uiNavigationBarAnimator.SetBool("goRight", true);

        selectSkinColorWindow.SetActive(false);
        selectHairstyleWindow.SetActive(true);
    }
    public void DoneButton()
    {
        uiWindowAnimator.SetInteger("level", 0);
        cameraAnimator.SetInteger("zoom", 0);
        doneButton.SetActive(false);
        StartCoroutine(CloseCustomization());
    }
}
