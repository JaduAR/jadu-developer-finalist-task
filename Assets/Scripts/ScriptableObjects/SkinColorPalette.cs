// ----------------------
// Onur EREREN - May 2023
// ----------------------

// Jadu UI Technical Task  - Skin Color Palette ScriptableObject
// Stores skin colors as a palette.
// ScriptableObject format for ease of creating new palettes in the editor

using UnityEngine;

namespace TechTask
{
    [CreateAssetMenu(fileName = "New Skin Color Palette", menuName = "Create Avatar Item/Skin Color Palette")]
    public class SkinColorPalette : ScriptableObject
    {
        public Color[] SkinColors;

    }
}