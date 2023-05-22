using System;
using DG.Tweening;
using UnityEngine;

public class SlideInNOutPanel : MonoBehaviour
{
    Guid    uid;
    float   _duration = 0.5f;

    public void Animate(float yPos)
    {
        if (DOTween.IsTweening(gameObject))
        {
            DOTween.Kill(uid);
        }

        RectTransform rect = transform as RectTransform;
        if(rect != null)
        {
            rect.DOMoveY(yPos, _duration);
        }
    }
}
