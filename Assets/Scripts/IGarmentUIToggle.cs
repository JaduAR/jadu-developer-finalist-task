using UnityEngine.UI;
/// <summary>
/// create a toggle
/// </summary>
public interface IGarmentUIToggle 
{
    public void CreateToggle(Garment garment, ToggleGroup toggleGroup,
        bool isOn);
}
