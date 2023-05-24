using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorScrollView : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform content;

    private Transform[] colorTransforms = new Transform[20];
    private void Start() {
        for (int i = 0; i < colorTransforms.Length; i++) {
            colorTransforms[i] = Instantiate(prefab, content).transform;
            var tr = colorTransforms[i];
            tr.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            tr.GetComponent<Button>().onClick.AddListener(delegate { SetPressedScale(tr); });
        }
        
    }

    public void SetPressedScale(Transform _transform) {
        for (int i = 0; i < colorTransforms.Length; i++) {
            colorTransforms[i].localScale = Vector3.one;
        }
        _transform.localScale = Vector3.one * 0.7f;
    }
}
