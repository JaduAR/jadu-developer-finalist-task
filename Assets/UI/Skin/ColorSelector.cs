using UnityEngine;

public class ColorSelector : MonoBehaviour {

    [SerializeField]
    ColorButton optionPrefab;

    void Start() {
        // add buttons for all of the skin colors in Assets/Resources/SkinColors/

        ColorScriptableObject[] opts = Resources.LoadAll<ColorScriptableObject>("SkinColors/");

        foreach (ColorScriptableObject obj in opts) {
            ColorButton btn = Instantiate(optionPrefab, transform);
            btn.SetColor(obj.color);
            btn.AddListener(() => OnSelect(btn));
        }

        // select the second one by default (as in design spec)
        OnSelect(transform.GetChild(1).GetComponent<ColorButton>());
    }

    void OnSelect(ColorButton btn) {
        // update selected state for all options
        foreach (Transform t in transform) {
            ColorButton cb = t.GetComponent<ColorButton>();
            cb.SetSelected(t.gameObject == btn.gameObject);
        }
    }
}
