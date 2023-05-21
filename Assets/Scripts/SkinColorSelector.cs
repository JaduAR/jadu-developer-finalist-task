using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorSelector : CustomizationSelector
{
    public Color Color;
    [SerializeField] Image Image;
    [SerializeField] RectTransform RectTransform;

    [SerializeField] Vector2 selectedSize = new Vector2(10, 10);
    [SerializeField] Vector2 deselectedSize = new Vector2(20, 20);

    // Start is called before the first frame update
    void Start()
    {
        if (Image == null) 
            Image = GetComponent<Image>();

        Image.color = Color;
    }

    public override void OnSelect()
    {
        SelectionManager.SetSelection(this);
        RectTransform.DOSizeDelta(selectedSize, EaseDuration).SetEase(EaseStyle);
    }
    public override void OnDeselect()
    {
        RectTransform.DOSizeDelta(deselectedSize, EaseDuration).SetEase(EaseStyle);
    }
}
