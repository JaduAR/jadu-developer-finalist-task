using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class SizeLerp : MonoBehaviour, IDeselectHandler
{
    private Button button;
    private float timeToLerp = 0.1f;
    float scaleModifier = 1;
    private bool selected;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Shrink);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Normalize()
    {
        if(selected)
        {
            StartCoroutine(LerpGrow());
            selected = false;
        }
    }

    public void Shrink()
    {
        if(!selected)
        {
            StartCoroutine(LerpSize(0.25f, timeToLerp));
            selected = true;
        }

    }

    IEnumerator LerpSize(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale * endValue;
    }

    IEnumerator LerpGrow()
    {
        float time = 0;
        Vector3 startScale = Vector3.one;
        while (time < timeToLerp)
        {
            scaleModifier = Mathf.Lerp(0.25f, 1f, time / timeToLerp);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.one;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Normalize();
    }
}
