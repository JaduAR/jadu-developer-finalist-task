using TMPro;
using UnityEngine.UI;

/// <summary>
/// implement UI for the hair toggle
/// </summary>
public class HairToggle : Toggle, IGarmentUIToggle
{
    public Image            icon;
    public TextMeshProUGUI  titleText;

    public void CreateToggle(Garment garment, ToggleGroup toggleGroup)
    {
        if(icon != null && garment.UIImage != null)
        {
            icon.sprite = garment.UIImage;
        }
        if(titleText != null)
        {
            titleText.text = garment.garmentName;
        }
        this.group = toggleGroup;
    }
}
