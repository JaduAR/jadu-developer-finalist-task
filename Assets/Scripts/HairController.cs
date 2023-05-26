using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairController : MonoBehaviour
{
  public enum HairType
  {
    NONE,
    LAVAPOWER,
    GOLDSPIKE,
    LAVENDER,
    NINJA,
    ICECREAM,
    SOPRANO,
  };

  [SerializeField]
  HairType hairType = HairType.NONE;

  public delegate void HairSelectHandler(HairType hairType);
  public static event HairSelectHandler OnHairSelect;

  public void SelectHair(int hair)
  {
    hairType = (HairType)hair;
    OnHairSelect?.Invoke(hairType);
  }
}
