using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Style", menuName = "ScriptableObjects/HairStyleScriptableObject")]
public class HairStyleScriptableObject : ScriptableObject {
    public string label;
    public Sprite preview;
}
