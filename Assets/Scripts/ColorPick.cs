using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPick : MonoBehaviour
{
    [SerializeField]
    private int thisColor;
    [SerializeField]
    private UIManager theMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickThis()
    {
        theMan.SelectColor(thisColor);
    }
}
