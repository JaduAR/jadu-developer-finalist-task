using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorButton : SelectableButton {

    public Color GetColor() => GetComponent<Image>().color;

    public void SetColor(Color col) {
        GetComponent<Image>().color = col;
    }
}
