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
    Vector3                 _cameraPos;
    Vector3                 _cameraRot;
    SlideInNOutPanel        _inventoryAnimation;
    /// <summary>
    /// end Y position for the tab
    /// </summary>
    float                   _endY;

    /// <summary>
    /// set up with the tab with infos
    /// </summary>
    /// <param name="tabName"></param>
    /// <param name="toggleGroup"></param>
    /// <param name="cameraPos"></param>
    /// <param name="cameraRot"></param>
    public void SetUp(string tabName, ToggleGroup toggleGroup,
        Vector3 cameraPos, Vector3 cameraRot,
         SlideInNOutPanel inventoryAnimation,
         float endY)
    {
        _endY = endY;
        _inventoryAnimation = inventoryAnimation;
        _cameraPos = cameraPos;
        _cameraRot = cameraRot;
        if (label!=null)
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

    /// <summary>
    /// easy in the panel and animate the camera
    /// </summary>
    public void Show()
    {
        CameraAnimator.Instance.AnimateCamera(_cameraRot,
                _cameraPos);
        if (_inventoryAnimation != null)
        {
            _inventoryAnimation.Animate(_endY);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        Show();
    }
}
