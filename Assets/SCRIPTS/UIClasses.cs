using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JaduTest
{
    [System.Serializable]
    public class SkinOption
    {
        public string ID;
        public string ColorHexValue;

        public Color GetColor()
        {
            Color output;
            ColorUtility.TryParseHtmlString(ColorHexValue, out output);

            return output;
        }
    }

    [System.Serializable]
    public class HairOption
    {
        public string ID;
        public Sprite Icon;     
    }
}

