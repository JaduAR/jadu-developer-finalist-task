
using UnityEngine;

public interface IUIToggleButton {

    ScriptableObject buttonSO { get; }
    void Init(UnityEngine.ScriptableObject so);
    void SelectBt();
    void DeselectBt();
}
