using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// the base class for the inventory UI window
/// </summary>
public class InventoryScrollView : MonoBehaviour
{
    /// <summary>
    /// the prefab for the icon
    /// </summary>
    public GameObject       iconPrefab;
    /// <summary>
    /// the grid
    /// </summary>
    public Transform        contentParent;
    public ToggleGroup      toggleGroup;
    Toggle _toggleTab;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="garments"></param>
    /// <param name="toggleTab"></param>
    /// <param name="show"></param>
    public void SetUp(Garment[] garments, Toggle toggleTab,
        bool show)
    {
        if(iconPrefab != null)
        {
            for (int i = 0; i < garments.Length; i++)
            {
                GameObject icon = Instantiate(iconPrefab);
                IGarmentUIToggle garmentToggle = icon.GetComponent<IGarmentUIToggle>();
                if(garmentToggle != null && toggleGroup != null)
                {
                    garmentToggle.CreateToggle(garments[i], toggleGroup,
                        i==0);
                    if(contentParent != null)
                    {
                        icon.transform.SetParent(contentParent);
                        contentParent.gameObject.SetActive(show);
                    }
                }
            }
        }
        if(toggleTab != null)
        {
            toggleTab.onValueChanged.AddListener(HideAndShowTab);
            _toggleTab = toggleTab;
        }
    }

    void HideAndShowTab(bool selected)
    {
        if(contentParent == null)
        {
            return;
        }
        contentParent.gameObject.SetActive(selected);
    }

    void OnDestroy()
    {
        if (_toggleTab != null)
        {
            _toggleTab.onValueChanged.RemoveAllListeners();
        }
    }
}
