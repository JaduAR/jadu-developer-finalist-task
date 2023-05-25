using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CustomizerAnimator : MonoBehaviour
{
    [Header("UI")]
    public float UIMoveTime = 0.6f;
    public GameObject MainPanel;
    public GameObject TargetNone;
    public GameObject TargetSkin;
    public GameObject TargetHair;
    
    

    public GameObject DoneButton;
    public GameObject TargetDone_Hidden;
    public GameObject TargetDone_Shown;

    float DoneButtonHeightChange =100;

    public GameObject CharacterButton;
    public GameObject SkinPanel;
    public GameObject HairPanel;

    public GameObject BarMarker;
    public GameObject TargetBar_Skin;
    public GameObject TargetBar_Hair;

    public TMP_Text SkinText;
    public TMP_Text HairText;
    public Color TextSelected;
    Color TextDeselected;

    [Header("Camera")]
    public GameObject Camera;
    public GameObject CameraPosition_None;
    public GameObject CameraPosition_Skin;
    public GameObject CameraPosition_Hair;
    public float CameraMoveTime = 1f;
    public LeanTweenType CameraEase;

    private void Awake()
    {
        LeanTween.reset();
    }

    private void Start()    
    {
        TextDeselected = SkinText.color;
        DoneButton.transform.position = TargetDone_Hidden.transform.position;
        MainPanel.transform.position = TargetNone.transform.position;
       
    }

    public void GoToScreenNone()
    {
        CharacterButton.SetActive(true);
        GoToTarget(DoneButton,TargetDone_Hidden, 0.2f);
        GoToTarget(MainPanel, TargetNone);
        GoToTargetWithRotation(Camera, CameraPosition_None);
    }

    public void GoToScreenSkin()
    {
        CharacterButton.SetActive(false);
        SkinPanel.SetActive(true);
        HairPanel.SetActive(false);
        GoToTarget(DoneButton, TargetDone_Shown, 0.2f);
        GoToTarget(MainPanel, TargetSkin);
        GoToTargetWithRotation(Camera, CameraPosition_Skin);
        GoToTargetX(BarMarker, TargetBar_Skin);

        LeanTween.value(0, 1, UIMoveTime).setOnUpdate((float val) => {
            SkinText.color = Color.Lerp(TextDeselected, TextSelected, val);
            HairText.color = Color.Lerp(TextSelected, TextDeselected, val);
        
        });
    }

    public void GoToScreenHair()
    {
        CharacterButton.SetActive(false);
        SkinPanel.SetActive(false);
        HairPanel.SetActive(true);
        GoToTarget(DoneButton, TargetDone_Shown,0.2f);
        GoToTarget(MainPanel, TargetHair);
        GoToTargetWithRotation(Camera, CameraPosition_Hair);
        GoToTargetX(BarMarker, TargetBar_Hair);

        LeanTween.value(1, 0, UIMoveTime).setOnUpdate((float val) => {
            SkinText.color = Color.Lerp(TextDeselected, TextSelected, val);
            HairText.color = Color.Lerp(TextSelected, TextDeselected, val);

        });
    }

    LTDescr GoToTarget(GameObject obj,GameObject target, float addedTime = 0)
    {
        LeanTween.cancel(obj);
        return LeanTween.move(obj, target.transform.position, UIMoveTime+addedTime);
    }

    void GoToTargetX(GameObject obj, GameObject target)
    {
        LeanTween.cancel(obj);
        LeanTween.moveX(obj,target.transform.position.x, UIMoveTime);
    }

    void GoToTargetWithRotation(GameObject obj, GameObject target)
    {
        LeanTween.cancel(obj);
        LeanTween.move(obj, target.transform.position, CameraMoveTime).setEase(CameraEase);
        LeanTween.rotate(obj, target.transform.rotation.eulerAngles, CameraMoveTime).setEase(CameraEase);
    }
    void GoToPosition(GameObject obj, Vector3 targetPos)
    {
        LeanTween.cancel(obj);
        LeanTween.move(obj, targetPos, UIMoveTime);
    }


}
