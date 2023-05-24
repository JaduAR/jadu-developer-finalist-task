using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CameraBehaviourOnAvatarScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject MainCamera;
    public GameObject ZoomInCamera;
    public RectTransform StylesUI;


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
        Debug.Log("111");

        StylesUI.gameObject.SetActive(true);
        StylesUI.DOAnchorPos(Vector2.zero, 1f);

        MainCamera.SetActive(false);
        ZoomInCamera.SetActive(true);

       

    }
}
