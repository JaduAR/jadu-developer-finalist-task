using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BtHair : MonoBehaviour, IUIToggleButton
{
    public ScriptableObject buttonSO {
        get { return _hairSO; }
    }
    private HairScriptableObject _hairSO;
    [SerializeField] private Image _hairImage;
    [SerializeField] private Image _backImage;
    [SerializeField] private TextMeshProUGUI _text;


    public void Init(ScriptableObject colorSO) {
        _hairSO = colorSO as HairScriptableObject;
        _hairImage.sprite = _hairSO.sprite;
        _text.text = _hairSO.hairName;
        DeselectBt();
    }

    public void SelectBt() {
        _backImage.color = _hairSO.backgroundSelectedColor;
    }
    public void DeselectBt() {
        _backImage.color = _hairSO.backgroundColor;
    }

}
