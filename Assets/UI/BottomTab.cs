using TMPro;
using UnityEngine;

public class BottomTab : SelectableButton {

    [SerializeField]
    TextMeshProUGUI label;

    public void SetLabel(string txt) {
        label.text = txt;
    }
}
