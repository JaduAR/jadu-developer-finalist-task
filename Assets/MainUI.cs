using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    BottomPanel bottomPanel;

    [SerializeField]
    Button characterButton;
    [SerializeField]
    Button backButton;

    private void Start() {
        characterButton.onClick.AddListener(OnCharacterClicked);
        backButton.onClick.AddListener(OnBackButton);
    }

    public void OnCharacterClicked() {
        if (bottomPanel.IsHidden()) {
            backButton.gameObject.SetActive(true);
            bottomPanel.SetTab(0);
            bottomPanel.SetHidden(false);
        }
    }

    public void OnBackButton() {
        bottomPanel.SetHidden(true);
        backButton.gameObject.SetActive(false);
    }
}
