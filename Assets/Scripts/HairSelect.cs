using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSelect : MonoBehaviour
{
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

    public void SelectHair()
    {
        theMan.SetHair();
    }
}
