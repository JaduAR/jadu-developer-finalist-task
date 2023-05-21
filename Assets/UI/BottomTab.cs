using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BottomTab : SelectableButton {

    [SerializeField]
    TextMeshProUGUI label;

    public void SetLabel(string txt) {
        label.text = txt;
    }
}
