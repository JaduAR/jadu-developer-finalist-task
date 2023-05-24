using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickHelper : MonoBehaviour
{
    public UnityEvent clickEvent;

    private void OnMouseDown()
    {
        clickEvent.Invoke();
    }
}
