using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorButton : MonoBehaviour
{
    Button btn;

    public bool StartSelected;

    float startingScale;
    float shrunkScale = 0.3f;
    float animTime = 0.15f;
    void Start()
    {
        startingScale = transform.localScale.x;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        if (StartSelected)
            OnClick();
    }


    void OnClick()
    {
        ColorSelector.Instance.ColorButtonClicked(this);
    }


    public void CancelRunningTween()
    {
        LeanTween.cancel(gameObject);
    }

    public void Shrink()
    {
        LeanTween.scale(gameObject, (Vector3.one * shrunkScale), animTime);
    }
    public void Grow()
    {
        LeanTween.scale(gameObject, (Vector3.one * startingScale), animTime);
    }
}
