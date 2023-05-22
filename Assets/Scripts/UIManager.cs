using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// manages UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public Button                           doneButton;
    public GarmentTabScriptableObject[]     garmentTabsObjects;
    public Transform                        garmentTabsParent;

    void Start()
    {
        if(doneButton !=null)
        {
            doneButton.onClick.AddListener(DoneClicked);
        }
        if(garmentTabsParent != null)
        {
            for (int i = 0; i < garmentTabsObjects.Length; i++)
            {
                InventoryScrollView inventoryScrollView = Instantiate(garmentTabsObjects[i].InventoryScrollView);
                inventoryScrollView.gameObject.transform.SetParent(garmentTabsParent);
                inventoryScrollView.CreateIcons(garmentTabsObjects[i].garments);

                RectTransform rect = inventoryScrollView.GetComponent<RectTransform>();
                rect.SetTop(150);
                rect.SetRight(0);
            }
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
