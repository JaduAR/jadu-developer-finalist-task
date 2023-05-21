using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelector : CustomizationSelector
{
    [SerializeField] GameObject selectionHighlight;
    CanvasGroup selectionCanvasGroup;

    private void Start()
    {
        selectionCanvasGroup = selectionHighlight.GetComponent<CanvasGroup>();
    }
    public override void OnSelect()
    {
        SelectionManager.SetSelection(this);
        selectionHighlight.SetActive(true);
        selectionCanvasGroup.DOFade(1, EaseDuration).SetEase(EaseStyle);
    }

    public override void OnDeselect()
    {
        selectionHighlight.SetActive(false);
        selectionCanvasGroup.DOFade(0, EaseDuration).SetEase(EaseStyle);
    }

}
