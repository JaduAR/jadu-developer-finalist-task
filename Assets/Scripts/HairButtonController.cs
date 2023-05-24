using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HairButtonController : MonoBehaviour
{
    private Button[] buttonList;
    private Button activeButton;
    private Color defaultColor = new Color(1.0f,1.0f,1.0f,1.0f);
    private Color grayColor = new Color(1.0f,1.0f,1.0f,0.5f);

    public List<HairType> hairTypes;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private GameObject hairButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PopulateButtons();
    }

    private void PopulateButtons(){
        foreach(HairType hair in hairTypes){
            GameObject hairObj = Instantiate(hairButtonPrefab, buttonContainer);
            hairObj.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = hair.name;
            hairObj.transform.GetChild(2).gameObject.GetComponent<RawImage>().texture = hair.previewImage.texture;
        }
        buttonList = gameObject.GetComponentsInChildren<Button>();
        int buttonIndex = 0;
        foreach(Button button in buttonList){
            int temp = buttonIndex;
            button.onClick.AddListener(delegate {ToggleButtonState(temp); });
            buttonIndex++;
        }
    }

    private void ToggleButtonState(int buttonIndex){
        if(activeButton){
            activeButton.transform.GetChild(0).gameObject.SetActive(false);
            activeButton.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            activeButton.transform.GetChild(2).gameObject.GetComponent<RawImage>().color = defaultColor;
            activeButton = null;
        }

        buttonList[buttonIndex].transform.GetChild(0).gameObject.SetActive(true);
        buttonList[buttonIndex].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
        buttonList[buttonIndex].transform.GetChild(2).gameObject.GetComponent<RawImage>().color = grayColor;
        
        activeButton = buttonList[buttonIndex];
    }

}
