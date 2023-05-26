using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HairItemButton : MonoBehaviour
{
    [SerializeField] GameObject selectedRoot = null;
    [SerializeField] GameObject unselectedRoot = null;


    [SerializeField] Sprite previewSprite = null;
    [SerializeField] string itemName = null;
    [SerializeField] Image[] itemSpriteObj = null;
    [SerializeField] TextMeshProUGUI[] itemNameObj = null;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            itemSpriteObj[i].sprite = previewSprite;
            itemNameObj[i].text = itemName;
        }
    }

    public void SetActivate(bool isEnabled)
    {
        selectedRoot.SetActive(isEnabled);
        unselectedRoot.SetActive(!isEnabled);
    }
}
