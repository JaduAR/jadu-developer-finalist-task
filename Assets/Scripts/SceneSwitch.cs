using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneSwitch : MonoBehaviour
{
    public Transform[] camTransforms;
    public GameObject body;
    public GameObject canvas;
    public RectTransform menuRectTransform;
    Vector3 menuPosition;
    public GameObject menuButtons;
    public TextMeshProUGUI skinButtonText;
    public TextMeshProUGUI hairButtonText;
    public Image skinButtonIndicator;
    public Image hairButtonIndicator;
    public GameObject hairBar;
    public GameObject skinBar;
    public GameObject Backgrounds;
    float ButtonHeight1;
    float ButtonHeight2;
    float BackgroundHeight1;
    float BackgroundHeight2;
    int scene = 0;


    void Start()
    {
        SetCameraCanvasButton(0);
        canvas.SetActive(false);
        menuPosition = new Vector3(0, 0, 0);
        ButtonHeight1 = -226f;
        ButtonHeight2 = -135f;
        BackgroundHeight1 = -306f;
        BackgroundHeight2 = -251f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && scene == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.name == "Body")
                {
                    SetCameraCanvasButton(1);
                    StartCoroutine(ShowMenu());
                }

            }
        }
    }

    IEnumerator ShowMenu()
    {
        // Slide Menu
        float speed = 2000f;
        while (menuRectTransform.localPosition.y - menuPosition.y < 0) {
            menuRectTransform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }
    }

    public void SetCameraCanvasButton(int i)
    {
        // Set Scene
        scene = i;

        // Set Camera
        Camera.main.transform.position = camTransforms[i].position;
        Camera.main.transform.rotation = camTransforms[i].rotation;

        // Set Canvas and Button
        if (i == 0)
        {
            canvas.SetActive(false);
        }
        else if (i == 1)
        {
            canvas.SetActive(true);
            skinBar.SetActive(true);
            hairBar.SetActive(false);
            SetButtonColor(1);
            Vector3 currPosition = menuButtons.GetComponent<RectTransform>().localPosition;
            menuButtons.GetComponent<RectTransform>().localPosition = new Vector3(currPosition.x, ButtonHeight1, currPosition.z);
            currPosition = Backgrounds.GetComponent<RectTransform>().localPosition;
            Backgrounds.GetComponent<RectTransform>().localPosition = new Vector3(currPosition.x, BackgroundHeight1, currPosition.z);

        }
        else if (i == 2)
        {
            canvas.SetActive(true);
            skinBar.SetActive(false);
            hairBar.SetActive(true);
            SetButtonColor(2);
            Vector3 currPosition = menuButtons.GetComponent<RectTransform>().localPosition;
            menuButtons.GetComponent<RectTransform>().localPosition = new Vector3(currPosition.x, ButtonHeight2, currPosition.z);
            currPosition = Backgrounds.GetComponent<RectTransform>().localPosition;
            Backgrounds.GetComponent<RectTransform>().localPosition = new Vector3(currPosition.x, BackgroundHeight2, currPosition.z);
        }

    }

    void SetButtonColor(int i)
    {
        Debug.Log("changecolor");
        Color activateColor = new Color(1, 1, 1, 1);
        Color inactiveColor = new Color(0.6f, 0.63f, 0.67f, 0.8f);
        if (i == 1)
        {
            skinButtonText.color = activateColor;
            skinButtonIndicator.color = activateColor;
            hairButtonText.color = inactiveColor;
            hairButtonIndicator.color = inactiveColor;
        }
        else
        {
            hairButtonText.color = activateColor;
            hairButtonIndicator.color = activateColor;
            skinButtonText.color = inactiveColor;
            skinButtonIndicator.color = inactiveColor;
        }
    }

}
