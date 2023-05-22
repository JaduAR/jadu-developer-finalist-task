using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// code for the category toggle
/// </summary>
public class CategoryToggle : Toggle
{
    public TextMeshProUGUI  label;
    /// <summary>
    /// selected color for the label
    /// </summary>
    public Color            selectedColor;
    /// <summary>
    /// de-selected color for the label
    /// </summary>
    public Color            unSelectedColor;

    /// <summary>
    /// set up with the tab name
    /// </summary>
    /// <param name="tabName"></param>
    /// <param name="toggleGroup"></param>
    public void SetUp(string tabName, ToggleGroup toggleGroup)
    {
        if(label!=null)
        {
            label.text = tabName;
        }
        group = toggleGroup;
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        if (label != null)
        {
            label.color = unSelectedColor;
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        if (label != null)
        {
            label.color = selectedColor;
        }
    }
}
