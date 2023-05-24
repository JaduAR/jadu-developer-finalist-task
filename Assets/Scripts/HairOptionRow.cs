using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HairOptionRow : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI label;

    public void Init(HairOption option)
    {
        image.sprite = option.sprite;
        label.text = option.label;
    }
}
