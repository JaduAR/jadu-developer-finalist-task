using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hair", menuName = "CharacterData/Hair", order = 2)]
public class Hair : ScriptableObject
{
   public Sprite HairSprite;
   public string HairName;
}
