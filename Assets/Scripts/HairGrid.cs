using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HairGrid : MonoBehaviour, IPointerClickHandler
{
    public Action<HairGrid> OnGridClicked;

    public Image ActiveBG;
    public GameObject InactiveBG;
    public TMP_Text Name;
    public Image HairImage;

    public bool IsSelected = false;
    public int Index;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnGridClicked(this);
    }

    public void SetSelected(bool selected)
    {
        IsSelected = selected;
        ActiveBG.enabled = selected;
        InactiveBG.SetActive(!selected);

        //transparency
        var c = HairImage.color;
        c.a = selected ? 0.2f : 1f;
        HairImage.color = c;
    }

    public void Init(string name, Sprite tex)
    {
        Name.SetText(name);
        HairImage.sprite = tex;
    }
}
