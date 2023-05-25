using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour//, IPointerClickHandler//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject selectedRoot = null;
    [SerializeField] private GameObject unselectedRoot = null;

    public void SetActivate(bool isEnabled)
    {
        selectedRoot.SetActive(isEnabled);
        unselectedRoot.SetActive(!isEnabled);
    }
}
