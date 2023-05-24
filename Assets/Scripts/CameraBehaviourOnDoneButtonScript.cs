using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class CameraBehaviourOnDoneButtonScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject ZoomInCamera;
    public GameObject MainCamera;
    public RectTransform StylesUI;
    public Toggle InitToggle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Slide down UI
        
        StylesUI.DOAnchorPos(new Vector2(0, StylesUI.GetComponent<RectTransform>().rect.y*2), 1f);

        //reset UI

        InitToggle.isOn = true;

        ZoomInCamera.SetActive(false);
        MainCamera.SetActive(true);
        
    }
}
