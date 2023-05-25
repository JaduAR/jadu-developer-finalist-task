using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomizerUIManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private AnimationCurve _transitionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private float _transitionDuration = 1f;
    [Header("Component References")]
    [SerializeField] private List<Tab> _tabs = new List<Tab>();
    [SerializeField] private GameObject TabButtonGrid;
    [SerializeField] private GameObject TabButtonPrefab;
    [Header("Events")]
    public UnityEvent OnUIOpened;
    public UnityEvent OnUIClosed;
    
    private Tab _activeTab;
    private bool _isActive = false;
    private RectTransform _rectTransform;
    
    private Coroutine _transitionCoroutine;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _isActive = false;
        //Create tab buttons for grid container in header.
        foreach(var tab in _tabs)
        {
            var button = Instantiate(TabButtonPrefab, TabButtonGrid.transform);
            var tabButtonController = button.GetComponent<TabButtonController>();
            tabButtonController.Button.onClick.AddListener(() => SetActiveTab(_tabs.IndexOf(tab)));
            tabButtonController.SetText(tab.TabName);
            tab.SetButton(tabButtonController);
        }
    }
    
    //Switches to the tab at the given index.
    public void SetActiveTab(int index)
    {
        var tab = _tabs[index];
        if (_activeTab != null && _activeTab != tab)
        {
            _activeTab.Deselect();
        }
        _activeTab = tab;
        _activeTab.Select();
        UpdateUIPosition(_activeTab.TabPosition);
    }
    
    //Pulls the UI up from the bottom.
    public void ShowUI()
    {
        if(_isActive) return;
        if (_tabs == null || _tabs.Count == 0)
        {
            Debug.LogError("No tabs assigned to CustomizerUIManager.");
            return;
        }
        //Sets the first tab in the list to be selected as default.
        SetActiveTab(0);
        _isActive = true;
        OnUIOpened?.Invoke();
    }

    //Slide UI to the bottom.
    public void HideUI()
    {
        _activeTab?.Deselect();
        _isActive = false;
        UpdateUIPosition(new Vector2(0,-1000));
        OnUIClosed?.Invoke();
    }

    private void UpdateUIPosition(Vector2 position)
    { 
        if(_transitionCoroutine != null)
            StopCoroutine(_transitionCoroutine);
        _transitionCoroutine = StartCoroutine(Transition(position));
    }

    //Interpolates the UI position based on anchored position.
    private IEnumerator Transition(Vector2 endPos)
    {
        var elapsedTime = 0f;
        var startPos = _rectTransform.anchoredPosition;
        while (elapsedTime < _transitionDuration)
        {
            _rectTransform.anchoredPosition = Vector3.Lerp(startPos, endPos, _transitionCurve.Evaluate(elapsedTime / _transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    //Clears the button click events on destroy.
    private void OnDestroy()
    {
        foreach(var tab in _tabs)
        {
            tab.ButtonController.Button.onClick.RemoveAllListeners();
        }
    }
}
