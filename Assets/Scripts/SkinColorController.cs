using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinColorController : MonoBehaviour
{
  public enum SkinColor
  {
    NONE,
    TURQUOISE,
    BLUE,
    INDIGO,
    LIGHT_PINK,
    PINK,
    DARK_PINK,
    LIGHT_BROWN,
    BROWN,
    GREY,
    GREEN,
    MOSS_GREEN,
    YELLOW,
    RED,
  };

  public delegate void SelectColorHandler(SkinColor color);
  public static event SelectColorHandler OnColorSelected;

  [SerializeField]
  SkinColor skinColor = SkinColor.NONE;

  public void HandleColorSelected(int colorIndex)
  {
    skinColor = (SkinColor)colorIndex;
    OnColorSelected?.Invoke(skinColor);
  }
}
