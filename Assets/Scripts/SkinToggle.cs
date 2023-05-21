using UnityEngine.UI;

/// <summary>
/// toggle icon for the skin color selection
/// </summary>
public class SkinToggle : Toggle, IGarmentUIToggle
{
    public Image icon;

    public void CreateToggle(Garment garment, ToggleGroup toggleGroup)
    {
        if(icon != null)
        {
            icon.color = garment.garementColor;
        }
        this.group = toggleGroup;
    }
}
