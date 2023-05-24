using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorButton : SelectableButton {

    public Color GetColor() => GetComponent<Image>().color;

    public void SetColor(Color col) {
        GetComponent<Image>().color = col;
    }
}
