using UnityEngine;
using UnityEngine.UI;
using JaduTest;

public class SkinOptionButton : MonoBehaviour
{
    private SkinOption Opt;

    [Header("UI References")]
    public Image ButtonImage;

    Animator m_anim;

    private void Start()
    {    
        CustomizationManager.Instance.SkinOptionSet.AddListener(UpdateSelection);
    }

    //Set the option data for this button and adjust the UI accordingly
    public void SetData(SkinOption data)
    {
        Opt = data;
        ButtonImage.color = Opt.GetColor();
        m_anim = GetComponent<Animator>();
        UpdateSelection();
    }

    /// <summary>Selects this scripts linked skin option and sends it to the Customization manager</summary>
    public void SelectOption()
    {
        CustomizationManager.Instance.SetSkinOption(Opt);
    }

    /// <summary>Updates the selection state of the button</summary>
    public void UpdateSelection()
    {
        if(CustomizationManager.Instance.SkinOptions[CustomizationManager.Instance.currentskinselection] == Opt)
        {
            m_anim.SetBool("SelectionOverride",true);
        }
        else
        {
            m_anim.SetBool("SelectionOverride", false);
        }
    }
}
