using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TabButtonHandler : MonoBehaviour
{
  [SerializeField]
  GameObject contentView;

  [SerializeField]
  CameraSwitcher.ActiveCamera desiredCameraState;

  TextMeshProUGUI text;
  Image underline;

  [SerializeField]
  Color selectedColor;
  [SerializeField]
  Color defaultColor;
  [SerializeField]
  float transitionTime = 0.5f;

  void Awake()
  {
    text = transform.GetComponentInChildren<TextMeshProUGUI>();
    underline = transform.GetComponentInChildren<Image>();
    underline?.gameObject.SetActive(false);
  }


  void OnEnable()
  {
    CameraSwitcher.OnContentViewChanged += OnContentViewChanged;
    CameraSwitcher.OnContentViewReset += OnContentViewReset;
  }

  void OnDisable()
  {
    CameraSwitcher.OnContentViewChanged -= OnContentViewChanged;
    CameraSwitcher.OnContentViewReset -= OnContentViewReset;
  }

  void OnContentViewChanged(CameraSwitcher.ActiveCamera activeCamera)
  {
    if (activeCamera == desiredCameraState)
    {
      contentView?.SetActive(true);
      underline?.gameObject.SetActive(true);
      text?.DOColor(selectedColor, transitionTime);
    }
    else
    {
      contentView?.SetActive(false);
      underline?.gameObject.SetActive(false);
      text?.DOColor(defaultColor, transitionTime);

    }
  }

  void OnContentViewReset()
  {
    underline?.gameObject.SetActive(false);
    if (text != null)
    {
      text.color = defaultColor;
    }
  }
}
