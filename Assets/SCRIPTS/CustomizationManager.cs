using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JaduTest;
using UnityEngine.Events;

public class CustomizationManager : MonoBehaviour
{
    [Header("Skin Customizer")]
    public int currentskinselection = 0;
    public Transform SkinContainer;
    public List<SkinOption> SkinOptions = new List<SkinOption>();

    [Header("Hair Customizer")]
    public int currenthairselection = 0;
    public Transform HairContainer;
    public List<HairOption> HairOptions = new List<HairOption>();

    [HideInInspector]
    public UnityEvent SkinOptionSet;

    [HideInInspector]
    public UnityEvent HairOptionSet;

    public static CustomizationManager Instance { get; set; }

    //Instatiate singleton upon awake for script references
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        LoadMenuOptions();
    }

    /// <summary>Builds the Menu options from the preset option list. (Note: can change to dynamic based on available assets if neccessary)</summary>
    void LoadMenuOptions()
    {
        foreach(SkinOption opt in SkinOptions)
        {
            GameObject newbutton = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/SkinOptionButton"), SkinContainer);
            newbutton.transform.GetComponent<SkinOptionButton>().SetData(opt);
        }
        foreach (HairOption opt in HairOptions)
        {
            GameObject newbutton = GameObject.Instantiate(Resources.Load<GameObject>("UIPrefabs/HairOptionButton"), HairContainer);
            newbutton.transform.GetComponent<HairOptionButton>().SetData(opt);
        }    
    }

    /// <summary>Sets the value of the Skin option menu and invokes the skin set event</summary>
    /// <param name="opt"> Skin Option to set to</param>
    public void SetSkinOption(SkinOption opt)
    {
        currentskinselection = SkinOptions.IndexOf(opt);
        //**NOTE: Change Skin Color Logic would be inserted here
        SkinOptionSet.Invoke();
    }

    /// <summary>Sets the value of the Hair option menu and invokes the hair set event</summary>
    /// <param name="opt"> Hair Option to set to</param>
    public void SetHairOption(HairOption opt)
    {
        currenthairselection = HairOptions.IndexOf(opt);
        //**NOTE: Change Hair Logic would be inserted here
        HairOptionSet.Invoke();
    }

}

