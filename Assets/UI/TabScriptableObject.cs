using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tab", menuName = "ScriptableObjects/TabScriptableObject")]
public class TabScriptableObject : ScriptableObject
{
    public string label;
    public GameObject contentPrefab;
    public float panelHeight;
}
