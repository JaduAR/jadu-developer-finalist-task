using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairStyleSelector : MonoBehaviour {
    [SerializeField]
    HairStyleButton optionPrefab;

    void Start() {
        HairStyleScriptableObject[] opts = Resources.LoadAll<HairStyleScriptableObject>("HairStyles/");

        foreach (HairStyleScriptableObject obj in opts) {
            HairStyleButton btn = Instantiate(optionPrefab, transform);
            btn.SetLabel(obj.label);
            btn.SetPreview(obj.preview);
            btn.AddListener(() => OnSelect(btn));
        }

        OnSelect(transform.GetChild(0).GetComponent<HairStyleButton>());
    }

    void OnSelect(HairStyleButton btn) {
        foreach (Transform t in transform) {
            HairStyleButton cb = t.GetComponent<HairStyleButton>();
            cb.SetSelected(t.gameObject == btn.gameObject);
        }
    }
}
