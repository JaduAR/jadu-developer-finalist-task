using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for keeping track of selection of a <see cref="CustomizationSelector"/>
/// </summary>
public abstract class SelectionManager : MonoBehaviour
{
    public CustomizationSelector CurrentSelection { get; protected set; }
    [SerializeField] Ease fadeEase = Ease.InOutCirc;
    [SerializeField] float fadeDuration = .5f;
    [SerializeField] protected CanvasGroup selectionViewport; // Fades out on deselect
    void OnDisable()
    {
        selectionViewport.DOFade(0, fadeDuration).SetEase(fadeEase);
    }

    void OnEnable()
    {
        selectionViewport.DOFade(1, fadeDuration).SetEase(fadeEase);
    }

    public void SetSelection(CustomizationSelector selection)
    {
        if (CurrentSelection)
            CurrentSelection.OnDeselect();

        CurrentSelection = selection;
    }
}
