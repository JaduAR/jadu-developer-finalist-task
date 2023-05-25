using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorUIController : BottomUILayout {

    [SerializeField] private List<ColorScriptableObject> _colorList;

    private AdjustableHorizontalLayout _horizontalLayoutGroup;


    protected override void Awake() {
        base.Awake();
        _horizontalLayoutGroup = _buttonsParent.GetComponent<AdjustableHorizontalLayout>();
    }

    protected override void OnEnable() {
        _horizontalLayoutGroup.CalculateLayoutInputHorizontal();
        _horizontalLayoutGroup.AdjustLayoutHorizontal();

        base.OnEnable();
    }

    protected override void ChangeAvatar(IUIToggleButton uiButton) {

        ColorScriptableObject colorSO = uiButton.buttonSO as ColorScriptableObject;
        Debug.Log($"Pressed color button id {colorSO.id}");
        //MyAvatar.ChangeSkinColor(colorSO);
    }

    protected override List<ScriptableObject> SetupSOList() {
        _soList = new List<ScriptableObject>();
        _soList.AddRange(_colorList);
        return _soList;
    }
}
