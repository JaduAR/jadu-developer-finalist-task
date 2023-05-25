using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {
    public enum ScreenOrder {
        none = 0,
        AvatarScreen = 1,
        SkinColorScreen = 2,
        HairScreen = 3
    }
    private ScreenSO _currentScreen;

    public static ScreenController Instance {
        get {
            return _instance;
        }
    }
    private static ScreenController _instance;

    [SerializeField] private CameraController _cameraController;

    [Header("UI")]
    [SerializeField] private GameObject _topUI;
    [SerializeField] private GameObject _bottomUI;    
    [SerializeField] private Animator _bottomScrollAnimator;
    [SerializeField] private CanvasGroup _mainCanvasGroup;
    [Space][Tooltip("Execution order is determined by Screen Order set on the scriptable object, not order on list")]
    [SerializeField] private List<ScreenSO> _screenList;

    private int _screenOrderEnumSize;
    private bool _isSwitchingScreen;
    
    private void Awake() {

        if (_instance != null) {
            Destroy(this);
        }
        _instance = this;

        _currentScreen = null;
        _isSwitchingScreen = false;
        _screenOrderEnumSize = Enum.GetNames(typeof(ScreenOrder)).Length;

    }

    private void Start() {

        foreach (ScreenSO so in _screenList) {
            switch (so.screenOrder) {
                case ScreenOrder.none:
                    break;
                case ScreenOrder.AvatarScreen:
                    so.SetupScript(new AvatarScreen());
                    break;
                case ScreenOrder.SkinColorScreen:
                    so.SetupScript(new SkinColorScreen());

                    break;
                case ScreenOrder.HairScreen:
                    so.SetupScript(new HairSelectionScreen());
                    break;
            }
        }

        SwitchScreen(ScreenOrder.AvatarScreen);
    }

    public void ScreenBack() {
        if (!_currentScreen ||(int)_currentScreen.screenOrder <= 1) {
            return;
        }
        SwitchScreen((_currentScreen.screenOrder - 1));
    }

    public void ScreenForward() {
        if (!_currentScreen || (int)_currentScreen.screenOrder == _screenOrderEnumSize - 1) {
            return;
        }
        SwitchScreen((_currentScreen.screenOrder + 1));
    }

    public void SelectScreen(ScreenOrder newScreen) {
        SwitchScreen(newScreen);
    }

    private void SwitchScreen(ScreenOrder newScreen) {

        foreach(ScreenSO screenSO in _screenList) {
            if(screenSO.screenOrder == newScreen && screenSO.screenOrder != _currentScreen?.screenOrder) {
                StartCoroutine(TransitionToScreen(screenSO));
                return;
            }
        }        
    }


    private IEnumerator TransitionToScreen(ScreenSO screen) {
        if (_isSwitchingScreen) {
            yield break;
        }
        _isSwitchingScreen = true;
        _mainCanvasGroup.interactable = false;


        if (!screen.showTopUI) {
            _topUI.SetActive(false);
        }

        _bottomScrollAnimator.SetInteger("Screen", (int)screen.screenOrder);        

        _currentScreen?.screenScript.LeaveScreen();
        while (_currentScreen?.screenScript.LeftScreen != true) {
            if (!_currentScreen) {
                break;
            }
            yield return null;
        }

        yield return _cameraController.MoveCamera(screen);

        screen.screenScript.EnterScreen();
        yield return new WaitUntil(delegate { return screen.screenScript.FinishedTransition; });
        
        //making sure we also finished the transition animation
        yield return new WaitWhile(delegate { return _bottomScrollAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f; });

        if (screen.showTopUI) {
            _topUI.SetActive(true);
        }

        _currentScreen = screen;

        _mainCanvasGroup.interactable = true;
        _isSwitchingScreen = false;
    }


}
