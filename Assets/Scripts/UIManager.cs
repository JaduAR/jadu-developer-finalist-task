using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// manages UI
/// </summary>
public class UIManager : MonoBehaviour
{
    public Button                           doneButton;
    public Button                           startButton;
    public GarmentTabScriptableObject[]     garmentTabsObjects;
    public Transform                        garmentTabsParent;
    public CategoryToggle                   categoryToggle;
    public Transform                        categoryToggleParent;
    ToggleGroup                             _toggleGroup;
    float   _inventoryHiddenY               = -1000;
    List<CategoryToggle>                    _categoryToggles = new List<CategoryToggle>();
    /// <summary>
    /// animation for the inventory
    /// </summary>
    SlideInNOutPanel                        _inventoryAnimation;

    void Start()
    {
        if (doneButton !=null)
        {
            doneButton.onClick.AddListener(DoneClicked);
        }
        if(startButton != null)
        {
            startButton.onClick.AddListener(SelectSkin);
        }
        if(garmentTabsParent != null && categoryToggleParent != null
            && categoryToggle != null)
        {
            _inventoryAnimation = garmentTabsParent.gameObject.AddComponent<SlideInNOutPanel>();
            _toggleGroup = categoryToggleParent.gameObject.AddComponent<ToggleGroup>();

            for (int i = 0; i < garmentTabsObjects.Length; i++)
            {
                CategoryToggle c = Instantiate(categoryToggle);
                _categoryToggles.Add(c);
                c.transform.SetParent(categoryToggleParent);
                c.SetUp(garmentTabsObjects[i].garementType.ToString(),
                    _toggleGroup,
                    garmentTabsObjects[i].cameraPos,
                    garmentTabsObjects[i].cameraRotation,
                    _inventoryAnimation,
                    garmentTabsObjects[i].height);

                InventoryScrollView inventoryScrollView = Instantiate(garmentTabsObjects[i].InventoryScrollView);
                inventoryScrollView.gameObject.transform.SetParent(garmentTabsParent);
                inventoryScrollView.SetUp(garmentTabsObjects[i],c
                    , i==0);

                RectTransform rect = inventoryScrollView.GetComponent<RectTransform>();
                rect.SetTop(150);
                rect.SetRight(0);
            }
        }
    }

    void SelectSkin()
    {
        if(_categoryToggles.Count>0)
        {
            _categoryToggles[0].isOn = true;
            _categoryToggles[0].Show();
        }
        if (startButton != null)
        {
            startButton.gameObject.SetActive(false);
        }
        if (doneButton != null)
        {
            doneButton.gameObject.SetActive(true);
        }
    }

    void DoneClicked()
    {
        if (startButton != null)
        {
            startButton.gameObject.SetActive(true);
        }
        if(CameraAnimator.Instance)
        {
            CameraAnimator.Instance.MoveToStart();
        }
        if(_inventoryAnimation != null)
        {
            _inventoryAnimation.Animate(_inventoryHiddenY);
        }
        if(doneButton!=null)
        {
            doneButton.gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        if (doneButton != null)
        {
            doneButton.onClick.RemoveAllListeners();
        }
    }
}
