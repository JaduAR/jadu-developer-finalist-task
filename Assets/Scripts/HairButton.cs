using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HairButton : MonoBehaviour
{
    Button btn;

    public bool StartSelected;

    public Image BackgroundImage;
    public Color BackgroundSelected;
    Color BackgroundDeselected;
    public Image HairImage;
    public Color HairSelected;
    Color HairDeselected;
    public TMP_Text Text;
    public Color TextSelected;
    Color TextDeselected;

    float animTime = 0.4f;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        TextDeselected = Text.color;
        HairDeselected = HairImage.color;
        BackgroundDeselected = BackgroundImage.color;

        if (StartSelected)
            OnClick();

    }


    void OnClick()
    {
        HairSelector.Instance.ButtonClicked(this);
    }


    public void CancelRunningTween()
    {
        LeanTween.cancel(gameObject);
    }

    public void Select()
    {
        LeanTween.value(0, 1, animTime).setOnUpdate((float val) => {
            BackgroundImage.color = Color.Lerp(BackgroundDeselected, BackgroundSelected, val);
            HairImage.color = Color.Lerp(HairDeselected, HairSelected, val);
            Text.color = Color.Lerp(TextDeselected, TextSelected, val);
        });
    }
    public void Deselect()
    {
        LeanTween.value(1, 0, animTime).setOnUpdate((float val) => {
            BackgroundImage.color = Color.Lerp(BackgroundDeselected, BackgroundSelected, val);
            HairImage.color = Color.Lerp(HairDeselected, HairSelected, val);
            Text.color = Color.Lerp(TextDeselected, TextSelected, val);
        });
    }
}
