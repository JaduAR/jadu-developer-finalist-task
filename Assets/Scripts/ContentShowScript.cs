using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContentShowScript : MonoBehaviour
{
    public Toggle _toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeShow()
    {
            this.gameObject.SetActive(_toggle.isOn);
    }
}
