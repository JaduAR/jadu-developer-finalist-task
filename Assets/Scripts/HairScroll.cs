using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HairScroll : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public Color pressedColor;
    public Color normalColor;
    public Transform content;
    
    private Transform[] hairTransforms = new Transform[20];
    
    public void Start() {
        for (int i = 0; i < hairTransforms.Length; i++) {
            hairTransforms[i] = Instantiate(prefab, content).transform;
            var tr = hairTransforms[i];
            tr.GetComponent<Button>().onClick.AddListener(delegate { SetPressed(tr); });
        }
    }
    
    public void SetPressed(Transform _transform) {
        for (int i = 0; i < hairTransforms.Length; i++) {
            hairTransforms[i].GetChild(0).GetComponent<RawImage>().color = pressedColor;
            hairTransforms[i].GetChild(1).GetComponent<TextMeshProUGUI>().color = normalColor;
        }

        _transform.GetChild(0).GetComponent<RawImage>().color = normalColor;
        _transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = pressedColor;
    }
}
