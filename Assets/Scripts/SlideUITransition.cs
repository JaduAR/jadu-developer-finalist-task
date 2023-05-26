using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class SlideUITransition : MonoBehaviour
{
  [SerializeField]
  float transitionTime = 0.25f;

  RectTransform panel;
  float originalYPosition;

  void Start()
  {
    panel = GetComponent<RectTransform>();
    originalYPosition = panel.anchoredPosition.y;
  }

  public void SkinSlideTransition(float targetAnchorYPosition)
  {
    panel.DOAnchorPosY(targetAnchorYPosition, transitionTime);
  }

  public void HairSlideTransition(float targetAnchorYPosition)
  {
    panel.DOAnchorPosY(targetAnchorYPosition, transitionTime);
  }

  public void ResetPosition()
  {
    panel.anchoredPosition = new Vector2(panel.anchoredPosition.x, originalYPosition);
  }
}
