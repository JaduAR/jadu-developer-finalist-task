using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairOptionController : MonoBehaviour
{
    public HairOption[] hairOptions;
    public Transform optionList;
    public GameObject buttonPrefab;

    void Start()
    {
        for (int i = 0; i < hairOptions.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, optionList);
            button.GetComponentInChildren<HairOptionRow>().Init(hairOptions[i]);
            button.GetComponent<Button>().onClick.AddListener(() => SelectHair(button));
        }
        SelectHair(optionList.GetChild(0).gameObject);
    }

    public void SelectHair(GameObject clicked)
    {
        ResetSelection();
        clicked.GetComponent<Animator>().SetBool("selected", true);
        // TODO: change character hair
    }

    void ResetSelection()
    {
        for (int i = 0; i < optionList.childCount; i++)
        {
            optionList.GetChild(i).GetComponent<Animator>().SetBool("selected", false);
        }
    }
}

[System.Serializable]
public class HairOption
{
    public Sprite sprite;
    public string label;
}
