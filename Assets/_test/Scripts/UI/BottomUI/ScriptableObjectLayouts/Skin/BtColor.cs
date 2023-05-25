using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtColor : MonoBehaviour, IUIToggleButton {

    public ScriptableObject buttonSO {
        get { return _colorSO; }
    }
    private ColorScriptableObject _colorSO;
    [SerializeField] private Image _image;
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }
    public void Init(ScriptableObject colorSO) {
        _colorSO = colorSO as ColorScriptableObject;
        _image.color = _colorSO.color;

    }

    public void SelectBt() {
        _animator.SetBool("Selected", true);
    }
    public void DeselectBt() {
        _animator.SetBool("Selected", false);
    }
    public Color GetColor() {
        return _colorSO.color;
    }
}
