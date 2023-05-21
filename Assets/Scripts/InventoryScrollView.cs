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

    public void CreateIcons(Garment[] garments)
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
                    }
                }
            }
        }
    }
}
