using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    float panelHeight;  //cached value for different screen sizes
    //normalized values (how much to slide up for each screen?)
    float Screen2PanelPos = 0.6f;
    float Screen3PanelPos = 1f;     //Assume hair panel is always higher than the skin scroller

    public List<Color> SkinColors;
    public Transform ColorGroup;
    public GameObject ColorKnobPrefab;
    public float KnobDistanceFactor = 0.5f;
    public float KnobSelectedSizeFector = 0.35f;
    private List<GameObject> CurrentColorKnobs;

    public float UiSlidingInterval = 0.5f;

    [Header("UI Text Color")]
    public Color TagActive;
    public Color TagInactive;
    public Button SkinButton;
    public Button HairButton;
    public Button DoneButton;

    public Transform HairGroup;
    public GameObject HairGridPrefab;
    public float HairDistanceFactor = 0.5f;

    [Serializable]
    public struct HairData
    {
        public string Name;
        public Sprite Tex;
    }
    public List<HairData> HairGridData;
    private List<GameObject> CurrentHairGrids;

    float PanelStepAmount { get { return panelHeight * (Time.deltaTime / UiSlidingInterval); } }

    private void Start()
    {
        panelHeight = uiPanel.sizeDelta.y;
        CreateSkinColorKnobs();
        CreateHairGrids();
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
        else if (Input.GetMouseButtonDown(0) && State == CustomizerState.Screen1)   //Q:need to handle mouse click as well?
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit) && hit.collider.tag == "Player")
            {
                State = CustomizerState.InTransition;
                StartCoroutine(Screen1To2());
            }
        }

    }

    IEnumerator Screen1To2()
    {
        SkinButton.transform.GetChild(0).GetComponent<TMP_Text>().color = TagActive;
        HairButton.transform.GetChild(0).GetComponent<TMP_Text>().color = TagInactive;
        ColorGroup.parent.parent.gameObject.SetActive(true);
        HairGroup.parent.parent.gameObject.SetActive(false);

        StartCoroutine(camTrans.CamTransition(Campos2));
        //slide in the panel
        while (uiPanel.anchoredPosition.y < Screen2PanelPos * panelHeight)
        {
            uiPanel.anchoredPosition += Vector2.up * Screen2PanelPos * PanelStepAmount;
            yield return null;
        }
        while (!camTrans.TransitionDone)
        {
            yield return null;
        }

        DoneButton.gameObject.SetActive(true);
        State = CustomizerState.Screen2;
    }

    IEnumerator Screen2To3()
    {
        SkinButton.transform.GetChild(0).GetComponent<TMP_Text>().color = TagInactive;
        HairButton.transform.GetChild(0).GetComponent<TMP_Text>().color = TagActive;
        ColorGroup.parent.parent.gameObject.SetActive(false);
        HairGroup.parent.parent.gameObject.SetActive(true);
        
        StartCoroutine(camTrans.CamTransition(Campos3));
        while (uiPanel.anchoredPosition.y < Screen3PanelPos * panelHeight)
        {
            uiPanel.anchoredPosition += Vector2.up * Screen3PanelPos * PanelStepAmount;
            yield return null;
        }
        while (!camTrans.TransitionDone)
        {
            yield return null;
        }


        State = CustomizerState.Screen3;
    }

    IEnumerator Screen3To2()
    {
        SkinButton.transform.GetChild(0).GetComponent<TMP_Text>().color = TagActive;
        HairButton.transform.GetChild(0).GetComponent<TMP_Text>().color = TagInactive;
        ColorGroup.parent.parent.gameObject.SetActive(true);
        HairGroup.parent.parent.gameObject.SetActive(false);

        StartCoroutine(camTrans.CamTransition(Campos2));
        while (uiPanel.anchoredPosition.y > Screen2PanelPos * panelHeight)
        {
            uiPanel.anchoredPosition -= Vector2.up * Screen2PanelPos * PanelStepAmount;
            yield return null;
        }
        while (!camTrans.TransitionDone)
        {
            yield return null;
        }

        State = CustomizerState.Screen2;
    }

    IEnumerator ScreenToMain()
    {
        DoneButton.gameObject.SetActive(false);
        StartCoroutine(camTrans.CamTransition(CamposMain));
        float panelPos = uiPanel.anchoredPosition.y / uiPanel.sizeDelta.y;
        while (uiPanel.anchoredPosition.y > 0f)
        {
            uiPanel.anchoredPosition -= Vector2.up * Screen2PanelPos * PanelStepAmount;
            yield return null;
        }
        while (!camTrans.TransitionDone)
        {
            yield return null;
        }

        State = CustomizerState.Screen1;
    }

    private void CreateSkinColorKnobs()
    {
        CurrentColorKnobs = new List<GameObject>();
        float totalWidth = 0f;
        for (int i = 0; i < SkinColors.Count; i++)
        {
            GameObject knob = Instantiate(ColorKnobPrefab, ColorGroup);
            RectTransform knobRT = knob.GetComponent<RectTransform>();

            if (i == 0)
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

    private void CreateHairGrids()
    {

        CurrentHairGrids = new List<GameObject>();
        float totalWidth = 0f;
        for (int i = 0; i < HairGridData.Count; i++)
        {
            GameObject grid = Instantiate(HairGridPrefab, HairGroup);
            RectTransform gridRT = grid.GetComponent<RectTransform>();

            if (i == 0)
            {
                totalWidth = gridRT.sizeDelta.x * gridRT.localScale.x * (0.5f + HairDistanceFactor);
            }

            grid.GetComponent<HairGrid>().Init(HairGridData[i].Name, HairGridData[i].Tex);

            var gridComp = grid.GetComponent<HairGrid>();
            gridComp.OnGridClicked += SelectHairGrid;
            gridComp.IsSelected = false;
            gridComp.Index = i;

            //2 rows
            if (i % 2 == 0)
            {
                gridRT.anchoredPosition = Vector2.right * totalWidth - Vector2.up * gridRT.sizeDelta.y * (0.5f + HairDistanceFactor);
                totalWidth += gridRT.sizeDelta.x * gridRT.localScale.x * (1 + HairDistanceFactor);
            }
            else
            {
                gridRT.anchoredPosition = CurrentHairGrids[i - 1].GetComponent<RectTransform>().anchoredPosition - Vector2.up * gridRT.sizeDelta.y * (1 + HairDistanceFactor);
            }


            CurrentHairGrids.Add(grid);
        }
        HairGroup.GetComponent<RectTransform>().sizeDelta *= Vector2.up;       //zero out the width
        HairGroup.GetComponent<RectTransform>().sizeDelta += Vector2.right * totalWidth;    //calculate the actual width
    }

    void SelectHairGrid(HairGrid grid)
    {
        if (grid.IsSelected)
        {
            return;
        }

        foreach (var knobObj in CurrentHairGrids)
        {
            var refGrid = knobObj.GetComponent<HairGrid>();
            if (refGrid.Index == grid.Index)
            {
                refGrid.SetSelected(true);
            }
            else
            {
                refGrid.SetSelected(false);
            }
        }
    }

    //UI Functions
    public void HairButtonClicked()
    {
        if(State == CustomizerState.Screen2)
        {
            State = CustomizerState.InTransition;
            StartCoroutine(Screen2To3());
        }
    }

    public void SkinButtonClicked()
    {
        if (State == CustomizerState.Screen3)
        {
            State = CustomizerState.InTransition;
            StartCoroutine(Screen3To2());
        }
    }

    public void DoneButtonClicked()
    {
        if (State == CustomizerState.Screen3 || State == CustomizerState.Screen2)
        {
            State = CustomizerState.InTransition;
            StartCoroutine(ScreenToMain());
        }
    }
}
