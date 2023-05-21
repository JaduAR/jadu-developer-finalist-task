using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour {

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
        // if in overview, transition to tabs
        if (bottomPanel.IsHidden()) {
            backButton.gameObject.SetActive(true);
            bottomPanel.SetTab(0);
            bottomPanel.SetHidden(false);
        }
    }

    public void OnBackButton() {
        // transition to overview
        bottomPanel.SetHidden(true);
        backButton.gameObject.SetActive(false);
    }
}
