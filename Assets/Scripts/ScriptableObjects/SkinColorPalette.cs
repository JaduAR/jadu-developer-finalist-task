using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TechTask
{

    [CreateAssetMenu(fileName = "New Skin Color Palette", menuName = "Create Avatar Item/Skin Color Palette")]
    public class SkinColorPalette : ScriptableObject
    {
        public Color[] SkinColors;

    }
}