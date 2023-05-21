using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BottomTab : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI label;

    public void SetLabel(string txt) {
        label.text = txt;
    }

    public void AddListener(UnityAction fn) {
        GetComponent<Button>().onClick.AddListener(fn);
    }

    public void SetSelected(bool selected) {
        GetComponent<Animator>().SetBool("Selected", selected);
    }
}
