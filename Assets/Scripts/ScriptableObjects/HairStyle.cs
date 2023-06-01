// ----------------------
// Onur EREREN - May 2023
// ----------------------

// Jadu UI Technical Task  - Hair Style ScriptableObject
// Stores hairstyle images and names.
// ScriptableObject format for ease of creating new styles in the editor

using UnityEngine;

[CreateAssetMenu(fileName = "New Hair Style", menuName = "Create Avatar Item/Hair Style")]
public class HairStyle : ScriptableObject
{
    public Sprite StyleSprite;
    public string StyleName;
}
