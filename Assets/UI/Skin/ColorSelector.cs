using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorSelector : MonoBehaviour {

    [SerializeField]
    ColorButton optionPrefab;

    void Start() {
        ColorScriptableObject[] opts = Resources.LoadAll<ColorScriptableObject>("SkinColors/");

        foreach (ColorScriptableObject obj in opts) {
            ColorButton btn = Instantiate(optionPrefab, transform);
            btn.SetColor(obj.color);
            btn.AddListener(() => OnSelect(btn));
        }

        OnSelect(transform.GetChild(1).GetComponent<ColorButton>());
    }

    void OnSelect(ColorButton btn) {
        foreach (Transform t in transform) {
            ColorButton cb = t.GetComponent<ColorButton>();
            cb.SetSelected(t.gameObject == btn.gameObject);
        }
    }
}
