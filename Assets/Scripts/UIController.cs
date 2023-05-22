// ----------------------
// Onur EREREN - May 2023
// ----------------------

// Jadu UI Technical Task UI Controller
// Controls UI actions


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EaseLibrary;
using System;

namespace TechTask
{

    public class UIController : MonoBehaviour
    {
        #region DECLARATIONS

        #region Component References

        private CameraController _cameraController;
        private SkinColorPicker _skinColorPicker;
        private HairStylePicker _hairStylePicker;

        #endregion

        [Header("DRAWERS")]
        [SerializeField]
        private Transform _topDrawer;
        
        [SerializeField] 
        private Transform _bottomDrawer;

        [Header("DRAWER POSITIONS")]
        [Space(5)]

        [SerializeField]
        private Transform[] _topDrawerPositions;

        [SerializeField]
        private Transform[] _bottomDrawerPositions;

        [Header("MISC")]
        [SerializeField]
        private GameObject _fullScreenButton;


        [SerializeField]
        private GameObject _skinColorButtonPrefab;

        [SerializeField]
        private RectTransform _skinScrollContent;


        [SerializeField]
        private GameObject _hairStyleButtonPrefab;

        [SerializeField]
        private RectTransform _hairScrollContent;

        private SkinColorButton[] _skinColorButtons;

        private HairStyleButton[] _hairStyleButtons;

        [SerializeField]
        private float _menuChangeDuration;

        [SerializeField]
        private EaseType _easeType;

        [SerializeField]
        private int _skinButtonSize;
        [SerializeField]
        private int _skinButtonGap;
        [SerializeField]
        private float _skinButtonSelectedScale;
        [SerializeField]
        private float _skinButtonScaleDuration;

        [SerializeField]
        private int _hairButtonSize;
        [SerializeField]
        private int _hairButtonGap;

        private const int HairStyleColumns = 3;

        [SerializeField]
        private GameObject _skinColorParent;

        [SerializeField]
        private GameObject _hairStyleParent;

        #endregion

        #region EVENTS

        public event Action<Color> OnSkinColorChanged;
        public event Action<int> OnHairStyleChanged;

        #endregion

        #region MONOBEHAVIOUR

        private void Start()
        {
            _cameraController = GetComponent<CameraController>();
            _skinColorPicker = GetComponent<SkinColorPicker>();
            _hairStylePicker = GetComponent<HairStylePicker>();

            SetupSkinColorBar();
            SetupHairStyleWindow();
        }



        #endregion


        #region METHODS

        #region Setup Skin and Hair Windows

        private void SetupSkinColorBar()
        {
            SkinColorPalette colorPalette = _skinColorPicker.skinPalette;
            int numberOfButtons = colorPalette.SkinColors.Length;

            float contentWidth = numberOfButtons * (_skinButtonSize + _skinButtonGap) + _skinButtonGap;
            _skinScrollContent.sizeDelta = new Vector2(contentWidth, _skinScrollContent.sizeDelta.y);

            _skinColorButtons = new SkinColorButton[numberOfButtons];

            for (int i=0; i<numberOfButtons; i++) 
            {
                GameObject newSkinButton = Instantiate(_skinColorButtonPrefab, _skinScrollContent);
                
                SkinColorButton skinButtonScript = newSkinButton.GetComponent<SkinColorButton>();
                skinButtonScript.SetupButton(this, i, _skinButtonSelectedScale, _skinButtonScaleDuration, _easeType, colorPalette.SkinColors[i]);

                _skinColorButtons[i] = skinButtonScript;

            }

            _skinColorButtons[LastSelectedSkinButton()].Activate();
        }

        private void SetupHairStyleWindow()
        {
            int numberOfButtons = _hairStylePicker.HairStyles.Length;

            int numberOfRows = (numberOfButtons / HairStyleColumns) + (numberOfButtons % HairStyleColumns) == 0 ? 0 : 1;

            float contentHeight = numberOfRows * (_hairButtonSize +_hairButtonGap) + _hairButtonGap;
            _hairScrollContent.sizeDelta = new Vector2(_hairScrollContent.sizeDelta.x, contentHeight);

            _hairStyleButtons = new HairStyleButton[numberOfButtons];

            for (int i=0; i<numberOfButtons; ++i)
            {
                GameObject newHairButton = Instantiate(_hairStyleButtonPrefab, _hairScrollContent);

                HairStyleButton hairButtonScript = newHairButton.GetComponent<HairStyleButton>();
                HairStyle currentStyle = _hairStylePicker.HairStyles[i];
                hairButtonScript.SetupButton(this, i, currentStyle.StyleSprite, currentStyle.StyleName);

                _hairStyleButtons[i] = hairButtonScript;
            }

            _hairStyleButtons[LastSelectedHairButton()].Activate();
        }

