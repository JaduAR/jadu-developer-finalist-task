using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// implement UI for the hair toggle
/// </summary>
public class HairToggle : Toggle, IGarmentUIToggle
{
    public Image            icon;
    public TextMeshProUGUI  titleText;
    /// <summary>
    /// selected color for the label
    /// </summary>
    public Color            selectedColor;
    /// <summary>
    /// de-selected color for the label
    /// </summary>
    public Color            unSelectedColor;

    protected override void Start()
    {
        base.Start();
        onValueChanged.AddListener(FadeOutUI);
    }

    void FadeOutUI(bool selected)
    {
        if(!selected)
        {
            if (titleText != null)
            {
                titleText.color = unSelectedColor;
            }
            if (icon != null)
            {
                icon.color = Color.white;
            }
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (titleText != null)
        {
            titleText.color = selectedColor;
        }
        if(icon != null)
        {
            icon.color = new Color(1, 1, 1, 0.2f);
        }    
    }

    public void CreateToggle(Garment garment, ToggleGroup toggleGroup,
        bool turnOn)
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
        if(turnOn)
        {
            Select();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        onValueChanged.RemoveAllListeners();
    }
}
