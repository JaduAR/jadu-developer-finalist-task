using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance;

    public GameObject[] Screens;
    public GameObject[] CameraStates;
    public bool CanInteractWithModel = true;

    [Header("Skin Data")]
    public GameObject SkinUI;
    public Transform Content;
    public float SelectedColorSize = 0.31f;
    public float Duration = 0.4f;

    [Header("Hair Data")]
    public GameObject HairUI;
    public Color DefaultTextColor;
    public Transform HairStyleContent;
    public float ColorScalingDuration = 0.3f;




    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        CanInteractWithModel = true;
    }

    public void EnableCameraState(int index)
    {
        for (int i = 1; i < CameraStates.Length; i++)
        {
            CameraStates[i].SetActive(false);
        }
        CameraStates[index].SetActive(true);
    }
    public void EnableModelAttraction(bool value)
    {
        CanInteractWithModel = value;
    }
    public void ApplyColor(GameObject SelectedObject)
    {
        ResizeAll();
        SelectedObject.GetComponent<RectTransform>().DOScale(SelectedColorSize, ColorScalingDuration);
    }
    public void EnableEffectOnClick(int index)
    {
        foreach (Transform StyleItem in HairStyleContent.transform)
        {
            StyleItem.GetComponent<StyleItem>().SelectedStyleEffect.SetActive(false);
            StyleItem.GetComponent<StyleItem>().StyleName.color = DefaultTextColor;
        }
        HairStyleContent.transform.GetChild(index).GetComponent<StyleItem>().SelectedStyleEffect.SetActive(true);
        HairStyleContent.transform.GetChild(index).GetComponent<StyleItem>().StyleName.color = Color.white;
    }
    private void ResizeAll()
    {
        foreach (Transform Coloritem in Content.transform)
        {
            Coloritem.GetChild(0).GetComponent<RectTransform>().DOScale(1, ColorScalingDuration);
        }
    }
    public void SkinSlideManager(float Value)
    {
        SlideUI(SkinUI, Value);
    }
    public void HairSlideManager(float Value)
    {
        SlideUI(HairUI, Value);
    }
    private void SlideUI(GameObject Screen, float value)
    {
        Screen.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, value, 0), Duration).SetEase(Ease.InOutBack); 
    }
}
