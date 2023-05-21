using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class BottomPanel : MonoBehaviour {

    [SerializeField]
    TabScriptableObject[] tabs;

    // tab selectors are the buttons that change tabs

    [SerializeField]
    BottomTab tabSelectorPrefab;

    [SerializeField]
    Transform tabSelectorParent;

    BottomTab[] tabSelectors;
    
    // tab contents are the bodies of the tabs

    [SerializeField]
    Transform tabContentParent;

    TabContents[] tabContents;

    [SerializeField]
    RectTransform selectedIndicator;

    [SerializeField]
    bool hidden = false;

    [SerializeField]
    int currentTab = 0;

    [SerializeField]
    float transitionSpeed = 1.0f;

    RectTransform rectTransform;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();

        // add tab selectors for all tabs
        tabSelectors = tabs.Select((t, i) => {
            BottomTab sel = Instantiate(tabSelectorPrefab, tabSelectorParent);
            sel.SetLabel(t.label);
            sel.AddListener(() => SetTab(i));
            return sel;
        }).ToArray();

        // add tab contents for all tabs
        tabContents = tabs.Select(t => Instantiate(t.contentPrefab, tabContentParent)).ToArray();

        // refresh current tab
        SetTab(currentTab);
    }

    private void Update() {
        // transition entire bottom panel to new height (ease out)
        float targetPosY = hidden ? 0.0f : tabs[currentTab].panelHeight;
        float curPosY = rectTransform.anchoredPosition.y;
        float newPosY = Mathf.Lerp(curPosY, targetPosY, Time.deltaTime * transitionSpeed);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newPosY);

        // transition the tab indicator to be under the current tab selector
        float indicatorTargetPos = tabSelectors[currentTab].GetComponent<RectTransform>().anchoredPosition.x;
        float curIndicatorPos = selectedIndicator.anchoredPosition.x;
        float newIndicatorPos = Mathf.Lerp(curIndicatorPos, indicatorTargetPos, Time.deltaTime * transitionSpeed * 1.5f);
        selectedIndicator.anchoredPosition = new Vector2(newIndicatorPos, selectedIndicator.anchoredPosition.y);
    }

    public bool IsHidden() => this.hidden;

    public void SetHidden(bool hidden) {
        this.hidden = hidden;
    }

    public int GetTab() => this.currentTab;

    public void SetTab(int tab) {
        // make sure invalid input doesn't break everything
        currentTab = Math.Clamp(tab, 0, tabs.Length - 1);

        // update animations/visibility of tabs
        for (int i = 0; i < tabs.Length; i++) {
            bool current = i == tab;

            tabSelectors[i].SetSelected(current);
            tabContents[i].SetSelected(current);
        }
    }

    public int NumTabs() => this.tabs.Length;
}
