using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] skins;
    private int lastColor = 0;
    [SerializeField]
    private Image[] panels;
    private int lastPan = 0;
    [SerializeField]
    private Animator skinAnim;
    [SerializeField]
    private Animator hairAnim;
    [SerializeField]
    private Animator openAnim;
    [SerializeField]
    private Animator menuAnim;
    [SerializeField]
    private Animator doneAnim;
    [SerializeField]
    private Animator camAnim;
    [SerializeField]
    private Animator lineAnim;
    private bool menuOpen = false;
    private int menu = 1;
    // Start is called before the first frame update
    void Start()
    {
        skins[lastColor].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 10f);
        skins[lastColor].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 10f);
        panels[lastPan].color = new Color(0, 255, 0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (!menuOpen)
            {
                openAnim.SetTrigger("Enter");
                doneAnim.SetTrigger("Enter");
                camAnim.SetTrigger("OpenMenu");
                menuOpen = true;
            }
        }
        
    }

    public void SelectColor(int newColor)
    {
        if(newColor != lastColor)
        {
            skins[lastColor].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 32f);
            skins[lastColor].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 32f);
            lastColor = newColor;
            skins[lastColor].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 10f);
            skins[lastColor].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 10f);
        }
    }

    public void SelectPan(int newPan)
    {
        if(newPan != lastPan)
        {
            panels[lastPan].color = new Color(0, 0, 0, 100);
            lastPan = newPan;
            panels[lastPan].color = new Color(0, 255, 0, 100);
        }
    }

    public void CloseMenu()
    {
        openAnim.SetTrigger("Exit");
        doneAnim.SetTrigger("Exit");
        menuAnim.SetTrigger("Skin");
        skinAnim.SetTrigger("Brighten");
        hairAnim.SetTrigger("Darken");
        lineAnim.SetTrigger("Skin");
        camAnim.SetTrigger("CloseMenu");
        menu = 1;
        menuOpen = false;
    }

    public void SetHair()
    {
        if(menu == 1)
        {
            openAnim.SetTrigger("Hair");
            menuAnim.SetTrigger("Hair");
            skinAnim.SetTrigger("Darken");
            hairAnim.SetTrigger("Brighten");
            lineAnim.SetTrigger("Hair");
            menu = 2;
        }
    }

    public void SetSkin()
    {
        if (menu == 2)
        {
            openAnim.SetTrigger("Skin");
            menuAnim.SetTrigger("Skin");
            skinAnim.SetTrigger("Brighten");
            hairAnim.SetTrigger("Darken");
            lineAnim.SetTrigger("Skin");
            menu = 1;
        }
    }
}
