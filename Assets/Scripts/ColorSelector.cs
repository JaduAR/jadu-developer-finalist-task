using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : Selector
{
   [Header("Component References")]
   [SerializeField] private Image _buttonImage;
   [Header("Properties")]
   [SerializeField] private float _shrinkSize = 0.25f;
   [SerializeField] private float _tweenDuration = 0.1f;
   [SerializeField] private AnimationCurve _TweenCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
   
   private Coroutine _scaleTweenCoroutine;

   public void SetColor(Color skinColor)
   {
      _buttonImage.color = skinColor;
   }

   //This is called when the button is clicked. Hooked in by Unity Event.
   public override void Select()
   {
      if(_scaleTweenCoroutine != null) StopCoroutine(_scaleTweenCoroutine);
      StartCoroutine(ScaleTween(Vector3.one * _shrinkSize, _tweenDuration));
      owner.SetActiveItem(this);
   }

   public override void Deselect()
   {
      if(_scaleTweenCoroutine != null) StopCoroutine(_scaleTweenCoroutine);
      StartCoroutine(ScaleTween(Vector3.one, _tweenDuration));
   }
   
   private IEnumerator ScaleTween(Vector3 targetScale, float duration)
   {
      var startScale = transform.localScale;
      var elapsedTime = 0f;
      while (elapsedTime < duration)
      {
         var t = _TweenCurve.Evaluate(elapsedTime / duration);
         transform.localScale = Vector3.Lerp(startScale, targetScale, t);
         elapsedTime += Time.deltaTime;
         yield return new WaitForEndOfFrame();
      }
      transform.localScale = targetScale;
   }
}
