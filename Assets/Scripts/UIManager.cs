using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// manages UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public Button               doneButton;
    public InventoryScrollView  skinSelection;
    public InventoryScrollView  hairSelection;
    public Garment[]            skins;
    public Garment[]            hair;

    void Start()
    {
        if(doneButton !=null)
        {
            doneButton.onClick.AddListener(DoneClicked);
        }
        if(skinSelection != null && skins!= null)
        {
            skinSelection.CreateIcons(skins);
        }
        if (hairSelection != null && hair != null)
        {
            hairSelection.CreateIcons(hair);
        }
    }

    void DoneClicked()
    {
        
    }

    void OnDestroy()
    {
        if (doneButton != null)
        {
            doneButton.onClick.RemoveAllListeners();
        }
    }
}
