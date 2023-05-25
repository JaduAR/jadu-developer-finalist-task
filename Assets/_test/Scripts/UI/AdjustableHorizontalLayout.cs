using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustableHorizontalLayout : HorizontalLayoutGroup {

    /// <summary>
    /// Adjusts layout position and width to match children occupied space and padding (makes Transform bigger or smaller to match children)
    /// </summary>
    public void AdjustLayoutHorizontal() {
        base.SetLayoutHorizontal();

        float xMin = 0;
        float xMax = 0;
        for (int i = 0; i < transform.childCount; i++) {
            RectTransform childRect = transform.GetChild(i) as RectTransform;
            if (childRect == null || !childRect.gameObject.activeInHierarchy) {
                continue;
            }

            xMin = xMin < (childRect.anchoredPosition.x + childRect.rect.width) ? xMin : (childRect.anchoredPosition.x + childRect.rect.width);
            xMax = xMax > (childRect.anchoredPosition.x + childRect.rect.width) ? xMax : (childRect.anchoredPosition.x + childRect.rect.width);

        }
        RectTransform rectTransform = transform as RectTransform;

        rectTransform.anchoredPosition = new Vector2(xMin, rectTransform.anchoredPosition.y);
        rectTransform.sizeDelta = new Vector2(xMax - xMin, rectTransform.sizeDelta.y);
    }

}
