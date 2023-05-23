using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOnClick : MonoBehaviour
{
    public ScreenOneView screenOneView;
    public bool allowed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        screenOneView.OnModelClicked += ToggleBool;
        screenOneView.OnReturn += ToggleBool;
    }

    private void OnDisable()
    {
        screenOneView.OnModelClicked -= ToggleBool;
    }


    private void ToggleBool()
    {
        allowed = !allowed;
    }

    private void OnMouseDown()
    {
        if(allowed)
        {
            screenOneView.ModelClick();
        }
    }
}
