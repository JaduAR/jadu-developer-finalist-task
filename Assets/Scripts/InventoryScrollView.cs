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
    public GameObject           iconPrefab;
    /// <summary>
    /// the grid
    /// </summary>
    public Transform            contentParent;
    public ToggleGroup          toggleGroup;
    Toggle                      _toggleTab;
    /// <summary>
    /// keeps info about the tab
    /// </summary>
    GarmentTabScriptableObject  _tabObj;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="garments"></param>
    /// <param name="toggleTab"></param>
    /// <param name="show"></param>
    public void SetUp(GarmentTabScriptableObject tabObj, Toggle toggleTab,
        bool show)
    {
        _tabObj = tabObj;
        if (iconPrefab != null)
        {
            for (int i = 0; i < tabObj.garments.Length; i++)
            {
                GameObject icon = Instantiate(iconPrefab);
                IGarmentUIToggle garmentToggle = icon.GetComponent<IGarmentUIToggle>();
                if(garmentToggle != null && toggleGroup != null)
                {
                    garmentToggle.CreateToggle(tabObj.garments[i], toggleGroup,
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
        if(_tabObj!= null && CameraAnimator.Instance != null && selected)
        {
            CameraAnimator.Instance.AnimateCamera(_tabObj.cameraRotation,
                _tabObj.cameraPos);
        }
    }

    void OnDestroy()
    {
        if (_toggleTab != null)
        {
            _toggleTab.onValueChanged.RemoveAllListeners();
        }
    }
}
