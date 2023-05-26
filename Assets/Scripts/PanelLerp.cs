using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLerp : MonoBehaviour
{
    public ScreenOneView screenOneView;
    public GameObject ScreenTwo;


    private void OnEnable()
    {
        screenOneView.OnModelClicked += PanelRise;
        screenOneView.OnReturn += PanelShrink;
    }

    private void OnDisable()
    {
        screenOneView.OnModelClicked -= PanelRise;
        screenOneView.OnReturn -= PanelShrink;

    }

    public void PanelRise()
    {
        StartCoroutine(PanelLerpRoutine(ScreenTwo, -232f, 0f, 0.3f));

    }

    public void PanelShrink()
    {

        StartCoroutine(PanelLerpRoutine(ScreenTwo, 0f, -232f, 0.3f));

    }

    IEnumerator PanelLerpRoutine(GameObject rect, float startValue, float endValue, float duration)
    {
        float time = 0;

        while (time < duration)
        {
            rect.GetComponent<RectTransform>().position = new Vector3(rect.GetComponent<RectTransform>().position.x, Mathf.Lerp(startValue, endValue, time / duration), rect.GetComponent<RectTransform>().position.z);

            time += Time.deltaTime;
            yield return null;
        }
        rect.GetComponent<RectTransform>().position = new Vector3(rect.GetComponent<RectTransform>().position.x, endValue, rect.GetComponent<RectTransform>().position.z);

    }


}
