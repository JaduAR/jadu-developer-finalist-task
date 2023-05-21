using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomizationTabTitle : MonoBehaviour
{
    CustomizationTabTitleManager manager;
    public TextMeshProUGUI Title;
    public TMP_FontAsset Regular;
    public TMP_FontAsset Bold;
    // Start is called before the first frame update
    void Awake()
    {
        manager = transform.parent.parent.parent.GetComponent<CustomizationTabTitleManager>();
        manager.AddCustomizationTabTitle(this);
    }

    public void SetCurrent()
    {
        manager.SetCurrentTab(this);
        Title.font = Bold;
    }

    public void UnSetCurrent()
    {
        Title.font = Regular;
    }
}
