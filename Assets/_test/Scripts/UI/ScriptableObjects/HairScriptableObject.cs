using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableOjbects/UI/Hair", fileName = "HairScriptableObject")]
public class HairScriptableObject : ScriptableObject {

    public int id;
    public string hairName;
    public Sprite sprite;
    public Color backgroundColor = Color.black;
    public Color backgroundSelectedColor = Color.gray;
}
