using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class ColorSelector : MonoBehaviour
{

  RectTransform rectTransform;

  [SerializeField]
  SkinColorController.SkinColor skinColor;
  [SerializeField]
  float selectedScale = 0.2f;
  [SerializeField]
  float originalScale = 1f;

  void Awake()
  {
    rectTransform = GetComponent<RectTransform>();
  }

  void OnEnable()
  {
    SkinColorController.OnColorSelected += OnSelected;
  }

  void OnDisable()
  {
    SkinColorController.OnColorSelected -= OnSelected;
  }

  void OnSelected(SkinColorController.SkinColor color)
  {
    if (skinColor == color)
    {
      rectTransform.DOScale(selectedScale, 0.25f);
    }
    else
    {
      rectTransform.DOScale(originalScale, 0.25f);
    }
  }
}
