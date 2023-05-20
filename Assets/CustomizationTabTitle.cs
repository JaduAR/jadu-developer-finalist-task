using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomizationTabTitle : MonoBehaviour
{
    CustomizationTabTitleManager manager;
    public TextMeshProUGUI title;
    public TMP_FontAsset Regular;
    public TMP_FontAsset Bold;
    // Start is called before the first frame update
    void Awake()
    {
        manager = transform.parent.parent.parent.GetComponent<CustomizationTabTitleManager>();
        manager.AddCustomizationTabTitle(this);

        print(manager);
        //title.font = 
    }
public void SetCurrent()
    {
        manager.SetCurrentTab(this);
        title.font = Bold;
    }
    public void UnSetCurrent()
    {
        title.font = Regular;
    }
}