        #endregion

        #region UI Button Click Methods

        public void MoveToAvatarView()
        {
            ToggleFullScreenButton(true);
            MoveTopDrawer(1);
            MoveBottomDrawer(2);
            _cameraController.MoveCamera(0);
        }

        public void MoveToSkinColorView()
        {
            ToggleFullScreenButton(false);
            MoveTopDrawer(0);
            MoveBottomDrawer(1);
            ToggleSkinBarParent(true);
            ToggleHairStyleParent(false);
            _cameraController.MoveCamera(1);

        }

        public void MoveToHairStyleView()
        {
            ToggleFullScreenButton(false);
            MoveTopDrawer(0);
            MoveBottomDrawer(0);
            ToggleSkinBarParent(false);
            ToggleHairStyleParent(true);
            _cameraController.MoveCamera(2);
        }

        #endregion

        #region Button Click Calls

        public void SkinButtonClicked(int index)
        {
            for (int i=0; i<_skinColorButtons.Length; i++)
            {
                if (i != index)
                {
                    _skinColorButtons[i].Deactivate();
                }
            }

            RecordSelectedSkinButton(index);

            OnSkinColorChanged?.Invoke(_skinColorPicker.skinPalette.SkinColors[index]);
        }

        public void HairButtonClicked(int index)
        {
            for (int i=0; i < _hairStyleButtons.Length; i++)
            {
                if (i != index)
                {
                    _hairStyleButtons[i].Deactivate();
                }
            }

            RecordSelectedHairButton(index);

            OnHairStyleChanged?.Invoke(index);
        }

        #endregion

        #region Internal Element Movements

        private void MoveTopDrawer(int positionIndex)
        {
            StartCoroutine(MoveUIElement(_topDrawer, _topDrawerPositions[positionIndex].position, _menuChangeDuration, _easeType ));
        }

        private void MoveBottomDrawer(int positionIndex)
        {
            StartCoroutine(MoveUIElement(_bottomDrawer, _bottomDrawerPositions[positionIndex].position, _menuChangeDuration, _easeType));
        }
        
        private void ToggleFullScreenButton(bool activated)
        {
            _fullScreenButton.SetActive(activated);
        }

        private void ToggleHairStyleParent(bool activated)
        {
            _hairStyleParent.SetActive(activated);
        }
        
        private void ToggleSkinBarParent(bool activated)
        {
            _skinColorParent.SetActive(activated);
        }
        #endregion

        #region Variable Recording

        private int LastSelectedSkinButton()
        {
            return PlayerPrefs.GetInt("lastActivatedSkin", 1);
        }

        private void RecordSelectedSkinButton(int index)
        {
            PlayerPrefs.SetInt("lastActivatedSkin", index);
        }

        private int LastSelectedHairButton()
        {
            return PlayerPrefs.GetInt("lastActivatedHair", 0);
        }

        private void RecordSelectedHairButton(int index)
        {
            PlayerPrefs.SetInt("lastActivatedHair", index);
        }

        #endregion

        #endregion

        #region COROUTINES

        private IEnumerator MoveUIElement(Transform element, Vector3 targetPosition, float moveDuration, EaseType easeType)
        {
            Vector3 startPosition = element.position;
            Vector3 endPosition = targetPosition;

            float timer = 0f;

            while (timer < _menuChangeDuration)
            {
                timer += Time.deltaTime;
                float lerp = timer / _menuChangeDuration;
                float clampedLerp = Mathf.Clamp(lerp, 0f, 1f);
                float easedLerp = KinematicEase.Evaluate(easeType, clampedLerp);

                element.position = Vector3.Lerp(startPosition, endPosition, easedLerp);
                
                yield return null;
            }
            
            

        }
        
        #endregion

    }
}