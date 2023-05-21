using UnityEngine.UI;

/// <summary>
/// toggle icon for the skin color selection
/// </summary>
public class SkinToggle : Toggle, IGarmentUIToggle
{
    public Image icon;

    /// <summary>
    /// set up icon
    /// </summary>
    /// <param name="garment">garment info</param>
    /// <param name="toggleGroup"></param>
    /// <param name="turnOn"></param>
    public void CreateToggle(Garment garment, ToggleGroup toggleGroup,
        bool turnOn)
    {
        if(icon != null)
        {
            icon.color = garment.garementColor;
        }
        this.group = toggleGroup;
        if (turnOn)
        {
            Select();
        }
    }
}
