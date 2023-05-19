using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColor : MonoBehaviour
{
    public SkinColorManager SkinColorManager;
    public Color Color;
    public Image Image;
    [SerializeField] RectTransform RectTransform;

    [SerializeField] Vector2 selectedSize = new Vector2(10, 10);
    [SerializeField] Vector2 deselectedSize = new Vector2(20, 20);

    // Start is called before the first frame update
    void Start()
    {
        if (Image == null) Image = GetComponent<Image>();
        Image.color = Color;


    }

    public void SelectColor()
    {
        SkinColorManager.SetCurrentSkinColor(this);
        RectTransform.sizeDelta = selectedSize;
    }
    public void DeselectColor()
    {
        RectTransform.sizeDelta = deselectedSize;
    }
}
