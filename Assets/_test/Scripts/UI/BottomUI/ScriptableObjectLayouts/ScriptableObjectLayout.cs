using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BottomUILayout : MonoBehaviour, IBottomUILayout {

    public Action<IUIToggleButton> OnClickLayoutButton;

    [SerializeField] protected GameObject _btPrefab;
    protected List<ScriptableObject> _soList;
    [SerializeField] protected Transform _buttonsParent;
    private IUIToggleButton _selectedButton;

    protected abstract void ChangeAvatar(IUIToggleButton btLayout);
    protected abstract List<ScriptableObject> SetupSOList();

    protected virtual void Awake() {
        PopulateLayout();
        OnClickLayoutButton += SelectButton;
        OnClickLayoutButton += ChangeAvatar;
    }
    protected virtual void OnEnable() {

        if (_selectedButton != null) {
            SelectButton(_selectedButton);
        }
    }
    protected virtual void OnDestroy() {
        OnClickLayoutButton -= SelectButton;
        OnClickLayoutButton -= ChangeAvatar;
    }

    protected virtual void PopulateLayout() {
        _soList = SetupSOList();

        foreach (ScriptableObject so in _soList) {
            GameObject go = Instantiate(_btPrefab, _buttonsParent);
            go.GetComponent<IUIToggleButton>().Init(so);

            go.GetComponent<Button>().onClick.AddListener(delegate { OnClickLayoutButton(go.GetComponent<IUIToggleButton>()); });
        }
    }

    

    public virtual void SelectButton(IUIToggleButton btLayout) {
        _selectedButton?.DeselectBt();
        btLayout.SelectBt();
        _selectedButton = btLayout;
    }

    
}
