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
    public CategoryToggle                   categoryToggle;
    public Transform                        categoryToggleParent;
    ToggleGroup                             _toggleGroup;
    void Start()
    {
        if(doneButton !=null)
        {
            doneButton.onClick.AddListener(DoneClicked);
        }
        if(garmentTabsParent != null && categoryToggleParent != null
            && categoryToggle != null)
        {
            _toggleGroup = categoryToggleParent.gameObject.AddComponent<ToggleGroup>();
            for (int i = 0; i < garmentTabsObjects.Length; i++)
            {
                CategoryToggle c = Instantiate(categoryToggle);
                c.transform.SetParent(categoryToggleParent);
                c.SetUp(garmentTabsObjects[i].garementType.ToString(),
                    _toggleGroup);

                InventoryScrollView inventoryScrollView = Instantiate(garmentTabsObjects[i].InventoryScrollView);
                inventoryScrollView.gameObject.transform.SetParent(garmentTabsParent);
                inventoryScrollView.SetUp(garmentTabsObjects[i].garments,c
                    , i==0);

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
