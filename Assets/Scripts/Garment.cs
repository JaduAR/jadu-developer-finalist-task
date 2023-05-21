using UnityEngine;

public enum GarementType
{
    HAIR,
    SKIN
}
/// <summary>
/// garement for the avatar
/// </summary>
public class Garment : ScriptableObject
{
    public Color        garementColor;
    public GarementType garementType;
    public Sprite       UIImage;
    public string       garmentName;
}
