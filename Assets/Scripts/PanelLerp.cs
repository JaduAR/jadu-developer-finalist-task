using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLerp : MonoBehaviour
{
    public ScreenOneView screenOneView;
    public GameObject ScreenTwo;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        screenOneView.OnModelClicked += PanelScreenOneToTwo;
        screenOneView.OnReturn += PanelScreenTwoToOne;
    }

    private void OnDisable()
    {
        screenOneView.OnModelClicked -= PanelScreenOneToTwo;
        screenOneView.OnReturn -= PanelScreenTwoToOne;

    }

    public void PanelScreenOneToTwo()
    {
        StartCoroutine(PanelLerpRoutine(ScreenTwo, 0f, 200f, 0.3f));

    }

    public void PanelScreenTwoToOne()
    {

        StartCoroutine(PanelLerpRoutine(ScreenTwo, 200f, 0f, 0.3f));

    }

    IEnumerator PanelLerpRoutine(GameObject rect, float startValue, float endValue, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            float scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            rect.GetComponent<RectTransform>().sizeDelta = new Vector2(0, scaleModifier);
            time += Time.deltaTime;
            yield return null;
        }
        rect.GetComponent<RectTransform>().sizeDelta = new Vector2(0, endValue);
    }


}
