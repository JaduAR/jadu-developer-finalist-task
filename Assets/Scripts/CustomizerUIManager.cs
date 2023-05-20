using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerUIManager : MonoBehaviour
{
    [SerializeField] private AnimationCurve _transitionCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private float _transitionDuration = 1f;
    [SerializeField] private List<Tab> _tabs = new List<Tab>();
    private Tab _activeTab;
    private float _lerpTimer = 0f;
    private bool _isActive = false;
    private RectTransform _rectTransform;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _isActive = false;
    }
    
    //Pulls the UI up from the bottom.
    public void ShowUI()
    {
        if (_isActive) return;
        //Sets the first tab in the list to be selected as default.
        _activeTab = _tabs[0];
        _activeTab.Select();
        UpdateUIPosition(_activeTab.TabPosition);
        _isActive = true;
    }

    //Slide UI to the bottom.
    public void HideUI()
    {
        _isActive = false;
        UpdateUIPosition(new Vector2(0,-1000));
    }
    

    public void UpdateUIPosition(Vector2 position)
    { 
        StartCoroutine(Transition(position));
    }

    //Interpolates the UI position.
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
}
