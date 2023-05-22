using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hair Style", menuName = "Create Avatar Item/Hair Style")]
public class HairStyle : ScriptableObject
{
    public Sprite StyleSprite;
    public string StyleName;
}
