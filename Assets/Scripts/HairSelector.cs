using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelector : CustomizationSelector
{
    [SerializeField] GameObject selectionHighlight;
    CanvasGroup selectionHighlightCanvasGroup;// Fade grey bg when selected

    private void Start()
    {
        selectionHighlightCanvasGroup = selectionHighlight.GetComponent<CanvasGroup>();
    }
    public override void OnSelect()
    {
        base.OnSelect();
        selectionHighlight.SetActive(true);
        selectionHighlightCanvasGroup.DOFade(1, EaseDuration).SetEase(EaseStyle);
    }

    public override void OnDeselect()
    {
        base.OnDeselect();
        selectionHighlight.SetActive(false);
        selectionHighlightCanvasGroup.DOFade(0, EaseDuration).SetEase(EaseStyle);
    }

}
