using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UINav : MonoBehaviour
{
    //GameObjects
    public Transform mainCamera, camera_idle, camera_skin, camera_hair, playerModel;

    //UI State Machine
    public enum NavState { IDLE, SKIN, HAIR, TRANSITION }
    public NavState currentState = NavState.IDLE;
    public NavState newState = NavState.SKIN;

    //UI Assets
    public UIDocument UI;
    Button doneButton;
    VisualElement skinColorPane;
    VisualElement hairColorPane;
    VisualElement root;

    public List<Button> skinColorButtons;
    public List<Button> hairColorButtons;

    Button selectedSkinColor;
    Button selectedHairColor;

    void Start()
    {
        skinColorPane = UI.rootVisualElement.Q("Customization_SkinColor") as VisualElement;
        hairColorPane = UI.rootVisualElement.Q("Customization_HairColor") as VisualElement;

        doneButton = UI.rootVisualElement.Q("DoneButton") as Button;
        root = UI.rootVisualElement.Q("Customization_ScreenOverlay");

        skinColorPane.Q("SkinButton").RegisterCallback<ClickEvent>(OnClickSkin);
        skinColorPane.Q("HairButton").RegisterCallback<ClickEvent>(OnClickHair);
        hairColorPane.Q("SkinButton").RegisterCallback<ClickEvent>(OnClickSkin);
        hairColorPane.Q("HairButton").RegisterCallback<ClickEvent>(OnClickHair);
        doneButton.RegisterCallback<ClickEvent>(OnClickDone);

        skinColorButtons = UI.rootVisualElement.Q("Customization_SkinColorTray").Query<Button>().ToList();
        
        foreach(Button button in skinColorButtons)
        {
            button.clicked += () => OnClickSkinColor(button);
        }

        hairColorButtons = UI.rootVisualElement.Q("Customization_HairColorTray").Query<Button>().ToList();

        foreach (Button button in hairColorButtons)
        {
            Debug.Log(button);
            button.clicked += () => OnClickHairColor(button);
        }

        skinColorPane.visible = false;
        hairColorPane.visible = false;
        doneButton.visible = false;
    }

    void Update()
    {
        switch (currentState) {
            case NavState.IDLE:
                IdleState();
                break;
            case NavState.SKIN:
                SkinColorState();
                break;
            case NavState.HAIR:
                HairColorState();
                break;
            case NavState.TRANSITION:
                TransitionState();
                break;
        }
    }

    void IdleState()
    {
        if (Input.touchCount > 0) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), camera_idle.forward, out hit))
            {
                if (hit.collider.tag == "Player")
                    ChangeState(NavState.SKIN);
            }
        }
    }

    float swipeUpGestureY;
    float swipeUpGestureEndY;
    float swipeUpThreshold = 15f;
    void SkinColorState()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Began) {
                swipeUpGestureY = Input.GetTouch(0).position.y;
                swipeUpGestureEndY = swipeUpGestureY + swipeUpThreshold; 
            }

            if (firstTouch.position.y >= swipeUpGestureEndY)
            {
                skinColorPane.visible = true;
                doneButton.visible = true;
            }
        }
    }

    void HairColorState()
    {
    }

    float stateChangeDuration = 1f;
    float stateChangeElapsed = 0f;
    Vector3 cameraAPos;
    Quaternion cameraARot;
    Vector3 cameraBPos;
    Quaternion cameraBRot;

    Vector3 PMRotIdle = new Vector3(0, 12.11f, 0);
    Vector3 PMRotCustom = new Vector3(0, -17.25f, 0);
    Quaternion PMRotA;
    Quaternion PMRotB;

    void TransitionState()
    {
        //Easing Function T*T
        float timeComplexity = (stateChangeElapsed * stateChangeElapsed) / stateChangeDuration;

        mainCamera.position = Vector3.Lerp(cameraAPos, cameraBPos, timeComplexity);
        mainCamera.rotation = Quaternion.Lerp(cameraARot, cameraBRot, timeComplexity);
        playerModel.rotation = Quaternion.Lerp(PMRotA, PMRotB, timeComplexity);

        stateChangeElapsed += Time.deltaTime;

        if (stateChangeElapsed >= stateChangeDuration)
        {
            stateChangeElapsed = 0f;
            currentState = newState;
        }
    }

    void ChangeState(NavState changeTo)
    {
        cameraAPos = mainCamera.position;
        cameraARot = mainCamera.rotation;
        PMRotA = playerModel.rotation;

        currentState = NavState.TRANSITION;
        newState = changeTo;

        switch (newState)
        {
            case NavState.IDLE:
                cameraBPos = camera_idle.position;
                cameraBRot = camera_idle.rotation;
                PMRotB = Quaternion.Euler(PMRotIdle);

                skinColorPane.visible = false;
                hairColorPane.visible = false;
                doneButton.visible = false;

                break;
            case NavState.SKIN:
                cameraBPos = camera_skin.position;
                cameraBRot = camera_skin.rotation;
                PMRotB = Quaternion.Euler(PMRotCustom);

                if (currentState == NavState.HAIR)
                {
                    skinColorPane.visible = true;
                    hairColorPane.visible = false;
                    doneButton.visible = true;
                }

                break;
            case NavState.HAIR:
                cameraBPos = camera_hair.position;
                cameraBRot = camera_hair.rotation;
                PMRotB = Quaternion.Euler(PMRotCustom);

                skinColorPane.visible = false;
                hairColorPane.visible = true;
                doneButton.visible = true;

                break;
        }
    }

    public void OnClickDone(ClickEvent evt)
    {
        ChangeState(NavState.IDLE);

        Debug.Log("Pressed");
    }

    public void OnClickSkin(ClickEvent evt)
    {

        ChangeState(NavState.SKIN);
    }
    public void OnClickHair(ClickEvent evt)
    {

        ChangeState(NavState.HAIR);
    }

    public void OnClickSkinColor(Button button)
    {
        Debug.Log(button.style.unityBackgroundImageTintColor.ToString() + " was selected.");
        
        if (selectedSkinColor != null)
            selectedSkinColor.style.scale = new Scale(Vector3.one);

        selectedSkinColor = button;
        button.style.scale = new Scale(new Vector3(0.3125f, 0.3125f, 0.3125f));
    }

    public void OnClickHairColor(Button button)
    {
        Debug.Log(button.Q<Label>().text + " was selected.");

        if (selectedHairColor != null)
        {
            selectedHairColor.style.backgroundColor = new StyleColor(Color.black);
            selectedHairColor.style.opacity = 1f;
        }

        selectedHairColor = button;

        button.style.backgroundColor = new StyleColor(new Color(29f / 255f, 30f / 255f, 33f / 255f));
        button.style.opacity = 0.5f;
    }
}
