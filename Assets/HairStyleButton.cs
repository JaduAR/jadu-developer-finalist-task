using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HairStyleButton : SelectableButton {
    [SerializeField]
    TextMeshProUGUI label;

    [SerializeField]
    Image preview;

    public void SetLabel(string txt) {
        label.text = txt;
    }

    public void SetPreview(Sprite sprite) {
        preview.sprite = sprite;
    }
}
