using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinColorBehaviourScript : MonoBehaviour//IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // Start is called before the first frame update

    public Toggle _toggle;
    public Image Color;
    void Start()
    {
        _toggle= this.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        //Color.rectTransform.sizeDelta= new Vector2(50,50);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("out");
        //Color.rectTransform.sizeDelta = new Vector2(100, 100);
    }

    public void ToggleBehaviour()
    {
        if (_toggle.isOn)
        {
            Color.rectTransform.sizeDelta = new Vector2(10, 10);
        }
        else
            Color.rectTransform.sizeDelta = new Vector2(32, 32);

    }
}
