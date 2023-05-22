using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EaseLibrary;
using UnityEngine.UI;
using TechTask;

public class SkinColorButton : MonoBehaviour
{
    #region REFERENCES

    private UIController _uiController;

    #endregion

    #region VARIABLES

    private int _index;
    private float _minimizedScale;
    private float _scaleDuration ;
    private EaseType _easeType;
    private Color _buttonColor;

    #endregion



    #region METHODS

    public void SetupButton(UIController controller, int index, float minimizedScale, float scaleDuration, EaseType buttonEase, Color buttonColor)
    {
        _uiController = controller;

        _index = index; 
        _minimizedScale = minimizedScale;
        _scaleDuration = scaleDuration;
        _easeType = buttonEase;
        _buttonColor = buttonColor;

        GetComponent<Image>().color = buttonColor;
    }

    public void Activate()
    {
        StartCoroutine(ScaleButton(_minimizedScale));
        _uiController.SkinButtonClicked(_index);
    }

    public void Deactivate()
    {
        StartCoroutine(ScaleButton(1f));
    }

    #endregion

    #region COROUTINES

    private IEnumerator ScaleButton(float finalScale)
    {
        float startScale = transform.localScale.x;
        float endScale = finalScale;

        float timer = 0f;

        while (timer < _scaleDuration)
        {
            timer += Time.deltaTime;
            float lerp = timer / _scaleDuration;
            float clampedLerp = Mathf.Clamp(lerp, 0f, 1f);
            float easedLerp = KinematicEase.Evaluate(_easeType, clampedLerp);

            transform.localScale = Vector3.one * Mathf.Lerp(startScale, finalScale, easedLerp);

            yield return null;
        }

    }

    #endregion

}
