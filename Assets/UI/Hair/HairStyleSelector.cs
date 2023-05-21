using UnityEngine;

public class HairStyleSelector : MonoBehaviour {

    [SerializeField]
    HairStyleButton optionPrefab;

    void Start() {
        // add buttons for all of the hair styles in Assets/Resources/HairStyles/

        HairStyleScriptableObject[] opts = Resources.LoadAll<HairStyleScriptableObject>("HairStyles/");

        foreach (HairStyleScriptableObject obj in opts) {
            HairStyleButton btn = Instantiate(optionPrefab, transform);
            btn.SetLabel(obj.label);
            btn.SetPreview(obj.preview);
            btn.AddListener(() => OnSelect(btn));
        }

        // select the first one by default (as in design spec)
        OnSelect(transform.GetChild(0).GetComponent<HairStyleButton>());
    }

    void OnSelect(HairStyleButton btn) {
        // update selected state for all options
        foreach (Transform t in transform) {
            HairStyleButton cb = t.GetComponent<HairStyleButton>();
            cb.SetSelected(t.gameObject == btn.gameObject);
        }
    }
}
