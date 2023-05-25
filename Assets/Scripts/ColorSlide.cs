using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlide : MonoBehaviour
{
    [SerializeField]
    private Transform thisTransform;
    private Slider thisSlide;
    // Start is called before the first frame update
    void Start()
    {
        thisSlide = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slide()
    {
        thisTransform.localPosition = new Vector3(thisSlide.value - 218f, thisTransform.localPosition.y, 0f);
    }
}
