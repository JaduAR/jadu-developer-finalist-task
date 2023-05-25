using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairStyleUIController : BottomUILayout {

    [SerializeField]private List<HairScriptableObject> _hairList;

    protected override void ChangeAvatar(IUIToggleButton uiButton) {

        HairScriptableObject hairSO = uiButton.buttonSO as HairScriptableObject;
        Debug.Log($"Pressed hair button for {hairSO.hairName}");
        //MyAvatar.ChangeHairStyle(hairSO);
    }

    protected override List<ScriptableObject> SetupSOList() {
        _soList = new List<ScriptableObject>();
        _soList.AddRange(_hairList);
        return _soList;
    }
}
