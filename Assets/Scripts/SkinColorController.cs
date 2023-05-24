using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinColorController : MonoBehaviour
{
    public Color[] colors;
    public Transform colorList;
    public GameObject buttonPrefab;

    void Start()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            GameObject button = Instantiate(buttonPrefab, colorList);
            button.GetComponent<Image>().color = colors[i];
            button.GetComponent<Button>().onClick.AddListener(() => SelectColor(button));
        }
        SelectColor(colorList.GetChild(1).gameObject);
    }

    public void SelectColor(GameObject clicked)
    {
        ResetSelection();
        clicked.GetComponent<Animator>().SetBool("selected", true);
        // TODO: change character skin color
    }

    void ResetSelection()
    {
        for (int i = 0; i < colorList.childCount; i++)
        {
            colorList.GetChild(i).GetComponent<Animator>().SetBool("selected", false);
        }
    }
}
