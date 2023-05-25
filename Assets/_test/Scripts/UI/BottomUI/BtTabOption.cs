using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtTabOption : MonoBehaviour
{
    [SerializeField] private ScreenController.ScreenOrder _myScreen;

    private Button _button;


    private void Start() {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(delegate { ScreenController.Instance.SelectScreen(_myScreen); });
    }

}
