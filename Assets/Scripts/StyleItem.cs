using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StyleItem : MonoBehaviour
{
    public GameObject SelectedStyleEffect;
    public Text StyleName;

    public void EnableEffect(int index)
    {
        SkinManager.Instance.EnableEffectOnClick(index);
    }
}
