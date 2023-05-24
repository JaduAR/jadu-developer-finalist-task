using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinColorButtonController : MonoBehaviour
{
    private Button[] buttonList;
    private Button activeButton;
    private Color defaultColor = new Color(1.0f,1.0f,1.0f,1.0f);
    private Color grayColor = new Color(1.0f,1.0f,1.0f,0.5f);

    // Start is called before the first frame update
    void Start()
    {
        buttonList = gameObject.GetComponentsInChildren<Button>();
        int buttonIndex = 0;
        foreach(Button button in buttonList){
            int temp = buttonIndex;
            button.onClick.AddListener(delegate {ToggleButtonState(temp); });
            Color randomColor = 
                new Color(
                    Random.Range(0.75f,1.0f),
                    Random.Range(0.75f,1.0f),
                    Random.Range(0.75f,1.0f),
                    1.0f);
            button.transform.GetChild(0).gameObject.GetComponent<Image>().color = Random.ColorHSV();
            buttonIndex++;
        }
    }

    private void ToggleButtonState(int buttonIndex){
        if(activeButton){
                activeButton.transform.GetChild(0).localScale = new Vector3(1.0f, 1.0f, 1.0f);
                activeButton = null;
        }
        buttonList[buttonIndex].transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f, 1.0f);
        activeButton = buttonList[buttonIndex];
    }

}
