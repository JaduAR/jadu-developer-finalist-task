using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class HairSelector : MonoBehaviour
{
  [SerializeField]
  HairController.HairType hairType;

  [SerializeField]
  Color selectedColor;

  Image image;
  Color originalColor;

  void Awake()
  {
    image = GetComponent<Image>();
    originalColor = image.color;
  }

  void OnEnable()
  {
    HairController.OnHairSelect += OnHairSelect;
  }

  void OnDisable()
  {
    HairController.OnHairSelect -= OnHairSelect; 
  }

  void OnHairSelect(HairController.HairType hairType)
  {
    if (this.hairType == hairType)
    {
      image.DOColor(selectedColor, 0.25f);
    }
    else
    {
      image.DOColor(originalColor, 0.25f);
    }
  }
}
