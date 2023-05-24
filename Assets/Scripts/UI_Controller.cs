using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    //Reference to the main camera object for transitions
    [SerializeField]
    private GameObject main_cam;

    //State change interactables
    [SerializeField]
    private GameObject go_button_done;
    private Button bu_button_done;

    [SerializeField]
    private Button bu_avatar_select;

    [SerializeField]
    private GameObject ui_interaction_menu;
    private GameObject go_skin_button;
    private Button bu_skin_button;
    private GameObject go_hair_button;
    private Button bu_hair_button;

    //Skin selection menu items
    [SerializeField]
    private Scrollbar sb_skin_options;
    private bool is_scrolling_options;
    private Vector3 prev_mouse_position;
    [SerializeField]
    private GameObject selected_skin;

    //Hair selection menu items
    [SerializeField]
    private GameObject go_hair_options;
    [SerializeField]
    private GameObject selected_hair;
    [SerializeField]
    private Sprite sp_background_gray;
    [SerializeField]
    private Sprite sp_background_black;
    [SerializeField]
    private Font ft_regular;
    [SerializeField]
    private Font ft_bold;

    //Different menu states
    private enum scene_states {
        avatar_view = 0,
        avatar_skin = 1,
        avatar_hair = 2,
    }
    private scene_states current_scene_state;

    [SerializeField]
    private float state_transition_time;
    private float state_transition_timer_current = 0;

    //Preset positions for each element for each state
    //Order of Vectors is:                                     main camera position,  main camera rotation (Euler angles),        UI interaction menu position,    done button position
    private Vector3[] avatar_view_positions = new Vector3[] { new Vector3(0.105f, 0.765f, 1.02f),  new Vector3(0, 185f, 0), new Vector3(Screen.width/2, -225f, 0), new Vector3(Screen.width-50f, Screen.height+100f, 0) };
    private Vector3[] avatar_skin_positions = new Vector3[] { new Vector3(-0.115f, 0.99f, 0.418f), new Vector3(0, 170f, 0),   new Vector3(Screen.width/2, 25f, 0), new Vector3(Screen.width-50f, Screen.height-40f, 0) };
    private Vector3[] avatar_hair_positions = new Vector3[] { new Vector3(-0.138f, 0.96f, 0.5f),  new Vector3(0, 170f, 0),   new Vector3(Screen.width/2, 100f, 0), new Vector3(Screen.width-50f, Screen.height-40f, 0) };
    private List<Vector3[]> preset_positions;

    // Start is called before the first frame update
    void Start()
    {
        preset_positions = new List<Vector3[]>();
        preset_positions.Add(avatar_view_positions);
        preset_positions.Add(avatar_skin_positions);
        preset_positions.Add(avatar_hair_positions);

        //Assign dependent references
        bu_button_done = go_button_done.GetComponent<Button>();
        go_skin_button = ui_interaction_menu.transform.Find("Button_Skin").gameObject;
        bu_skin_button = go_skin_button.GetComponent<Button>();
        go_hair_button = ui_interaction_menu.transform.Find("Button_Hair").gameObject;
        bu_hair_button = go_hair_button.GetComponent<Button>();

        //Create listeners for UI interaction
        bu_avatar_select.onClick.AddListener(delegate { ChangeUIState(1); } );
        bu_button_done.onClick.AddListener(delegate { ChangeUIState(0); } );
        bu_skin_button.onClick.AddListener(delegate { ChangeUIState(1); } );
        bu_hair_button.onClick.AddListener(delegate { ChangeUIState(2); } );
    }

    // Update is called once per frame
    void Update()
    {
        if(state_transition_timer_current > 0) {
            state_transition_timer_current -= Time.deltaTime;
        } else {
            if((int)current_scene_state == 1) {
                //Watch for mouse input in the scrollbar region
                if(Input.GetMouseButtonUp(0)) {
                    is_scrolling_options = false;
                } if(is_scrolling_options) {
                    sb_skin_options.value = Mathf.Clamp(sb_skin_options.value + ((Input.mousePosition.x - prev_mouse_position.x) / Screen.width), 0, 1);
                    prev_mouse_position = Input.mousePosition;
                } else if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < 150 && Input.mousePosition.y > 50) {
                    is_scrolling_options = true;
                    prev_mouse_position = Input.mousePosition;
                }
            }
        }
    }

    //Selecting skin color options
    public void SelectSkinOption(GameObject invoking_button) {
        if(invoking_button != selected_skin) {
            selected_skin.transform.localScale = new Vector3(1, 1, 1);
            invoking_button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            selected_skin = invoking_button;
        }
    }

    //Selecting hair style options
    public void SelectHairOption(GameObject invoking_button) {
        Debug.Log("Button pressed for hair - "+invoking_button.name);
        if(invoking_button != selected_hair) {
            selected_hair.transform.GetChild(0).GetComponent<Image>().sprite = sp_background_black;
            Text selected_text = selected_hair.transform.GetChild(2).GetComponent<Text>();
            selected_text.font = ft_regular;
            selected_text.color = new Color(0.725f, 0.725f, 0.725f);

            invoking_button.transform.GetChild(0).GetComponent<Image>().sprite = sp_background_gray;
            Text invoking_text = invoking_button.transform.GetChild(2).GetComponent<Text>();
            invoking_text.font = ft_bold;
            invoking_text.color = new Color(1, 1, 1);

            selected_hair = invoking_button;
        }
    }

    //Revert to main camera and UI to avatar view state
    private void ChangeUIState(int target_state) {
        //Check if there is currently a state transition underway
        if(state_transition_timer_current > 0) { return; }

        int from_state = (int)current_scene_state;

        //Begin lerping all transitions
        StartCoroutine(LerpTargetPosition(preset_positions[from_state][0], preset_positions[target_state][0], main_cam.transform));
        StartCoroutine(LerpTargetRotation(preset_positions[from_state][1], preset_positions[target_state][1], main_cam.transform));
        StartCoroutine(LerpTargetPosition(preset_positions[from_state][2], preset_positions[target_state][2], ui_interaction_menu.transform));
        StartCoroutine(LerpTargetPosition(preset_positions[from_state][3], preset_positions[target_state][3], go_button_done.transform));

        //Set the timer for lerps to complete and new state variables
        state_transition_timer_current = state_transition_time;
        current_scene_state = (scene_states)target_state;
        
        //Enable / Disable appropriate interfaces for this state
        bu_avatar_select.interactable = target_state == 0;
        if(target_state == 1) { //Skin selection
            sb_skin_options.gameObject.SetActive(true);
            go_skin_button.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1, 1, 1);
            go_hair_options.SetActive(false);
            go_hair_button.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f);
        } else if(target_state == 2) { //Hair selection
            sb_skin_options.gameObject.SetActive(false);
            go_skin_button.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f);
            go_hair_options.SetActive(true);
            go_hair_button.transform.GetChild(0).gameObject.GetComponent<Text>().color = new Color(1, 1, 1);
        }
    }

    private IEnumerator LerpTargetPosition(Vector3 start_position, Vector3 end_position, Transform target_transform) {
        float elapsed_time = 0;
        float lerp_time = 1.25f;
        while(elapsed_time < lerp_time) {
            target_transform.position = Vector3.Lerp(start_position, end_position, elapsed_time / lerp_time);
            elapsed_time += Time.deltaTime;
            yield return null;
        }
        target_transform.position = end_position;
    }

    private IEnumerator LerpTargetRotation(Vector3 start_rotation, Vector3 end_rotation, Transform target_transform) {
        float elapsed_time = 0;
        while(elapsed_time < state_transition_time) {
            target_transform.eulerAngles = Vector3.Lerp(start_rotation, end_rotation, elapsed_time / state_transition_time);
            elapsed_time += Time.deltaTime;
            yield return null;
        }
        target_transform.eulerAngles = end_rotation;
    }
}
