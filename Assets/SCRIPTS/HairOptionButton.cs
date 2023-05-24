using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JaduTest;

public class HairOptionButton : MonoBehaviour
{
    private HairOption Opt;

    [Header("UI References")]
    public Image ButtonImage;
    public TextMeshProUGUI ButtonLabel;
    Animator m_anim;

    private void Start()
    {
        CustomizationManager.Instance.HairOptionSet.AddListener(UpdateSelection);
    }

    /// <summary>Set the option data for this button and adjust the UI accordingly</summary>
    /// <param name="data"> Hair Option to set to</param>
    public void SetData(HairOption data)
    {
        Opt = data;
        ButtonImage.sprite = Opt.Icon;
        ButtonLabel.text = Opt.ID;
        m_anim = GetComponent<Animator>();
        UpdateSelection();
    }

    /// <summary>Selects this scripts linked hair option and sends it to the Customization manager</summary>
    public void SelectOption()
    {
        CustomizationManager.Instance.SetHairOption(Opt);
    }

    /// <summary>Updates the selection state of the button</summary>
    public void UpdateSelection()
    {
        if (CustomizationManager.Instance.HairOptions[CustomizationManager.Instance.currenthairselection] == Opt)
        {
            m_anim.SetBool("SelectionOverride", true);
        }
        else
        {
            m_anim.SetBool("SelectionOverride", false);
        }
    }
}
