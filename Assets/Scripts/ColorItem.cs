using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorItem : MonoBehaviour
{
    public GameObject ColorGameObject;

    public void SelectColor()
    {
        SkinManager.Instance.ApplyColor(ColorGameObject);
    }
}
