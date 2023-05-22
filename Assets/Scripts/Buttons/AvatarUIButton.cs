// ----------------------
// Onur EREREN - May 2023
// ----------------------

// Jadu UI Technical Task UI Controller
// Controls UI actions

using UnityEngine;
using TMPro;

public class AvatarUIButton : MonoBehaviour
{
    #region REFERENCES

    [SerializeField]
    private TMP_Text _buttonText;

    [SerializeField]
    private GameObject _bottomLine;

    private Color _activeColor;
    private Color _inactiveColor;

    #endregion

    #region VARIABLES

    private const float DeselectAlpha = 0.2f;

    #endregion

    #region MONOBEHAVIOUR

    private void Start()
    {
        _activeColor = _buttonText.color;
        _inactiveColor = new Color(_buttonText.color.r, _buttonText.color.g, _buttonText.color.b, DeselectAlpha);

    }

    #endregion

    #region METHODS

    public void Activate()
    {
        _buttonText.color = _activeColor;
        //_buttonText.fontStyle = FontStyles.Bold;
        _bottomLine.SetActive(true);
    }

    public void Deactivate()
    {
        _buttonText.color = _inactiveColor;
        //_buttonText.fontStyle = FontStyles.Normal;
        _bottomLine.SetActive(false);
    }


    #endregion


}
