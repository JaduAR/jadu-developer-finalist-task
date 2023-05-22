using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// toggle icon for the skin color selection
/// </summary>
public class SkinToggle : Toggle, IGarmentUIToggle
{
    public  Image           icon;
    /// <summary>
    /// the parent of all ainmated UIs
    /// </summary>
    public  RectTransform   animateTarget;
    /// <summary>
    /// scale animation duration
    /// </summary>
    float   _duration       = 0.1f;
    Vector2 _selectedSize   = new Vector2(-60, -60);
    Vector2 _unSelectedSize = new Vector2(0, 0);

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
        isOn = turnOn;
        CheckAnimation(isOn);
    }

    protected override void Start()
    {
        base.Start();
        onValueChanged.AddListener(CheckAnimation);
    }

    void CheckAnimation(bool selected)
    {
        ScaleIcon(selected? _selectedSize:_unSelectedSize);
    }

    void ScaleIcon(Vector2 size)
    {
        if(animateTarget != null)
        {
            DOTween.Complete(animateTarget);
            animateTarget.DOSizeDelta(size, _duration);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        onValueChanged.RemoveAllListeners();
    }
}
