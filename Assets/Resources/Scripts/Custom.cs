using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Custom : MonoBehaviour
{
    private class CameraState
    {
        private float ViewportHeight;
        public Vector3 position;
        public Quaternion rotation;
        public GameObject UIElement;

        public static int CurrentStateID;
        public static bool CameraTransitionInProgress;

        public CameraState(float height, Vector3 pos, Quaternion rot, GameObject UI = null)
        {
            ViewportHeight = height;
            position = pos;
            rotation = rot;
            UIElement = UI;
        }

        public static IEnumerator CameraTransition(int DesiredCameraState)
        {
            CameraTransitionInProgress = true;

            bool IsDone = false;
            float ViewportHeight = 0f;

            GameObject pnlMaster = GameObject.Find("Canvas").transform.Find("pnlMaster").gameObject;

            Camera MainCam = MainCamGO.GetComponent<Camera>();
            Camera UICam = UICamGO.GetComponent<Camera>();

            UIActivation(pnlMaster, DesiredCameraState);

            while (!IsDone)
            {
                MainCamGO.transform.position = Vector3.Lerp(MainCamGO.transform.position, CameraStates[DesiredCameraState].position, 20f * Time.deltaTime);
                MainCamGO.transform.rotation = Quaternion.Lerp(MainCamGO.transform.rotation, CameraStates[DesiredCameraState].rotation, 20f * Time.deltaTime);

                ViewportHeight = Mathf.Lerp(MainCam.rect.height, CameraStates[DesiredCameraState].ViewportHeight, 20f * Time.deltaTime);

                MainCam.rect = new Rect(0, 1f - ViewportHeight, 1, ViewportHeight);
                UICam.rect = new Rect(0, 0, 1, 1f - ViewportHeight);

                pnlMaster.transform.localPosition = new Vector3(pnlMaster.transform.localPosition.x, -(ReferenceResolution.y / 2) + (UICam.rect.height * ReferenceResolution.y) / 2, pnlMaster.transform.localPosition.z);
                pnlMaster.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, UICam.rect.height * ReferenceResolution.y);

                if ((float)System.Math.Round(MainCamGO.transform.position.x, 1) == (float)System.Math.Round(CameraStates[DesiredCameraState].position.x, 1) &&
                    (float)System.Math.Round(MainCamGO.transform.position.y, 1) == (float)System.Math.Round(CameraStates[DesiredCameraState].position.y, 1) &&
                    (float)System.Math.Round(MainCamGO.transform.position.z, 1) == (float)System.Math.Round(CameraStates[DesiredCameraState].position.z, 1) &&
                    (float)System.Math.Round(MainCamGO.transform.rotation.eulerAngles.x, 1) == (float)System.Math.Round(CameraStates[DesiredCameraState].rotation.eulerAngles.x, 1) &&
                    (float)System.Math.Round(MainCamGO.transform.rotation.eulerAngles.y, 1) == (float)System.Math.Round(CameraStates[DesiredCameraState].rotation.eulerAngles.y, 1) &&
                    (float)System.Math.Round(MainCamGO.transform.rotation.eulerAngles.z, 1) == (float)System.Math.Round(CameraStates[DesiredCameraState].rotation.eulerAngles.z, 1))
                    IsDone = true;

                yield return new WaitForSeconds(0.01f);
            }

            if (DesiredCameraState == 0)
                pnlTabs.SetActive(false);

            CameraTransitionInProgress = false;
            yield return null;
        }

        public static void UIActivation(GameObject pnlMaster, int DesiredCameraState)
        {
            foreach (Transform child in pnlMaster.transform)
                child.gameObject.SetActive(false);

            if (DesiredCameraState != 0)
            {
                CameraStates[DesiredCameraState].UIElement.SetActive(true);
                btnDone.SetActive(true);
            }
            else
                btnDone.SetActive(false);

            if (DesiredCameraState == 1)
            {
                pnlTabs.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
                pnlTabs.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
            else if (DesiredCameraState == 2)
            {
                pnlTabs.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                pnlTabs.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
            }

            pnlTabs.SetActive(true);
        }
    }

    private class SkinColor
    {
        public string Name;
        public Color32 color;

        public static int SelectedIndex = 0;

        public SkinColor(string name, Color32 col)
        {
            Name = name;
            color = col;
        }
    }

    private class HairStyle
    {
        public string Name;
        public Sprite sprite;

        public static int SelectedIndex = 0;

        public HairStyle(string name, Sprite sp)
        {
            Name = name;
            sprite = sp;
        }
    }

    private static GameObject Character;
    private static GameObject MainCamGO;
    private static GameObject UICamGO;
    private static GameObject Canvas;
    private static GameObject pnlTabs;
    private static GameObject btnDone;

    private static Vector2 ReferenceResolution;

    private static List<CameraState> CameraStates = new List<CameraState>();
    private static List<HairStyle> HairStyles = new List<HairStyle>();
    private static List<SkinColor> SkinColors = new List<SkinColor>();

    private void Start()
    {
        Character = GameObject.Find("Bloomborne");
        MainCamGO = GameObject.Find("Main Camera");
        UICamGO = GameObject.Find("UI Camera");
        Canvas = GameObject.Find("Canvas");
        btnDone = Canvas.transform.Find("btnDone").gameObject;
        pnlTabs = Canvas.transform.Find("pnlMaster").Find("pnlTabs").gameObject;

        btnDone.SetActive(false);
        pnlTabs.SetActive(false);

        ReferenceResolution = Canvas.GetComponent<CanvasScaler>().referenceResolution;

        SetupEventTriggers();
        PopulateSkinColors();
        PopulateHairStyles();
        PopulateCameraStates();
    }

    private void ChangeCameraState(int NewState)
    {
        if (CameraState.CameraTransitionInProgress)
            StopAllCoroutines();

        StartCoroutine(CameraState.CameraTransition(NewState));

        CameraState.CurrentStateID = NewState;
    }

    private void SetupEventTriggers()
    {
        //Character OnClick Triggers
        EventTrigger trigger = Character.transform.Find("Body").AddComponent<EventTrigger>();
        EventTrigger.Entry OnClick = new EventTrigger.Entry();
        OnClick.eventID = EventTriggerType.PointerClick;
        OnClick.callback.AddListener((data) => ChangeCameraState(1));
        trigger.triggers.Add(OnClick);

        trigger = Character.transform.Find("Hair").AddComponent<EventTrigger>();
        OnClick = new EventTrigger.Entry();
        OnClick.eventID = EventTriggerType.PointerClick;
        OnClick.callback.AddListener((data) => ChangeCameraState(2));
        trigger.triggers.Add(OnClick);

        //Button OnClick Triggers
        Button btn = pnlTabs.transform.Find("btnSkin").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => ChangeCameraState(1));

        btn = pnlTabs.transform.Find("btnHair").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => ChangeCameraState(2));

        btn = Canvas.transform.Find("btnDone").gameObject.GetComponent<Button>();
        btn.onClick.AddListener(() => ChangeCameraState(0));
    }

    private void PopulateSkinColors()
    {
        SkinColors.Add(new SkinColor("Light Blue", new Color32(69, 169, 201, 255)));
        SkinColors.Add(new SkinColor("Dark Blue", new Color32(69, 98, 201, 255)));
        SkinColors.Add(new SkinColor("Light Pink", new Color32(255, 215, 246, 255)));
        SkinColors.Add(new SkinColor("Pink", new Color32(227, 181, 214, 255)));
        SkinColors.Add(new SkinColor("Dark Pink", new Color32(192, 149, 180, 255)));
        SkinColors.Add(new SkinColor("Brown", new Color32(180, 157, 122, 255)));
        SkinColors.Add(new SkinColor("Tan", new Color32(175, 147, 104, 255)));

        CreateSkinColorBtns();
    }

    private void CreateSkinColorBtns()
    {
        GameObject ContentRect = Canvas.transform.Find("pnlMaster").Find("pnlSkin").Find("ViewPort").Find("ContentRect").gameObject;

        GameObject ButtonPrefab = Resources.Load<GameObject>("UI Elements/btnSkin");

        for (int i = 0; i < SkinColors.Count; i++)
        {
            GameObject btnSkinColor = Instantiate(ButtonPrefab, ContentRect.transform);

            Image img = btnSkinColor.GetComponent<Image>();
            img.color = SkinColors[i].color;

            int x = i;

            Button btn = btnSkinColor.GetComponent<Button>();
            btn.onClick.AddListener(() => SkinColorSelection(x));
        }

        ContentRect.transform.localPosition += new Vector3(ContentRect.GetComponent<RectTransform>().rect.width / 2, 0, 0);

        Canvas.transform.Find("pnlMaster").Find("pnlSkin").gameObject.SetActive(false);
    }

    private void PopulateHairStyles()
    {
        foreach (Sprite sprite in Resources.LoadAll<Sprite>("Textures/HairStyles"))
            HairStyles.Add(new HairStyle(sprite.name, sprite));

        CreateHairStyleBtns();
    }

    private void CreateHairStyleBtns()
    {
        GameObject pnlHair = Canvas.transform.Find("pnlMaster").Find("pnlHair").gameObject;

        GameObject ButtonPrefab = Resources.Load<GameObject>("UI Elements/btnHairStyle");

        for (int i = 0; i < HairStyles.Count; i++)
        {
            GameObject btnHairStyle = Instantiate(ButtonPrefab, pnlHair.transform);

            int x = i;

            Button btn = btnHairStyle.GetComponent<Button>();
            btn.onClick.AddListener(() => HairStyleSelection(x));

            Image img = btnHairStyle.transform.Find("Image").GetComponent<Image>();
            img.sprite = HairStyles[i].sprite;

            btnHairStyle.transform.Find("Text").gameObject.GetComponent<Text>().text = HairStyles[i].Name;

            btnHairStyle.transform.Find("Mask").gameObject.SetActive(false);
        }

        pnlHair.SetActive(false);
    }

    private void PopulateCameraStates()
    {
        CameraStates.Add(new CameraState(1, new Vector3(4.75f, 0.8f, 3.5f), Quaternion.Euler(10, 10, 0)));
        CameraStates.Add(new CameraState(0.75f, new Vector3(5.17f, 1, 4.4f), Quaternion.Euler(0, 340, 0), Canvas.transform.Find("pnlMaster").Find("pnlSkin").gameObject));
        CameraStates.Add(new CameraState(0.75f, new Vector3(5.17f, 1, 4.4f), Quaternion.Euler(0, 340, 0), Canvas.transform.Find("pnlMaster").Find("pnlHair").gameObject));
    }

    private void SkinColorSelection(int Index)
    {
        GameObject ContentRect = Canvas.transform.Find("pnlMaster").Find("pnlSkin").Find("ViewPort").Find("ContentRect").gameObject;

        //Reset previously selected button
        GameObject PreviouslySelected = ContentRect.transform.GetChild(SkinColor.SelectedIndex).gameObject;

        PreviouslySelected.transform.localScale = new Vector3(1, 1, 1);

        GameObject SelectedButton = ContentRect.transform.GetChild(Index).gameObject;

        SelectedButton.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        SkinColor.SelectedIndex = Index;
    }

    private void HairStyleSelection(int Index)
    {
        GameObject pnlHair = Canvas.transform.Find("pnlMaster").Find("pnlHair").gameObject;

        //Reset previously selected button
        GameObject PreviouslySelected = pnlHair.transform.GetChild(HairStyle.SelectedIndex).gameObject;

        PreviouslySelected.transform.Find("Mask").gameObject.SetActive(false);

        GameObject SelectedButton = pnlHair.transform.GetChild(Index).gameObject;

        SelectedButton.transform.Find("Mask").gameObject.SetActive(true);

        HairStyle.SelectedIndex = Index;
    }
}
