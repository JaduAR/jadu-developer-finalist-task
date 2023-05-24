using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




public class StyleButtonsBehaviourScript : MonoBehaviour
{

    public RectTransform StylesButtons;
    public bool item;
    // Start is called before the first frame update
    void Start()
    {
        item = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUpStyleButtons()
    {
        if (item) {
            StylesButtons.DOAnchorPos(new Vector2(0, 50), .1f);
        } 
        item = false;
        
    }

    public void MovedownStyleButtons()
    {
        if (!item)
        {
            StylesButtons.DOAnchorPos(new Vector2(0, -50), .1f);
        }
        item = true;
    }
}
