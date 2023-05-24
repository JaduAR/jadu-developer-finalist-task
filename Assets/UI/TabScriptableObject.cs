using UnityEngine;

[CreateAssetMenu(fileName = "Tab", menuName = "ScriptableObjects/TabScriptableObject")]
public class TabScriptableObject : ScriptableObject {
    public string label;
    public TabContents contentPrefab;
    public float panelHeight;
}
