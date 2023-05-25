using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizerManager : MonoBehaviour
{
    public enum CustomizerState
    { 
        InTransition,
        Screen1, 
        Screen2,
        Screen3,
    }

    public CustomizerState State;
    public Transform CamposMain;
    public Transform Campos2;
    public Transform Campos3;

    [SerializeField]
    CameraTransition camTrans;

    [SerializeField]
    RectTransform uiPanel;

    public List<Color> SkinColors;
    public Transform ColorGroup;
    public GameObject ColorKnobPrefab;
    public float KnobDistanceFactor = 0.5f;
    public float KnobSelectedSizeFector = 0.35f;
    private List<GameObject> CurrentColorKnobs;

    
    private void Start()
    {
        CreateSkinColorKnobs();    
    }

    private void Update()
    {
        if(State == CustomizerState.InTransition) 
        {
            return;
        }

        //handle player touch input
        if(Input.touchCount > 0)
        {
            // Screen1: On avatar tap: transition to Screen 2
            if(State == CustomizerState.Screen1)
            {
                Touch t = Input.GetTouch(0);
                Ray r = Camera.main.ScreenPointToRay(t.position);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit) && hit.collider.tag == "Player")
                {
                    State = CustomizerState.InTransition;
                    StartCoroutine(Screen1To2());
                }
            }

        }

    }

    IEnumerator Screen1To2()
    {
        StartCoroutine(camTrans.CamTransition(Campos2));
        while(!camTrans.TransitionDone)
        {
            yield return null;
        }

        //slide in the panel
        while(uiPanel.anchoredPosition.y < uiPanel.sizeDelta.y)
        {
            uiPanel.anchoredPosition += Vector2.up * uiPanel.sizeDelta.y * Time.deltaTime * 2f;
            yield return null;
        }

        State = CustomizerState.Screen2;
    }

    private void CreateSkinColorKnobs()
    {
        CurrentColorKnobs = new List<GameObject>();
        float totalWidth = 0f;
        for(int i = 0; i < SkinColors.Count; i++)
        {
            GameObject knob = Instantiate(ColorKnobPrefab, ColorGroup);
            RectTransform knobRT = knob.GetComponent<RectTransform>();

            if(i == 0)
            {
                totalWidth = knobRT.sizeDelta.x * knobRT.localScale.x * (0.5f + KnobDistanceFactor);
            }

            knobRT.anchoredPosition = Vector2.right * totalWidth;
            knob.GetComponent<Image>().color = SkinColors[i];
            totalWidth += knobRT.sizeDelta.x * knobRT.localScale.x * (1 + KnobDistanceFactor);

            var knobComp = knob.GetComponent<ColorKnob>();
            knobComp.OnKnobClicked += SelectColorKnob;
            knobComp.IsSelected = false;
            knobComp.Index = i;

            CurrentColorKnobs.Add(knob);
        }
        ColorGroup.GetComponent<RectTransform>().sizeDelta *= Vector2.up;       //zero out the width
        ColorGroup.GetComponent<RectTransform>().sizeDelta += Vector2.right * totalWidth;    //calculate the actual width
    }

    void SelectColorKnob(ColorKnob knob)
    {
        if(knob.IsSelected)
        {
            return;
        }

        foreach (var knobObj in CurrentColorKnobs)
        {
            var refKnob = knobObj.GetComponent<ColorKnob>();
            if (refKnob.Index == knob.Index)
            {
                refKnob.IsSelected = true;
                refKnob.GetComponent<RectTransform>().localScale = new Vector3(KnobSelectedSizeFector, KnobSelectedSizeFector, 1);
            }
            else
            {
                refKnob.IsSelected = false;
                refKnob.GetComponent<RectTransform>().localScale = Vector3.one;
            }
        }
    }


    //UI Functions
    public void HairButtonClicked()
    {
        print("HAIR");
    }
}
