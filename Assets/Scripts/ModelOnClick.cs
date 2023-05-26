using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelOnClick : MonoBehaviour
{
    private ScreenOneView screenOneView;
    private bool allowed = false;
    // Start is called before the first frame update
    void Awake()
    {
        screenOneView = gameObject.GetComponent<ScreenOneView>();
    }

    private void OnEnable()
    {
        screenOneView.OnModelClicked += ToggleBool;
        screenOneView.OnReturn += ToggleBool;
    }

    private void OnDisable()
    {
        screenOneView.OnModelClicked -= ToggleBool;
        screenOneView.OnReturn -= ToggleBool;
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
