using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "My Asset/Create Hair Asset")]
public class HairAsset : ScriptableObject
{
    public Texture2D hairIcon;
    public string hairText;
    public GameObject hairAsset;
}
