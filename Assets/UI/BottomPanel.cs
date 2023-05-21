using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour {
    [SerializeField]
    TabScriptableObject[] tabs;

    [SerializeField]
    BottomTab tabSelectorPrefab;

    [SerializeField]
    Transform tabSelectorParent;
    BottomTab[] tabSelectors;

    [SerializeField]
    Transform tabContentParent;
    GameObject[] tabContents;

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

        tabSelectors = tabs.Select((t, i) => {
            BottomTab sel = Instantiate(tabSelectorPrefab, tabSelectorParent);
            sel.SetLabel(t.label);
            sel.AddListener(() => {
                SetTab(i);
            });
            return sel;
        }).ToArray();

        tabContents = tabs.Select(t => Instantiate(t.contentPrefab, tabContentParent)).ToArray();

        SetTab(currentTab);
    }

    private void Update() {
        float target = 0.0f;

        if (!hidden) {
            target = tabs[currentTab].panelHeight;
        }

        // transition to new height (ease out)
        float curHeight = rectTransform.anchoredPosition.y;
        float newHeight = Mathf.Lerp(curHeight, target, Time.deltaTime * transitionSpeed);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newHeight);

        float indicatorTarget = tabSelectors[currentTab].GetComponent<RectTransform>().anchoredPosition.x;
        float newIndicatorPos = Mathf.Lerp(selectedIndicator.anchoredPosition.x, indicatorTarget, Time.deltaTime * transitionSpeed * 1.5f);
        selectedIndicator.anchoredPosition = new Vector2(newIndicatorPos, selectedIndicator.anchoredPosition.y);
    }

    public bool IsHidden() => this.hidden;

    public void SetHidden(bool hidden) {
        this.hidden = hidden;
    }

    public int GetTab() => this.currentTab;

    public void SetTab(int tab) {
        currentTab = Math.Clamp(tab, 0, tabs.Length - 1);

        // update animations/visibility of tabs
        for (int i = 0; i < tabs.Length; i++) {
            bool current = i == tab;

            // Use animator if present, otherwise just set active/inactive
            if (tabContents[i].GetComponent<Animator>() is Animator anim && anim != null) {
                anim.GetComponent<Animator>().SetBool("Selected", current);
            } else {
                tabContents[i].SetActive(current);
            }

            if (tabContents[i].GetComponent<CanvasGroup>() is CanvasGroup cg && cg != null) {
                cg.blocksRaycasts = current;
            }

            tabSelectors[i].SetSelected(current);
        }
    }

    public int NumTabs() => this.tabs.Length;
}
